using Core.Code.Attributes;
using Core.Code.Helpers;
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
                        var usdaNutrient = (USDANutrients)nutrientId;
                        var measure = usdaNutrient.GetMeasure() ?? throw new InvalidOperationException("Missing measure!");
                        if (ingredient.USDANutrients.Select(n => n.Nutrients).Contains(usdaNutrient))
                        {
                            var existingNutrient = ingredient.USDANutrients.First(n => n.Nutrients == usdaNutrient);
                            if (existingNutrient.Value != amount || existingNutrient.Measure != measure)
                            {
                                Console.WriteLine($"Updating {usdaNutrient} for {ingredient.FoodName}.");
                                existingNutrient.Value = amount;
                                existingNutrient.Measure = measure;
                                existingNutrient.LastUpdated = DateHelpers.Today;
                                await _nutrientRepo.UpdateNutrient(existingNutrient);
                            }
                        }
                        else if (amount != 0)
                        {
                            Console.WriteLine($"Inserting {usdaNutrient} for {ingredient.FoodName}.");
                            newNutrients.Add(new USDANutrient()
                            {
                                Value = amount,
                                Measure = measure,
                                Nutrients = usdaNutrient,
                                IngredientId = ingredient.Id,
                                LastUpdated = DateHelpers.Today,
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
