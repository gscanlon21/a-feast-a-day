using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_nutrient")]
public class UserNutrient
{
    public const int MuscleTargetMin = 0;

    public Nutrients Nutrient { get; init; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredientGroups))]
    public virtual User User { get; private init; } = null!;

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);

    /// <summary>
    /// The volume each muscle group should be exposed to each week.
    /// </summary>
    public static readonly IDictionary<Nutrients, Range> MuscleTargets = new Dictionary<Nutrients, Range>
    {
        [Nutrients.Proteins] = 100..150,
        [Nutrients.Starch] = 100..150,
        [Nutrients.Sugar] = 100..150,
        [Nutrients.Oligosaccharides] = 100..150,
        [Nutrients.SolubleFiber | Nutrients.InsolubleFiber] = 100..150,
        [Nutrients.MonounsaturatedFats | Nutrients.PolyunsaturatedFats | Nutrients.SaturatedFats] = 100..150,
        [Nutrients.HDLCholesterol] = 100..150,
        [Nutrients.Calcium] = 100..150,
        [Nutrients.Chloride] = 100..150,
        [Nutrients.Chromium] = 100..150,
        [Nutrients.Copper] = 100..150,
        [Nutrients.Fluoride] = 100..150,
        [Nutrients.Iodine] = 100..150,
        [Nutrients.Iron] = 100..150,
        [Nutrients.Lithium] = 100..150,
        [Nutrients.Magnesium] = 100..150,
        [Nutrients.Manganese] = 100..150,
        [Nutrients.Molybdenum] = 100..150,
        [Nutrients.Phosphorus] = 100..150,
        [Nutrients.Potassium] = 100..150,
        [Nutrients.Selenium] = 100..150,
        [Nutrients.Sodium] = 100..150,
        [Nutrients.Sulfur] = 100..150,
        [Nutrients.B1] = 100..150,
        [Nutrients.B2] = 100..150,
        [Nutrients.B3] = 100..150,
        [Nutrients.B5] = 100..150,
        [Nutrients.B6] = 100..150,
        [Nutrients.B7] = 100..150,
        [Nutrients.B9] = 100..150,
        [Nutrients.B12] = 100..150,
        [Nutrients.VitaminACartenoids] = 100..150,
        [Nutrients.VitaminARetinoids] = 100..150,
        [Nutrients.VitaminC] = 100..150,
        [Nutrients.VitaminD] = 100..150,
        [Nutrients.VitaminE] = 100..150,
        [Nutrients.VitaminK] = 100..150,
        [Nutrients.Zinc] = 100..150,
        [Nutrients.Choline] = 100..150,
        [Nutrients.TransFats] = 50..100,
        [Nutrients.LDLCholesterol] = 50..100,
    };
}
