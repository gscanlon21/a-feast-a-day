// See https://aka.ms/new-console-template for more information
using Core.Models;
using Core.Models.Nutrients;
using Data;
using Data.Entities.Ingredients;
using Data.Repos;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using System.IO.Compression;


using var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    })
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CoreContext>(options => options.UseNpgsql(context.Configuration.GetConnectionString("CoreContext") ?? throw new InvalidOperationException("Connection string 'CoreContext' not found."), options =>
        {
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
        }));
        services.AddTransient<NutrientRepo>();
        services.AddTransient<UserRepo>();
    }).Build();

var nutrientRepo = host.Services.GetRequiredService<NutrientRepo>();
var configuration = host.Services.GetRequiredService<IConfiguration>();
var downloadPath = configuration.GetValue<string>("DownloadPath")?.NullIfWhiteSpace() ?? AppContext.BaseDirectory;
var foodDataApiKey = configuration.GetSection("FoodData")?.GetValue<string>("ApiKey");
using HttpClient httpClient = new();
ConsoleKeyInfo actionKeyPressed;
do
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1: Download datasets from FDA's FoodData Central");
    Console.WriteLine("2: Search for food in FDA's FoodData Central");
    Console.WriteLine("3: Load nutrient data from a CSV file");
    Console.WriteLine("4: Download dietary reference intake");
    Console.WriteLine("5: Regenerate Nutrients");
    Console.WriteLine("0: Exit");
    actionKeyPressed = Console.ReadKey();

    Console.WriteLine();
    Console.WriteLine();

    try
    {
        var response = actionKeyPressed.KeyChar switch
        {
            '1' => await DownloadDatasetsFromFoodDataCentral(httpClient, downloadPath),
            '2' => await DownloadFoodFromFoodDataCentral(httpClient, foodDataApiKey),
            '3' => await LoadNutrientDataFromFoodDataCentral(nutrientRepo),
            '4' => await DownloadDietaryReferenceIntakes(httpClient, downloadPath),
            '5' => await RegenerateNutrients(),
            _ => Response.Success(),
        };

        if (response.Status == ResponseStatus.Failure)
        {
            Console.WriteLine(response.Message);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine();
    Console.WriteLine();
}
while (actionKeyPressed.KeyChar != '0');


/// <summary>
/// Downloads the entire dataset from FDA's FoodData Central.
/// </summary>
static async Task<Response> DownloadDatasetsFromFoodDataCentral(HttpClient httpClient, string downloadPath)
{
    Console.WriteLine("Go here: https://fdc.nal.usda.gov/download-datasets");
    Console.WriteLine("What is the download file link?");
    var url = Console.ReadLine();

    using var response = (await httpClient.GetAsync(url)).EnsureSuccessStatusCode();

    using var memoryStream = new MemoryStream();
    await response.Content.CopyToAsync(memoryStream);

    Console.WriteLine($"Writing to directory: {downloadPath}");
    await ZipFile.ExtractToDirectoryAsync(memoryStream, downloadPath);

    return Response.Success();
}

/// <summary>
/// Downloads a subset of foods from FDA's FoodData Central.
/// </summary>
static async Task<Response> DownloadFoodFromFoodDataCentral(HttpClient httpClient, string? apiKey)
{
    Console.WriteLine("What is the food name?");
    var foodName = Console.ReadLine();

    var response = (await httpClient.PostAsync($"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={apiKey ?? throw new Exception("Missing api key!")}", new StringContent(
        JsonSerializer.Serialize(new
        {
            query = foodName,
            pageSize = 10
        }),
        Encoding.UTF8,
        "application/json"
    ))).EnsureSuccessStatusCode();

    var json = JsonSerializer.Deserialize<object>(await response.Content.ReadAsStringAsync());
    var fileName = $"{foodName}_results.json";

    await File.WriteAllTextAsync(fileName, JsonSerializer.Serialize(json, JsonSerializerOptions.Default));
    Console.WriteLine($"Results saved to {fileName}");

    return Response.Success();
}

/// <summary>
/// Load a food nutrient data from FDA's FoodData Central.
/// </summary>
static async Task<Response> LoadNutrientDataFromFoodDataCentral(NutrientRepo nutrientRepo)
{
    Console.WriteLine("What is the path to food_nutrient.csv?");
    var foodNutrientPath = Console.ReadLine() ?? throw new Exception("Missing food_nutrient.csv!");

    var ingredientsWithFoodData = (await nutrientRepo.GetIngredientsWithFoodData())
        .ToLookup(i => i.IngredientAttr!.FDC_ID!.Value, i => i);

    using var parser = new TextFieldParser(foodNutrientPath.Replace("\"", ""));
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");

    List<Nutrient> newNutrients = [];
    string[]? actualHeaders = null;
    while (!parser.EndOfData)
    {
        var rows = parser.ReadFields();
        if (actualHeaders == null)
        {
            actualHeaders = rows;
        }
        else
        {
            if (!int.TryParse(rows?[actualHeaders.IndexOf(FoodNutrientHeaders.FDC_ID)], out int fdcId))
            {
                Console.WriteLine($"Missing: {FoodNutrientHeaders.FDC_ID}");
                continue;
            }

            // This is going to be slow.
            foreach (var ingredient in ingredientsWithFoodData[fdcId] ?? [])
            {
                if (int.TryParse(rows?[actualHeaders.IndexOf(FoodNutrientHeaders.NUTRIENT_ID)], out int nutrientId)
                    && double.TryParse(rows?[actualHeaders.IndexOf(FoodNutrientHeaders.AMOUNT)], out double amount))
                {
                    var nutrients2 = (Nutrients)nutrientId;
                    var measure = nutrients2.GetMeasure() ?? Measure.None;
                    if (ingredient.Nutrients.Select(n => (int)n.Nutrients).Contains(nutrientId))
                    {
                        var existingNutrient = ingredient.Nutrients.First(n => (int)n.Nutrients == nutrientId);
                        if (existingNutrient.Value != amount || existingNutrient.Measure != measure)
                        {
                            Console.WriteLine($"Updating Nutrient: {nutrients2}");
                            existingNutrient.Value = amount;
                            existingNutrient.Measure = measure;
                            await nutrientRepo.UpdateNutrient(existingNutrient);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Inserting Nutrient: {nutrients2}");
                        newNutrients.Add(new Nutrient()
                        {
                            Value = amount,
                            Measure = measure,
                            Nutrients = nutrients2,
                            IngredientId = ingredient.Id,
                        });
                    }
                }
                else
                {
                    Console.WriteLine($"Missing: {FoodNutrientHeaders.NUTRIENT_ID}");
                    Console.WriteLine($"Missing: {FoodNutrientHeaders.AMOUNT}");
                }
            }
        }
    }

    await nutrientRepo.InsertNewNutrients(newNutrients);
    return Response.Success();
}

static async Task<Response> DownloadDietaryReferenceIntakes(HttpClient httpClient, string downloadPath)
{
    var html = await httpClient.GetStringAsync("https://www.ncbi.nlm.nih.gov/books/NBK56068/table/summarytables.t2/?report=objectonly");

    var doc = new HtmlDocument();
    doc.LoadHtml(html);

    var tables = doc.DocumentNode.SelectNodes("//table");
    if (tables == null)
    {
        return Response.Failure("Specified table not found.");
    }

    var rows = tables[0].SelectNodes(".//tr");
    if (rows == null)
    {
        return Response.Failure("No rows found in table.");
    }

    var sb = new StringBuilder();
    foreach (var row in rows)
    {
        var cells = row.SelectNodes("./th|./td");
        if (cells == null)
        {
            continue;
        }

        // TODO Escape CSV data.
        var values = cells.Select(cell => cell.InnerText.Trim());

        sb.AppendLine(string.Join(",", values));
    }

    await File.WriteAllTextAsync(downloadPath, sb.ToString(), Encoding.UTF8);

    Console.WriteLine($"CSV saved to {downloadPath}");

    return Response.Success();
}



async Task<Response> RegenerateNutrients()
{
    // Shouldn't have these hardcoded.
    Console.WriteLine("What is the path to nutrient.csv?");
    ShortTermMemory.Nutrient_csv ??= Console.ReadLine() ?? throw new Exception("Missing nutrient.csv!");
    var outputPath = "C:/code/afeastaday/Core/Models/Nutrients/Nutrients.cs";

    var dailyAllowanceMap = await nutrientRepo.GetDietaryIntakeMap();
    var measureMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        [""] = "None",
        ["IU"] = "IU",
        ["PH"] = "PH",
        ["G"] = "Grams",
        ["kJ"] = "KiloJoule",
        ["KCAL"] = "KCalorie",
        ["UG"] = "Micrograms",
        ["MG"] = "Milligrams",
        ["MCG_RE"] = "MCG_RE",
        ["MG_GAE"] = "MG_GAE",
        ["MG_ATE"] = "MG_ATE",
        ["UMOL_TE"] = "UMOL_TE",
        ["SP_GR"] = "SpecificGravity"
    };

    var builder = new StringBuilder();

    builder.AppendLine("using Core.Code.Attributes;");
    builder.AppendLine("using System.ComponentModel.DataAnnotations;");
    builder.AppendLine();
    builder.AppendLine("namespace Core.Models.Nutrients;");
    builder.AppendLine();
    builder.AppendLine("public enum Nutrients");
    builder.AppendLine("{");
    builder.AppendLine("    None = 0,");

    using var parser = new TextFieldParser(ShortTermMemory.Nutrient_csv.Replace("\"", ""));
    parser.HasFieldsEnclosedInQuotes = true;
    parser.SetDelimiters(",");

    var headers = parser.ReadFields();
    if (headers == null)
    {
        return Response.Failure("No headers!");
    }

    while (!parser.EndOfData)
    {
        var fields = parser.ReadFields();
        if (fields == null)
        {
            continue;
        }

        var row = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < headers.Length && i < fields.Length; i++)
        {
            row[headers[i]] = fields[i];
        }

        var originalName = row.TryGetValue("name", out string? value2) ? value2 : "";
        var unitName = row.TryGetValue("unit_name", out string? value3) ? value3?.Trim() ?? "" : "";
        var id = row.ContainsKey("id") ? row["id"] : "0";

        // Pretty-up the nutrient name for C#.
        var name = new string(originalName.Select(c => char.IsLetterOrDigit(c) ? c : '_').ToArray());
        name = name.Replace("__", "_");
        while (name.Contains("___"))
        {
            name = name.Replace("___", "__");
        }

        name = name.Trim('_');

        if (!string.IsNullOrEmpty(name) && char.IsDigit(name[0]))
        {
            name = "_" + name;
        }

        // Map unit_name to Measure.
        if (!measureMap.TryGetValue(unitName, out var measure))
        {
            Console.WriteLine($"Warning: Unknown unit_name '{unitName}' for nutrient '{name}'. Using Measure.None.");
            measure = "None";
        }

        name = name + "_" + measure;

        double rank = -1;
        if (row.TryGetValue("rank", out string? value1)
            && !string.IsNullOrWhiteSpace(value1)
            && double.TryParse(value1, out var parsedRank))
        {
            rank = parsedRank;
        }

        double nutrientNumber = -1;
        if (row.TryGetValue("nutrient_nbr", out string? value)
            && !string.IsNullOrWhiteSpace(value)
            && double.TryParse(value, out var parsedNbr))
        {
            nutrientNumber = parsedNbr;
        }

        builder.AppendLine();
        builder.AppendLine($"    /// <summary>");
        builder.AppendLine($"    /// {originalName}");
        builder.AppendLine($"    /// </summary>");

        foreach (var dailyAllowance in dailyAllowanceMap
            .Where(kvp => originalName.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase)
                || name.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase))
            .SelectMany(kv => kv))
        {
            builder.AppendLine($"    [DailyAllowance({dailyAllowance.Min}, {dailyAllowance.Max}, Measure.{dailyAllowance.Measure}, Multiplier.{dailyAllowance.Multiplier}, CaloriesPerGram = {dailyAllowance.CaloriesPerGram}, For = Person.{dailyAllowance.Person})]");
        }

        builder.AppendLine($"    [NutrientsMetadata(Measure.{measure}, {nutrientNumber.ToString(CultureInfo.InvariantCulture)}, {rank.ToString(CultureInfo.InvariantCulture)})]");
        builder.AppendLine($"    [Display(Name = \"{originalName}\")]");
        builder.AppendLine($"    {name} = {id},");
    }

    builder.AppendLine("}");

    File.WriteAllText(outputPath, builder.ToString(), Encoding.UTF8);

    Console.WriteLine($"Finished writing {outputPath}");
    return Response.Success();
}