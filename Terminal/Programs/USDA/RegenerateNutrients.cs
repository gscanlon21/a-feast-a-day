using Core.Code.Attributes;
using Data.Repos;
using Microsoft.VisualBasic.FileIO;
using Terminal.Code.Helpers;
using Terminal.Models.USDA;

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

            var id = (row.TryGetValue(NutrientHeaders.ID, out string? idTemp) ? idTemp?.Trim() : null) ?? throw new Exception("Missing id!");
            var origName = (row.TryGetValue(NutrientHeaders.NAME, out string? nameTemp) ? nameTemp?.Trim() : null) ?? throw new Exception("Missing name!");
            var unitName = (row.TryGetValue(NutrientHeaders.UNIT_NAME, out string? unitNameTemp) ? unitNameTemp?.Trim() : null) ?? throw new Exception("Missing unit_name!");
            var nutrientNumber = (row.TryGetValue(NutrientHeaders.NUTRIENT_NBR, out string? nutrientNumberTemp) ? nutrientNumberTemp?.Trim().NullIfEmpty() : null) ?? "-1";
            var rank = (row.TryGetValue(NutrientHeaders.RANK, out string? rankTemp) ? rankTemp?.Trim().NullIfEmpty() : null) ?? "-1";

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
            if (!MeasureMap.Map.TryGetValue(unitName, out var measure))
            {
                Console.WriteLine($"Warning: Unknown unit_name '{unitName}' for nutrient '{name}'. Using Measure.None.");
                measure = "None";
            }

            name = name + "_" + measure;

            builder.AppendLine();
            builder.AppendLine($"    /// <summary>");
            builder.AppendLine($"    /// {origName}");
            builder.AppendLine($"    /// </summary>");
            builder.AppendLine($"    [{USDANutrientsMetadataAttribute.Name}(Measure.{measure}, {nutrientNumber}, {rank})]");
            builder.AppendLine($"    [Display(Name = \"{origName}\")]");
            builder.AppendLine($"    {name} = {id},");
        }

        builder.AppendLine("}");

        File.WriteAllText(outputPath, builder.ToString(), Encoding.UTF8);

        Console.WriteLine($"Finished writing {outputPath}");
        return Response.Success();
    }
}
