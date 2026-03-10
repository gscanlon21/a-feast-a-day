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
        foreach (var dailyAllowanceGroup in dailyAllowanceMap.OrderBy(g => g.Key.Order).ThenBy(g => g.Key.Key))
        {
            builder.AppendLine();
            builder.AppendLine($"    /// <summary>");
            builder.AppendLine($"    /// {dailyAllowanceGroup.Key.Key}");
            builder.AppendLine($"    /// </summary>");

            foreach (var dailyAllowance in dailyAllowanceGroup.Value)
            {
                builder.AppendLine($"    [DailyAllowance({dailyAllowance.Min ?? -1}, {dailyAllowance.Max ?? -1}, Measure.{dailyAllowance.Measure}, Multiplier.{dailyAllowance.Multiplier}, CaloriesPerGram = {dailyAllowance.CaloriesPerGram}, For = Person.{dailyAllowance.Person})]");
            }

            var enumName = new string(dailyAllowanceGroup.Key.Key.Select(c => char.IsLetterOrDigit(c) ? c : '_').ToArray());
            builder.AppendLine($"    [Display(Name = \"{dailyAllowanceGroup.Key.Key}\", Order = {dailyAllowanceGroup.Key.Order})]");
            builder.AppendLine($"    {enumName} = {++i},");
        }

        builder.AppendLine("}");

        File.WriteAllText(outputPath, builder.ToString(), Encoding.UTF8);

        Console.WriteLine($"Finished writing {outputPath}");
        return Response.Success();
    }
}
