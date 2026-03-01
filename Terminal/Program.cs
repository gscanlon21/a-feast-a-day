// See https://aka.ms/new-console-template for more information
using Core.Models.User;
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
            '5' => await RegenerateNutrients(downloadPath),
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


static async Task<Response> RegenerateNutrients(string downloadPath)
{
    // Shouldn't have these hardcoded.
    Console.WriteLine("What is the path to nutrient.csv?");
    var inputPath = Console.ReadLine() ?? throw new Exception("Missing nutrient.csv!");
    var outputPath = "C:/code/afeastaday/Core/Models/User/Nutrients.cs";

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

    var dailyAllowanceMap = new[]
    {
        // MACRONUTRIENTS
        new { Key = "Protein", Data = new DailyAllowance(10d, 35d, "Percent", "Person", 4, "Adult") },
        new { Key = "Sugar", Data = new DailyAllowance(6d, 12d, "Percent", "Person", 4, "Adult") },
        new { Key = "Oligosaccharides", Data = new DailyAllowance(1d, -1d, "Grams", "Person", 4, "Adult") },
        new { Key = "Starch", Data = new DailyAllowance(130d, -1d, "Grams", "Person", 4, "Adult") },

        new { Key = "Net Carbohydrates", Data = new DailyAllowance(130d, -1d, "Grams", "Person", 4, "Adult") },
        new { Key = "Net Carbohydrates", Data = new DailyAllowance(175d, -1d, "Grams", "Person", 4, "PregnantWoman") },
        new { Key = "Net Carbohydrates", Data = new DailyAllowance(210d, -1d, "Grams", "Person", 4, "BreastfeedingWoman") },

        //new { Key = "Soluble Dietary Fiber", Data = new DailyAllowance(10d, -1d, "Grams", "Kilocalorie", 4, "Adult") },
        //new { Key = "Insoluble Dietary Fiber", Data = new DailyAllowance(15d, -1d, "Grams", "Kilocalorie", 4, "Adult") },
        new { Key = "Fiber", Data = new DailyAllowance(25d, -1d, "Grams", "Kilocalorie", 4, "Adult") },

        new { Key = "Carbohydrates", Data = new DailyAllowance(45d, 65d, "Percent", "Person", 4, "Adult") },

        new { Key = "Trans Fats", Data = new DailyAllowance(-1d, 1d, "Percent", "Person", 9, "Adult") },
        new { Key = "Saturated Fats", Data = new DailyAllowance(-1d, 10d, "Percent", "Person", 9, "Adult") },
        new { Key = "Monounsaturated Fats", Data = new DailyAllowance(-1d, 10d, "Percent", "Person", 9, "Adult") },
        new { Key = "Omega 3", Data = new DailyAllowance(-1d, 10d, "Percent", "Person", 9, "Adult") },
        new { Key = "Omega 6", Data = new DailyAllowance(-1d, 10d, "Percent", "Person", 9, "Adult") },
        new { Key = "Polyunsaturated Fats", Data = new DailyAllowance(-1d, 10d, "Percent", "Person", 9, "Adult") },
        new { Key = "Unsaturated Fats", Data = new DailyAllowance(-1d, 20d, "Percent", "Person", 9, "Adult") },
        new { Key = "Fats", Data = new DailyAllowance(20d, 35d, "Percent", "Person", 9, "Adult") },

        new { Key = "Calories", Data = new DailyAllowance(1000d, 1100d, "None", "Kilocalorie", 0, "Adult") },

        new { Key = "Cholesterol", Data = new DailyAllowance(-1d, -1d, "Milligrams", "Person", 0, "Adult") },

        // ANTIOXIDANTS
        new { Key = "Flavanoids", Data = new DailyAllowance(1d, 10d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "NonFlavanoids", Data = new DailyAllowance(1d, 10d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Polyphenols", Data = new DailyAllowance(1d, 10d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Non-provitamin A Carotenoids", Data = new DailyAllowance(10d, 100d, "Milligrams", "Person", 0, "Adult") },

        // VITAMINS
        new { Key = "Alpha Carotene", Data = new DailyAllowance(10d, 100d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Beta Carotene", Data = new DailyAllowance(10d, 100d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Provitamin A Carotenoids", Data = new DailyAllowance(10d, 100d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Carotenoids", Data = new DailyAllowance(10d, 100d, "Milligrams", "Person", 0, "Adult") },

        new { Key = "Retinol", Data = new DailyAllowance(900d, 3000d, "Micrograms", "Person", 0, "Man") },
        new { Key = "Retinol", Data = new DailyAllowance(700d, 3000d, "Micrograms", "Person", 0, "Woman") },

        new { Key = "Vitamin A", Data = new DailyAllowance(900d, 3000d, "Micrograms", "Person", 0, "Man") },
        new { Key = "Vitamin A", Data = new DailyAllowance(700d, 3000d, "Micrograms", "Person", 0, "Woman") },

        new { Key = "Vitamin B-1", Data = new DailyAllowance(1.2d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Vitamin B-1", Data = new DailyAllowance(1.1d, -1d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Vitamin B-1", Data = new DailyAllowance(1.4d, -1d, "Milligrams", "Person", 0, "PregnantOrBreastfeedingWoman") },

        new { Key = "Vitamin B-2", Data = new DailyAllowance(1.3d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Vitamin B-2", Data = new DailyAllowance(1.1d, -1d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Vitamin B-2", Data = new DailyAllowance(1.4d, -1d, "Milligrams", "Person", 0, "PregnantWoman") },
        new { Key = "Vitamin B-2", Data = new DailyAllowance(1.6d, -1d, "Milligrams", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Vitamin B-3", Data = new DailyAllowance(16d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Vitamin B-3", Data = new DailyAllowance(14d, -1d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Vitamin B-3", Data = new DailyAllowance(17d, -1d, "Milligrams", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Pantothenic", Data = new DailyAllowance(5d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Pantothenic", Data = new DailyAllowance(6d, -1d, "Milligrams", "Person", 0, "PregnantWoman") },
        new { Key = "Pantothenic", Data = new DailyAllowance(7d, -1d, "Milligrams", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Vitamin B-6", Data = new DailyAllowance(1.3d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Vitamin B-6", Data = new DailyAllowance(1.5d, -1d, "Milligrams", "Person", 0, "ElderlyWoman") },
        new { Key = "Vitamin B-6", Data = new DailyAllowance(1.7d, -1d, "Milligrams", "Person", 0, "ElderlyMan") },

        new { Key = "Vitamin B-7", Data = new DailyAllowance(30d, -1d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Vitamin B-7", Data = new DailyAllowance(35d, -1d, "Micrograms", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Folate", Data = new DailyAllowance(400d, -1d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Folate", Data = new DailyAllowance(600d, -1d, "Micrograms", "Person", 0, "PregnantWoman") },
        new { Key = "Folate", Data = new DailyAllowance(500d, -1d, "Micrograms", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Vitamin B-12", Data = new DailyAllowance(2.4d, -1d, "Micrograms", "Person", 0, "Adult") },

        new { Key = "Vitamin C", Data = new DailyAllowance(90d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Vitamin C", Data = new DailyAllowance(75d, -1d, "Milligrams", "Person", 0, "Woman") },

        new { Key = "Vitamin D2", Data = new DailyAllowance(20d, 100d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Vitamin D2", Data = new DailyAllowance(25d, 100d, "Micrograms", "Person", 0, "Elderly") },
        new { Key = "Vitamin D3", Data = new DailyAllowance(20d, 100d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Vitamin D3", Data = new DailyAllowance(25d, 100d, "Micrograms", "Person", 0, "Elderly") },
        new { Key = "Vitamin D", Data = new DailyAllowance(20d, 100d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Vitamin D", Data = new DailyAllowance(25d, 100d, "Micrograms", "Person", 0, "Elderly") },

        new { Key = "Vitamin E", Data = new DailyAllowance(15d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Vitamin E", Data = new DailyAllowance(19d, -1d, "Milligrams", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Vitamin K1", Data = new DailyAllowance(90d, -1d, "Micrograms", "Person", 0, "Woman") },
        new { Key = "Vitamin K1", Data = new DailyAllowance(120d, -1d, "Micrograms", "Person", 0, "Man") },
        new { Key = "Vitamin K2", Data = new DailyAllowance(90d, -1d, "Micrograms", "Person", 0, "Woman") },
        new { Key = "Vitamin K2", Data = new DailyAllowance(120d, -1d, "Micrograms", "Person", 0, "Man") },
        new { Key = "Vitamin K", Data = new DailyAllowance(90d, -1d, "Micrograms", "Person", 0, "Woman") },
        new { Key = "Vitamin K", Data = new DailyAllowance(120d, -1d, "Micrograms", "Person", 0, "Man") },

        // MINERALS
        new { Key = "Calcium", Data = new DailyAllowance(750d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Chloride", Data = new DailyAllowance(800d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Magnesium", Data = new DailyAllowance(400d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Magnesium", Data = new DailyAllowance(350d, -1d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Potassium", Data = new DailyAllowance(3500d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Sodium", Data = new DailyAllowance(1500d, 2300d, "Milligrams", "Person", 0, "Adult") },

        new { Key = "Chromium", Data = new DailyAllowance(35d, -1d, "Micrograms", "Person", 0, "Man") },
        new { Key = "Chromium", Data = new DailyAllowance(25d, -1d, "Micrograms", "Person", 0, "Woman") },
        new { Key = "Chromium", Data = new DailyAllowance(40d, -1d, "Micrograms", "Person", 0, "PregnantOrBreastfeedingWoman") },

        new { Key = "Copper", Data = new DailyAllowance(900d, -1d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Fluoride", Data = new DailyAllowance(2.5d, 10d, "Milligrams", "Person", 0, "Adult") },

        new { Key = "Iodine", Data = new DailyAllowance(150d, -1d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Iodine", Data = new DailyAllowance(220d, -1d, "Micrograms", "Person", 0, "PregnantWoman") },
        new { Key = "Iodine", Data = new DailyAllowance(290d, -1d, "Micrograms", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Iron", Data = new DailyAllowance(8d, 45d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Iron", Data = new DailyAllowance(18d, 45d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Iron", Data = new DailyAllowance(27d, 45d, "Milligrams", "Person", 0, "PregnantWoman") },
        new { Key = "Iron", Data = new DailyAllowance(9d, 45d, "Milligrams", "Person", 0, "BreastfeedingWoman") },
        new { Key = "Iron", Data = new DailyAllowance(8d, 45d, "Milligrams", "Person", 0, "ElderlyWoman") },

        new { Key = "Manganese", Data = new DailyAllowance(2.3d, -1d, "Milligrams", "Person", 0, "Man") },
        new { Key = "Manganese", Data = new DailyAllowance(1.8d, -1d, "Milligrams", "Person", 0, "Woman") },
        new { Key = "Manganese", Data = new DailyAllowance(2.0d, -1d, "Milligrams", "Person", 0, "PregnantWoman") },
        new { Key = "Manganese", Data = new DailyAllowance(2.6d, -1d, "Milligrams", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Selenium", Data = new DailyAllowance(55d, 400d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Selenium", Data = new DailyAllowance(60d, 400d, "Micrograms", "Person", 0, "PregnantWoman") },
        new { Key = "Selenium", Data = new DailyAllowance(70d, 400d, "Micrograms", "Person", 0, "BreastfeedingWoman") },

        new { Key = "Zinc", Data = new DailyAllowance(10d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Zinc", Data = new DailyAllowance(12d, -1d, "Milligrams", "Person", 0, "PregnantOrBreastfeedingWoman") },

        new { Key = "Molybdenum", Data = new DailyAllowance(45d, -1d, "Micrograms", "Person", 0, "Adult") },
        new { Key = "Molybdenum", Data = new DailyAllowance(50d, -1d, "Micrograms", "Person", 0, "PregnantOrBreastfeedingWoman") },

        new { Key = "Phosphorus", Data = new DailyAllowance(700d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Sulfur", Data = new DailyAllowance(850d, -1d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Boron", Data = new DailyAllowance(2d, 20d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Vanadium", Data = new DailyAllowance(20d, 1000d, "Micrograms", "Person", 0, "Adult") },

        // OTHER
        new { Key = "Lithium", Data = new DailyAllowance(1d, 25d, "Grams", "Person", 0, "Adult") },
        new { Key = "Choline", Data = new DailyAllowance(500d, 3500d, "Milligrams", "Person", 0, "Adult") },
        new { Key = "Betaine", Data = new DailyAllowance(500d, 3500d, "Milligrams", "Person", 0, "Adult") },

        // AMINO ACIDS
        new { Key = "Histidine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Isoleucine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Leucine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Lysine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Methionine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Phenylalanine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Threonine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Tryptophan", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Valine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Arginine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
        new { Key = "Glycine", Data = new DailyAllowance(.5d, 10d, "Grams", "Person", 0, "Adult") },
    }.ToLookup(x => x.Key, x => x.Data);

    var builder = new StringBuilder();

    builder.AppendLine("using Core.Code.Attributes;");
    builder.AppendLine("using System.ComponentModel.DataAnnotations;");
    builder.AppendLine();
    builder.AppendLine("namespace Core.Models.User;");
    builder.AppendLine();
    builder.AppendLine("public enum Nutrients");
    builder.AppendLine("{");
    builder.AppendLine("    None = 0,");

    using var parser = new TextFieldParser(inputPath.Replace("\"", ""));
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
        var name = new string(originalName.Select(c => char.IsLetterOrDigit(c) || c == '_' ? c : '_').ToArray());
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
            .Where(kvp => originalName.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
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