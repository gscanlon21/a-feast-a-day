using Core.Models;
using Core.Models.Nutrients;
using Data.Entities.Ingredients;
using Data.Repos;
using Microsoft.VisualBasic.FileIO;

namespace Terminal.Programs.HealthCanada;

/// <summary>
/// Load a food nutrient data from FDA's FoodData Central.
/// </summary>
internal class LoadHealthCanadaNutrientData
{
    private readonly NutrientRepo _nutrientRepo;

    public LoadHealthCanadaNutrientData(NutrientRepo nutrientRepo)
    {
        _nutrientRepo = nutrientRepo;
    }

    public async Task<Response> Execute()
    {
        Console.WriteLine("What is the path to 'NUTRIENT AMOUNT.csv'?");
        var foodNutrientPath = Console.ReadLine() ?? throw new Exception("Missing 'NUTRIENT AMOUNT.csv'!");

        var ingredientsWithFoodData = (await _nutrientRepo.GetIngredientsWithHealthCanadaData())
            .ToLookup(i => i.IngredientAttr!.HC_Id!.Value, i => i);

        using var parser = new TextFieldParser(foodNutrientPath.Replace("\"", ""));
        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(",");

        List<NutrientCanada> newNutrients = [];
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
                if (!int.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.FOOD_ID)], out int fdcId))
                {
                    Console.WriteLine($"Missing: {NutrientAmountHeaders.FOOD_ID}");
                    continue;
                }

                // This is going to be slow.
                foreach (var ingredient in ingredientsWithFoodData[fdcId] ?? [])
                {
                    if (int.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.NUTRIENT_ID)], out int nutrientId)
                        && double.TryParse(rows?[actualHeaders.IndexOf(NutrientAmountHeaders.NUTRIENT_VALUE)], out double amount))
                    {
                        var nutrients2 = (CanadaNutrients)nutrientId;
                        var measure = nutrients2.GetMeasure() ?? Measure.None;
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
                            newNutrients.Add(new NutrientCanada()
                            {
                                Value = amount,
                                Measure = measure,
                                Nutrients = nutrients2,
                                IngredientId = ingredient.Id,
                                DataSource = DataSource.Canada,
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
