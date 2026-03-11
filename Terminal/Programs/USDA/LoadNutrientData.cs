using Core.Code.Attributes;
using Core.Models.Nutrients;
using Data.Entities.Nutrients;
using Data.Repos;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Terminal.Models.USDA;
using Terminal.Options;

namespace Terminal.Programs.USDA;

/// <summary>
/// Load a food nutrient data from FDA's FoodData Central.
/// </summary>
internal class LoadUSDANutrientData
{
    private readonly NutrientRepo _nutrientRepo;
    private readonly IOptions<USDASettings> _usdaSettings;

    public LoadUSDANutrientData(NutrientRepo nutrientRepo, IOptions<USDASettings> usdaSettings)
    {
        _nutrientRepo = nutrientRepo;
        _usdaSettings = usdaSettings;
    }

    public async Task<Response> Execute()
    {
        Console.WriteLine("What is the path to food_nutrient.csv?");
        var foodNutrientPath = _usdaSettings.Value.FoodNutrient.NullIfEmpty() ?? Console.ReadLine() ?? throw new Exception("Missing food_nutrient.csv!");

        var ingredientsWithFoodData = (await _nutrientRepo.GetIngredientsWithFoodData())
            .ToLookup(i => i.IngredientAttr!.FDC_ID!.Value, i => i);

        using var parser = new TextFieldParser(foodNutrientPath.Replace("\"", ""));
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        List<USDANutrient> newNutrients = [];
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
                        var nutrients2 = (USDANutrients)nutrientId;
                        var measure = nutrients2.GetMeasure() ?? throw new InvalidOperationException("Missing measure!");
                        if (ingredient.Nutrients.Select(n => (int)n.Nutrients).Contains(nutrientId))
                        {
                            var existingNutrient = ingredient.Nutrients.First(n => (int)n.Nutrients == nutrientId);
                            if (existingNutrient.Value != amount || existingNutrient.Measure != measure)
                            {
                                Console.WriteLine($"Updating Nutrient: {nutrients2}");
                                existingNutrient.Value = amount;
                                existingNutrient.Measure = measure;
                                await _nutrientRepo.UpdateNutrient(existingNutrient);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Inserting Nutrient: {nutrients2}");
                            newNutrients.Add(new USDANutrient()
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

        await _nutrientRepo.InsertNewNutrients(newNutrients);
        return Response.Success();
    }
}
