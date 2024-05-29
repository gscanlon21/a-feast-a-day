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
        [Nutrients.Proteins] = 100..125,
        [Nutrients.Starch] = 100..125,
        [Nutrients.Sugar] = 100..125,
        [Nutrients.Oligosaccharides] = 100..125,
        [Nutrients.SolubleFiber | Nutrients.InsolubleFiber] = 100..125,
        [Nutrients.MonounsaturatedFats | Nutrients.PolyunsaturatedFats | Nutrients.SaturatedFats] = 100..125,
        [Nutrients.HDLCholesterol] = 100..125,
        [Nutrients.Calcium] = 100..125,
        [Nutrients.Chloride] = 100..125,
        [Nutrients.Chromium] = 100..125,
        [Nutrients.Copper] = 100..125,
        [Nutrients.Fluoride] = 100..125,
        [Nutrients.Iodine] = 100..125,
        [Nutrients.Iron] = 100..125,
        [Nutrients.Lithium] = 100..125,
        [Nutrients.Magnesium] = 100..125,
        [Nutrients.Manganese] = 100..125,
        [Nutrients.Molybdenum] = 100..125,
        [Nutrients.Phosphorus] = 100..125,
        [Nutrients.Potassium] = 100..125,
        [Nutrients.Selenium] = 100..125,
        [Nutrients.Sodium] = 100..125,
        [Nutrients.Sulfur] = 100..125,
        [Nutrients.B1] = 100..125,
        [Nutrients.B2] = 100..125,
        [Nutrients.B3] = 100..125,
        [Nutrients.B5] = 100..125,
        [Nutrients.B6] = 100..125,
        [Nutrients.B7] = 100..125,
        [Nutrients.B9] = 100..125,
        [Nutrients.B12] = 100..125,
        [Nutrients.VitaminACartenoids] = 100..125,
        [Nutrients.VitaminARetinoids] = 100..125,
        [Nutrients.VitaminC] = 100..125,
        [Nutrients.VitaminD] = 100..125,
        [Nutrients.VitaminE] = 100..125,
        [Nutrients.VitaminK] = 100..125,
        [Nutrients.Zinc] = 100..125,
        [Nutrients.Choline] = 100..125,
        [Nutrients.TransFats] = 75..100,
        [Nutrients.LDLCholesterol] = 75..100,
    };
}
