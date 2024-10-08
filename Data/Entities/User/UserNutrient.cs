﻿using Core.Models.User;
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

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserNutrients))]
    public virtual User User { get; private init; } = null!;

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);

    /// <summary>
    /// The volume each nutrient should be consumed each week.
    /// </summary>
    public static readonly IDictionary<Nutrients, Range> NutrientTargets = new Dictionary<Nutrients, Range>
    {
        // TODO move these into the DailyAllowance attribute.
        [Nutrients.Vanadium] = 100..400,
        [Nutrients.Lithium] = 100..300,
        [Nutrients.Proteins] = 100..200,
        [Nutrients.Carbohydrates] = 100..200,
        [Nutrients.NetCarbohydrates] = 100..200,
        [Nutrients.Starch] = 100..200,
        [Nutrients.Oligosaccharides] = 100..200,
        [Nutrients.SolubleFiber] = 100..200,
        [Nutrients.InsolubleFiber] = 100..200,
        [Nutrients.DietaryFiber] = 100..200,
        [Nutrients.Calcium] = 100..200,
        [Nutrients.Chloride] = 100..200,
        [Nutrients.Chromium] = 100..200,
        [Nutrients.Copper] = 100..200,
        [Nutrients.Fluoride] = 100..200,
        [Nutrients.Iodine] = 100..200,
        [Nutrients.Magnesium] = 100..200,
        [Nutrients.Manganese] = 100..200,
        [Nutrients.Molybdenum] = 100..200,
        [Nutrients.Phosphorus] = 100..200,
        [Nutrients.Potassium] = 100..200,
        [Nutrients.Selenium] = 100..200,
        [Nutrients.Sulfur] = 100..200,
        [Nutrients.Boron] = 100..200,
        [Nutrients.VitaminB1] = 100..200,
        [Nutrients.VitaminB2] = 100..200,
        [Nutrients.VitaminB3] = 100..200,
        [Nutrients.VitaminB5] = 100..200,
        [Nutrients.VitaminB6] = 100..200,
        [Nutrients.VitaminB7] = 100..200,
        [Nutrients.VitaminB9] = 100..200,
        [Nutrients.VitaminB12] = 100..200,
        [Nutrients.VitaminA] = 100..200,
        [Nutrients.VitaminC] = 100..200,
        [Nutrients.NonProvitaminACarotenoids] = 100..200,
        [Nutrients.AlphaCarotene] = 100..200,
        [Nutrients.BetaCarotene] = 100..200,
        [Nutrients.ProvitaminACarotenoids] = 100..200,
        [Nutrients.Carotenoids] = 100..200,
        [Nutrients.Flavanoids] = 100..200,
        [Nutrients.NonFlavanoids] = 100..200,
        [Nutrients.Polyphenols] = 100..200,
        [Nutrients.Retinol] = 100..200,
        [Nutrients.VitaminD2] = 100..200,
        [Nutrients.VitaminD3] = 100..200,
        [Nutrients.VitaminD] = 100..200,
        [Nutrients.VitaminE] = 100..200,
        [Nutrients.VitaminK1] = 100..200,
        [Nutrients.VitaminK2] = 100..200,
        [Nutrients.VitaminK] = 100..200,
        [Nutrients.Zinc] = 100..200,
        [Nutrients.Choline] = 100..200,
        [Nutrients.Betaine] = 100..200,
        [Nutrients.Histidine] = 100..200,
        [Nutrients.Isoleucine] = 100..200,
        [Nutrients.Leucine] = 100..200,
        [Nutrients.Lysine] = 100..200,
        [Nutrients.Phenylalanine] = 100..200,
        [Nutrients.Methionine] = 100..200,
        [Nutrients.Threonine] = 100..200,
        [Nutrients.Tryptophan] = 100..200,
        [Nutrients.Valine] = 100..200,
        [Nutrients.Arginine] = 100..200,
        [Nutrients.Glycine] = 100..200,
        [Nutrients.Iron] = 100..200,
        [Nutrients.Calories] = 100..150,
        [Nutrients.Fats] = 100..140,
        [Nutrients.Sodium] = 80..120,
        [Nutrients.Sugar] = 80..120,
        [Nutrients.MonounsaturatedFats] = 0..100,
        [Nutrients.Omega3] = 0..100,
        [Nutrients.Omega6] = 0..100,
        [Nutrients.PolyunsaturatedFats] = 0..100,
        [Nutrients.UnsaturatedFats] = 0..100,
        [Nutrients.SaturatedFats] = 0..100,
        [Nutrients.TransFats] = 0..100,

        // No RDA or TUL.
        //[Nutrients.DietaryCholesterol] = 0..100,
    };
}
