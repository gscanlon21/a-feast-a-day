using Core.Code.Attributes;
using Core.Code.Helpers;
using Core.Models.Nutrients;
using Data.Entities.Nutrients;
using Data.Repos;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Terminal.Models.HealthCanada;
using Terminal.Options;

namespace Terminal.Programs.HealthCanada;

/// <summary>
/// Load a food nutrient data from FDA's FoodData Central.
/// </summary>
internal class LoadHealthCanadaNutrientData
{
    private readonly NutrientRepo _nutrientRepo;
    private readonly IOptions<HealthCanadaSettings> _healthCanadaSettings;

    public LoadHealthCanadaNutrientData(NutrientRepo nutrientRepo, IOptions<HealthCanadaSettings> healthCanadaSettings)
    {
        _nutrientRepo = nutrientRepo;
        _healthCanadaSettings = healthCanadaSettings;
    }

    public async Task<Response> Execute()
    {
        Console.WriteLine("What is the path to 'NUTRIENT AMOUNT.csv'?");
        var foodNutrientPath = _healthCanadaSettings.Value.NutrientAmount.NullIfEmpty() ?? Console.ReadLine() ?? throw new Exception("Missing 'NUTRIENT AMOUNT.csv'!");

        var ingredientsWithFoodData = (await _nutrientRepo.GetIngredientsWithHealthCanadaData())
            .ToLookup(i => i.IngredientAttr!.HC_Id!.Value, i => i);

        using var parser = new TextFieldParser(foodNutrientPath.Replace("\"", ""));
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        List<HealthCanadaNutrient> newNutrients = [];
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
                if (!int.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.FOOD_ID)], out int foodId))
                {
                    Console.WriteLine($"Missing: {NutrientAmountHeaders.FOOD_ID}");
                    continue;
                }

                // This is going to be slow.
                foreach (var ingredient in ingredientsWithFoodData[foodId] ?? [])
                {
                    if (int.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.NUTRIENT_ID)], out int nutrientId)
                        && double.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.NUTRIENT_VALUE)], out double amount))
                    {
                        var canadaNutrient = (CanadaNutrients)nutrientId;
                        var measure = canadaNutrient.GetMeasure() ?? throw new InvalidOperationException("Missing measure!");
                        if (ingredient.CanadaNutrients.Select(n => n.Nutrients).Contains(canadaNutrient))
                        {
                            var existingNutrient = ingredient.CanadaNutrients.First(n => n.Nutrients == canadaNutrient);
                            if (existingNutrient.Value != amount || existingNutrient.Measure != measure)
                            {
                                Console.WriteLine($"Updating {canadaNutrient} for {ingredient.FoodName}.");
                                existingNutrient.Value = amount;
                                existingNutrient.Measure = measure;
                                existingNutrient.LastUpdated = DateHelpers.Today;
                                await _nutrientRepo.UpdateNutrientCa(existingNutrient);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Inserting {canadaNutrient} for {ingredient.FoodName}.");
                            newNutrients.Add(new HealthCanadaNutrient()
                            {
                                Value = amount,
                                Measure = measure,
                                Nutrients = canadaNutrient,
                                IngredientId = ingredient.Id,
                                LastUpdated = DateHelpers.Today,
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Missing: {NutrientAmountHeaders.NUTRIENT_ID}");
                        Console.WriteLine($"Missing: {NutrientAmountHeaders.NUTRIENT_VALUE}");
                    }
                }
            }
        }

        await _nutrientRepo.InsertCanadaNutrients(newNutrients);
        return Response.Success();
    }
}
