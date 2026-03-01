# Shouldn't have these hardcoded.
$inputPath = "../Data/FoodData_Central_foundation_food_csv_2025-12-18/nutrient.csv"
$outputPath = "../../Core/Models/User/Nutrients2.cs"

$measureMap = @{
    ""  = "None"
    "IU" = "IU"
    "PH" = "PH"
    "G" = "Grams"
    "kJ" = "KiloJoule"
    "KCAL" = "KCalorie"
    "UG" = "Micrograms"
    "MG" = "Milligrams"
    "MCG_RE" = "MCG_RE"
    "MG_GAE" = "MG_GAE"
    "MG_ATE" = "MG_ATE"
    "UMOL_TE" = "UMOL_TE"
    "SP_GR" = "SpecificGravity"
}

$builder = New-Object System.Text.StringBuilder

$builder.AppendLine("using Core.Code.Attributes;")
$builder.AppendLine("")
$builder.AppendLine("namespace Core.Models.User;")
$builder.AppendLine("")
$builder.AppendLine("public enum Nutrients2")
$builder.AppendLine("{")

$nutrients = Import-Csv $inputPath
foreach ($nutrient in $nutrients) {

    # Pretty-up the nutrient name for C#.
    $name = $nutrient.name -replace '[^a-zA-Z0-9_]', '_'
    $name = $name -replace '__', '_'
    $name = $name -replace '__+', '__'
    $name = $name.Trim('_')

    # Don't start name with a number.
    if ($name -match '^[0-9]') {
        $name = "_" + $name
    }
    
    # Map unit_name to Measure.
    $unitName = $nutrient.unit_name.Trim()
    if ($measureMap.ContainsKey($unitName)) {
        $measure = $measureMap[$unitName]
    }
    else {
        Write-Warning "Unknown unit_name '$unitName' for nutrient '$name'. Using Measure.None."
        $measure = "None"
    }

    $name = $name + "_" + $measure
    $rank = if ([string]::IsNullOrEmpty($nutrient.rank)) { -1 } else { [double]$nutrient.rank }
    $nutrientNumber = if ([string]::IsNullOrEmpty($nutrient.nutrient_nbr)) { -1 } else { [double]$nutrient.nutrient_nbr }

    $builder.AppendLine("    /// <summary>")
    $builder.AppendLine("    /// $($nutrient.name)")
    $builder.AppendLine("    /// </summary>")
    $builder.AppendLine("    [Nutrients2Metadata(Measure.$measure, $nutrientNumber, $rank)]")
    $builder.AppendLine("    $name = $($nutrient.id),")
    $builder.AppendLine()
}

$builder.AppendLine("}")

$builder.ToString() | Set-Content $outputPath -Encoding UTF8

Write-Host "Finished writing $outputPath"
Read-Host -Prompt "Press any key to exit"
