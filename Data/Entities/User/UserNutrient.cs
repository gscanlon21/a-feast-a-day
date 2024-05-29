using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_nutrient")]
public class UserNutrient
{
    public const int MuscleTargetMin = 0;

    public Nutrient Nutrient { get; init; }

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
    public static readonly IDictionary<Nutrient, Range> MuscleTargets = new Dictionary<Nutrient, Range>
    {
        [Nutrient.Proteins] = 4..8,
        [Nutrient.Starch] = 4..8,
        [Nutrient.Sugar] = 4..8,
        [Nutrient.Oligosaccharides] = 4..8,
        [Nutrient.SolubleFiber | Nutrient.InsolubleFiber] = 4..8,
        [Nutrient.MonounsaturatedFats | Nutrient.PolyunsaturatedFats | Nutrient.SaturatedFats] = 4..8,
        [Nutrient.Calcium] = 4..8,
        [Nutrient.Chloride] = 4..8,
        [Nutrient.Chromium] = 4..8,
        [Nutrient.Copper] = 4..8,
        [Nutrient.Fluoride] = 4..8,
        [Nutrient.Iodine] = 4..8,
        [Nutrient.Iron] = 4..8,
        [Nutrient.Magnesium] = 4..8,
        [Nutrient.Manganese] = 4..8,
        [Nutrient.Molybdenum] = 4..8,
        [Nutrient.Phosphorus] = 4..8,
        [Nutrient.Potassium] = 4..8,
        [Nutrient.Selenium] = 4..8,
        [Nutrient.Sodium] = 4..8,
        [Nutrient.Sulfur] = 4..8,
        [Nutrient.B1] = 4..8,
        [Nutrient.B2] = 4..8,
        [Nutrient.B3] = 4..8,
        [Nutrient.B5] = 4..8,
        [Nutrient.B6] = 4..8,
        [Nutrient.B7] = 4..8,
        [Nutrient.B9] = 4..8,
        [Nutrient.B12] = 4..8,
        [Nutrient.VitaminACartenoids] = 4..8,
        [Nutrient.VitaminARetinoids] = 4..8,
        [Nutrient.VitaminC] = 4..8,
        [Nutrient.VitaminD] = 4..8,
        [Nutrient.VitaminE] = 4..8,
        [Nutrient.VitaminK] = 4..8,
        [Nutrient.Zinc] = 4..8,
        [Nutrient.Choline] = 4..8,
        [Nutrient.TransFats] = 0..4,
    };
}
