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
        [Nutrients.Proteins] = 100..200,
        [Nutrients.Starch] = 100..200,
        [Nutrients.Oligosaccharides] = 100..200,
        [Nutrients.SolubleFiber | Nutrients.InsolubleFiber] = 100..200,
        [Nutrients.MonounsaturatedFats | Nutrients.PolyunsaturatedFats | Nutrients.SaturatedFats] = 100..200,
        [Nutrients.Calcium] = 100..200,
        [Nutrients.Chloride] = 100..200,
        [Nutrients.Chromium] = 100..200,
        [Nutrients.Copper] = 100..200,
        [Nutrients.Fluoride] = 100..200,
        [Nutrients.Iodine] = 100..200,
        [Nutrients.Iron] = 100..200,
        [Nutrients.Lithium] = 100..200,
        [Nutrients.Magnesium] = 100..200,
        [Nutrients.Manganese] = 100..200,
        [Nutrients.Molybdenum] = 100..200,
        [Nutrients.Phosphorus] = 100..200,
        [Nutrients.Potassium] = 100..200,
        [Nutrients.Selenium] = 100..200,
        [Nutrients.Sodium] = 100..200,
        [Nutrients.Sulfur] = 100..200,
        [Nutrients.Boron] = 100..200,
        [Nutrients.Vanadium] = 100..200,
        [Nutrients.VitaminB1] = 100..200,
        [Nutrients.VitaminB2] = 100..200,
        [Nutrients.VitaminB3] = 100..200,
        [Nutrients.VitaminB5] = 100..200,
        [Nutrients.VitaminB6] = 100..200,
        [Nutrients.VitaminB7] = 100..200,
        [Nutrients.VitaminB9] = 100..200,
        [Nutrients.VitaminB12] = 100..200,
        [Nutrients.VitaminACartenoids] = 100..200,
        [Nutrients.VitaminARetinoids] = 100..200,
        [Nutrients.VitaminC] = 100..200,
        [Nutrients.VitaminD] = 100..200,
        [Nutrients.VitaminE] = 100..200,
        [Nutrients.VitaminK] = 100..200,
        [Nutrients.Zinc] = 100..200,
        [Nutrients.Choline] = 100..200,
        [Nutrients.Betaine] = 100..200,
        [Nutrients.Histidine] = 100..200,
        [Nutrients.Isoleucine] = 100..200,
        [Nutrients.Leucine] = 100..200,
        [Nutrients.Lysine] = 100..200,
        [Nutrients.Phenylalanine] = 100..200,
        [Nutrients.Threonine] = 100..200,
        [Nutrients.Tryptophan] = 100..200,
        [Nutrients.Valine] = 100..200,
        [Nutrients.Arginine] = 100..200,
        [Nutrients.Glycine] = 100..200,
        [Nutrients.Creatine] = 100..200,
        [Nutrients.Sugar] = 100..150,
        [Nutrients.TransFats] = 50..100,
    };
}
