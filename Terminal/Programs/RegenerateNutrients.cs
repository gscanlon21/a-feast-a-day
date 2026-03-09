using Data.Repos;

namespace Terminal.Programs.USDA;

internal class RegenerateNutrients
{
    private readonly NutrientRepo _nutrientRepo;

    public RegenerateNutrients(NutrientRepo nutrientRepo)
    {
        _nutrientRepo = nutrientRepo;
    }

    public async Task<Response> Execute()
    {
        // Shouldn't have these hardcoded.
        var outputPath = "C:/code/afeastaday/Core/Models/Nutrients/Nutrients.cs";

        var dailyAllowanceMap = await _nutrientRepo.GetDietaryIntakeMap();
        var builder = new StringBuilder();

        builder.AppendLine("using Core.Code.Attributes;");
        builder.AppendLine("using System.ComponentModel.DataAnnotations;");
        builder.AppendLine();
        builder.AppendLine("namespace Core.Models.Nutrients;");
        builder.AppendLine();
        builder.AppendLine("public enum Nutrients");
        builder.AppendLine("{");
        builder.AppendLine("    None = 0,");

        int i = 0;
        foreach (var dailyAllowanceGroup in dailyAllowanceMap)
        {
            builder.AppendLine();
            builder.AppendLine($"    /// <summary>");
            builder.AppendLine($"    /// {dailyAllowanceGroup.Key}");
            builder.AppendLine($"    /// </summary>");

            foreach (var dailyAllowance in dailyAllowanceGroup)
            {
                builder.AppendLine($"    [DailyAllowance({dailyAllowance.Min}, {dailyAllowance.Max}, Measure.{dailyAllowance.Measure}, Multiplier.{dailyAllowance.Multiplier}, CaloriesPerGram = {dailyAllowance.CaloriesPerGram}, For = Person.{dailyAllowance.Person})]");
            }

            //builder.AppendLine($"    [{NutrientsMetadataAttribute.Name}(Measure.{dailyAllowance}, {nutrientNumber}, {rank})]");
            builder.AppendLine($"    [Display(Name = \"{dailyAllowanceGroup.Key}\")]");
            builder.AppendLine($"    {dailyAllowanceGroup.Key} = {++i},");
        }

        builder.AppendLine("}");

        File.WriteAllText(outputPath, builder.ToString(), Encoding.UTF8);

        Console.WriteLine($"Finished writing {outputPath}");
        return Response.Success();
    }
}
