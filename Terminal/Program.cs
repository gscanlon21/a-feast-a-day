// See https://aka.ms/new-console-template for more information
using Data;
using Data.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualBasic.FileIO;
using System.IO.Compression;
using Terminal.Models;


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

    string[]? actualHeaders = null;
    string[] expectedHeaders = ["id", "fdc_id", "nutrient_id", "amount", "data_points", "derivation_id", "min", "max", "median", "loq", "footnote", "min_year_acquired"];

    var ingredientsWithFoodData = await nutrientRepo.GetIngredientsWithFoodData();

    using var parser = new TextFieldParser(foodNutrientPath.Replace("\"", ""));
    parser.TextFieldType = FieldType.Delimited;
    parser.SetDelimiters(",");
    
    while (!parser.EndOfData)
    {
        var rows = parser.ReadFields();
        if (actualHeaders == null)
        {
            actualHeaders = rows;
            Console.WriteLine(string.Join(", ", expectedHeaders));
            Console.WriteLine(string.Join(", ", expectedHeaders.Intersect(actualHeaders!)));
            // TODO find the actual header positions.
            // Some headers are included in the full set that aren't in the foundation set.
            if (!expectedHeaders.Intersect(actualHeaders!).SequenceEqual(expectedHeaders))
            {
                throw new Exception("Invalid headers!");
            }
        }
        else
        {
            foreach (var cell in rows ?? [])
            {
                Console.WriteLine(cell);
            }
        }
    }

    return Response.Success();
}
