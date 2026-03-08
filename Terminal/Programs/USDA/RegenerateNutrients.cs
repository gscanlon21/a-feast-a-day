using Data.Repos;
using Microsoft.VisualBasic.FileIO;

namespace Terminal.Programs.USDA;

internal class RegenerateUSDANutrients
{
    private readonly NutrientRepo _nutrientRepo;

    public RegenerateUSDANutrients(NutrientRepo nutrientRepo)
    {
        _nutrientRepo = nutrientRepo;
    }

    public async Task<Response> Execute()
    {
        // Shouldn't have these hardcoded.
        Console.WriteLine("What is the path to nutrient.csv?");
        ShortTermMemory.Nutrient_csv ??= Console.ReadLine() ?? throw new Exception("Missing nutrient.csv!");
        var outputPath = "C:/code/afeastaday/Core/Models/Nutrients/USDANutrients.cs";

        var dailyAllowanceMap = await _nutrientRepo.GetDietaryIntakeMap();
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
        builder.AppendLine("public enum USDANutrients");
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

            var id = (row.TryGetValue("id", out string? idTemp) ? idTemp?.Trim() : null) ?? throw new Exception("Missing id!");
            var origName = (row.TryGetValue("name", out string? nameTemp) ? nameTemp?.Trim() : null) ?? throw new Exception("Missing name!");
            var unitName = (row.TryGetValue("unit_name", out string? unitNameTemp) ? unitNameTemp?.Trim() : null) ?? throw new Exception("Missing unit_name!");
            var nutrientNumber = (row.TryGetValue("nutrient_nbr", out string? nutrientNumberTemp) ? nutrientNumberTemp?.Trim().NullIfEmpty() : null) ?? "-1";
            var rank = (row.TryGetValue("rank", out string? rankTemp) ? rankTemp?.Trim().NullIfEmpty() : null) ?? "-1";

            // Pretty-up the nutrient name for C#.
            var name = new string(origName.Select(c => char.IsLetterOrDigit(c) ? c : '_').ToArray());
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

            builder.AppendLine();
            builder.AppendLine($"    /// <summary>");
            builder.AppendLine($"    /// {origName}");
            builder.AppendLine($"    /// </summary>");

            foreach (var dailyAllowance in dailyAllowanceMap.Where(kvp => name.Equals(kvp.Key, StringComparison.OrdinalIgnoreCase)).SelectMany(kv => kv))
            {
                builder.AppendLine($"    [DailyAllowance({dailyAllowance.Min}, {dailyAllowance.Max}, Measure.{dailyAllowance.Measure}, Multiplier.{dailyAllowance.Multiplier}, CaloriesPerGram = {dailyAllowance.CaloriesPerGram}, For = Person.{dailyAllowance.Person})]");
            }

            builder.AppendLine($"    [NutrientsMetadata(Measure.{measure}, {nutrientNumber}, {rank})]");
            builder.AppendLine($"    [Display(Name = \"{origName}\")]");
            builder.AppendLine($"    {name} = {id},");
        }

        builder.AppendLine("}");

        File.WriteAllText(outputPath, builder.ToString(), Encoding.UTF8);

        Console.WriteLine($"Finished writing {outputPath}");
        return Response.Success();
    }
}
