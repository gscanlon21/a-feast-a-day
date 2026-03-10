using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum Nutrients
{
    None = 0,

    /// <summary>
    /// Energy Atwater General Factors KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy Atwater General Factors KCalorie", Order = 280)]
    Energy_Atwater_General_Factors_KCalorie = 1,

    /// <summary>
    /// Energy Atwater Specific Factors KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy Atwater Specific Factors KCalorie", Order = 290)]
    Energy_Atwater_Specific_Factors_KCalorie = 2,

    /// <summary>
    /// Calories
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Calories", Order = 300)]
    Calories = 3,

    /// <summary>
    /// Energy KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy KCalorie", Order = 300)]
    Energy_KCalorie = 4,

    /// <summary>
    /// Protein
    /// </summary>
    [DailyAllowance(0.85, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Male_14_18_Years)]
    [DailyAllowance(0.85, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Female_14_18_Years)]
    [DailyAllowance(1.1, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(1.3, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(0.8, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.8, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(0.8, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.8, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(1.3, -1, Measure.Grams, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 4, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Protein", Order = 600)]
    Protein = 5,

    /// <summary>
    /// Fats
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fats", Order = 800)]
    Fats = 6,

    /// <summary>
    /// Total lipid fat
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Total lipid fat", Order = 800)]
    Total_lipid_fat = 7,

    /// <summary>
    /// Carbohydrate by difference
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrate by difference", Order = 1110)]
    Carbohydrate_by_difference = 8,

    /// <summary>
    /// Carbohydrates
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrates", Order = 1110)]
    Carbohydrates = 9,

    /// <summary>
    /// Carbohydrate by summation
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrate by summation", Order = 1120)]
    Carbohydrate_by_summation = 10,

    /// <summary>
    /// Fiber total dietary
    /// </summary>
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber total dietary", Order = 1200)]
    Fiber_total_dietary = 11,

    /// <summary>
    /// Fiber soluble
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber soluble", Order = 1240)]
    Fiber_soluble = 12,

    /// <summary>
    /// Fiber insoluble
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber insoluble", Order = 1260)]
    Fiber_insoluble = 13,

    /// <summary>
    /// Sugars Total
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Sugars Total", Order = 1500)]
    Sugars_Total = 14,

    /// <summary>
    /// Total Sugars
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Total Sugars", Order = 1510)]
    Total_Sugars = 15,

    /// <summary>
    /// Starch
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Starch", Order = 2200)]
    Starch = 16,

    /// <summary>
    /// Resistant starch
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Resistant starch", Order = 2225)]
    Resistant_starch = 17,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Oligosaccharides", Order = 2250)]
    Oligosaccharides = 18,

    /// <summary>
    /// Sodium Na
    /// </summary>
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Sodium Na", Order = 5100)]
    Sodium_Na = 19,

    /// <summary>
    /// Magnesium Mg
    /// </summary>
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Magnesium Mg", Order = 5300)]
    Magnesium_Mg = 20,

    /// <summary>
    /// Iodine I
    /// </summary>
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Iodine I", Order = 5350)]
    Iodine_I = 21,

    /// <summary>
    /// Calcium Ca
    /// </summary>
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Calcium Ca", Order = 5400)]
    Calcium_Ca = 22,

    /// <summary>
    /// Phosphorus P
    /// </summary>
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Phosphorus P", Order = 5500)]
    Phosphorus_P = 23,

    /// <summary>
    /// Copper Cu
    /// </summary>
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Copper Cu", Order = 5550)]
    Copper_Cu = 24,

    /// <summary>
    /// Manganese Mn
    /// </summary>
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Manganese Mn", Order = 5600)]
    Manganese_Mn = 25,

    /// <summary>
    /// Molybdenum Mo
    /// </summary>
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Molybdenum Mo", Order = 5650)]
    Molybdenum_Mo = 26,

    /// <summary>
    /// Fluoride F
    /// </summary>
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Fluoride F", Order = 5680)]
    Fluoride_F = 27,

    /// <summary>
    /// Potassium K
    /// </summary>
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Potassium K", Order = 5700)]
    Potassium_K = 28,

    /// <summary>
    /// Iron Fe
    /// </summary>
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Iron Fe", Order = 5800)]
    Iron_Fe = 29,

    /// <summary>
    /// Zinc Zn
    /// </summary>
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Zinc Zn", Order = 5900)]
    Zinc_Zn = 30,

    /// <summary>
    /// Selenium Se
    /// </summary>
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Selenium Se", Order = 6200)]
    Selenium_Se = 31,

    /// <summary>
    /// Boron B
    /// </summary>
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Boron B", Order = 6245)]
    Boron_B = 32,

    /// <summary>
    /// Thiamin
    /// </summary>
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Thiamin", Order = 6300)]
    Thiamin = 33,

    /// <summary>
    /// Vitamin C total ascorbic acid
    /// </summary>
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin C total ascorbic acid", Order = 6300)]
    Vitamin_C_total_ascorbic_acid = 34,

    /// <summary>
    /// Riboflavin
    /// </summary>
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Riboflavin", Order = 6500)]
    Riboflavin = 35,

    /// <summary>
    /// Niacin
    /// </summary>
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Niacin", Order = 6600)]
    Niacin = 36,

    /// <summary>
    /// Vitamin B 6
    /// </summary>
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin B 6", Order = 6700)]
    Vitamin_B_6 = 37,

    /// <summary>
    /// Vitamin B 12
    /// </summary>
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_14_18_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_14_18_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Vitamin B 12", Order = 6800)]
    Vitamin_B_12 = 38,

    /// <summary>
    /// Biotin
    /// </summary>
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Biotin", Order = 6850)]
    Biotin = 39,

    /// <summary>
    /// Folate total
    /// </summary>
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Folate total", Order = 6900)]
    Folate_total = 40,

    /// <summary>
    /// Pantothenic acid
    /// </summary>
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Pantothenic acid", Order = 6900)]
    Pantothenic_acid = 41,

    /// <summary>
    /// Retinol
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Retinol", Order = 7410)]
    Retinol = 42,

    /// <summary>
    /// Vitamin A
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin A", Order = 7420)]
    Vitamin_A = 43,

    /// <summary>
    /// Vitamin A RAE
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin A RAE", Order = 7420)]
    Vitamin_A_RAE = 44,

    /// <summary>
    /// Carotene alpha
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene alpha", Order = 7440)]
    Carotene_alpha = 45,

    /// <summary>
    /// Carotene beta
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene beta", Order = 7450)]
    Carotene_beta = 46,

    /// <summary>
    /// Lutein/Zeaxanthin
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lutein/Zeaxanthin", Order = 7560)]
    Lutein_Zeaxanthin = 47,

    /// <summary>
    /// Carotene MCG RE
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene MCG RE", Order = 7600)]
    Carotene_MCG_RE = 48,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E", Order = 7810)]
    Vitamin_E = 49,

    /// <summary>
    /// Vitamin E alpha tocopherol
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E alpha tocopherol", Order = 7905)]
    Vitamin_E_alpha_tocopherol = 50,

    /// <summary>
    /// Vitamin E MG ATE
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E MG ATE", Order = 7905)]
    Vitamin_E_MG_ATE = 51,

    /// <summary>
    /// Vitamin D D2  D3
    /// </summary>
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin D D2  D3", Order = 8700)]
    Vitamin_D_D2__D3 = 52,

    /// <summary>
    /// Vitamin K phylloquinone
    /// </summary>
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin K phylloquinone", Order = 8800)]
    Vitamin_K_phylloquinone = 53,

    /// <summary>
    /// Fatty acids total saturated
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_0_6_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_0_6_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_7_12_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_7_12_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_1_2_Years)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_1_2_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_2_3_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_2_3_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_4_8_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_4_8_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_9_13_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_9_13_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_14_18_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_14_18_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_51_70_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_51_70_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_71_XX_Years)]
    [DailyAllowance(-1, 3, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_71_XX_Years)]
    [Display(Name = "Fatty acids total saturated", Order = 9700)]
    Fatty_acids_total_saturated = 54,

    /// <summary>
    /// Fatty acids total monounsaturated
    /// </summary>
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total monounsaturated", Order = 11400)]
    Fatty_acids_total_monounsaturated = 55,

    /// <summary>
    /// Choline total
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Choline total", Order = 11800)]
    Choline_total = 56,

    /// <summary>
    /// Fatty acids total polyunsaturated
    /// </summary>
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total polyunsaturated", Order = 12900)]
    Fatty_acids_total_polyunsaturated = 57,

    /// <summary>
    /// Omega 3 Fatty Acids
    /// </summary>
    [Display(Name = "Omega 3 Fatty Acids", Order = 14000)]
    Omega_3 = 58,

    /// <summary>
    /// Omega 3 (ALA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (ALA) Fatty Acids", Order = 14000)]
    Omega_3_ALA = 59,

    /// <summary>
    /// Omega 3 (EPA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (EPA) Fatty Acids", Order = 15000)]
    Omega_3_EPA = 60,

    /// <summary>
    /// Omega 3 (EPA/DHA) Fatty Acids
    /// </summary>
    [DailyAllowance(-1, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (EPA/DHA) Fatty Acids", Order = 15000)]
    Omega_3_EPA_DHA = 61,

    /// <summary>
    /// Omega 6 Fatty Acids
    /// </summary>
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 6 Fatty Acids", Order = 15005)]
    Omega_6 = 62,

    /// <summary>
    /// Omega 6 (LA) Fatty Acids
    /// </summary>
    [Display(Name = "Omega 6 (LA) Fatty Acids", Order = 15010)]
    Omega_6_LA = 63,

    /// <summary>
    /// Omega 3 (DHA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (DHA) Fatty Acids", Order = 15300)]
    Omega_3_DHA = 64,

    /// <summary>
    /// Fatty acids total trans
    /// </summary>
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total trans", Order = 15400)]
    Fatty_acids_total_trans = 65,

    /// <summary>
    /// Cholesterol
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Cholesterol", Order = 15700)]
    Cholesterol = 66,

    /// <summary>
    /// Tryptophan
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Tryptophan", Order = 16300)]
    Tryptophan = 67,

    /// <summary>
    /// Arginine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Arginine", Order = 16700)]
    Arginine = 68,

    /// <summary>
    /// Lysine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lysine", Order = 16800)]
    Lysine = 69,

    /// <summary>
    /// Methionine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Methionine", Order = 16900)]
    Methionine = 70,

    /// <summary>
    /// Leucine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Leucine", Order = 17000)]
    Leucine = 71,

    /// <summary>
    /// Isoleucine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Isoleucine", Order = 17100)]
    Isoleucine = 72,

    /// <summary>
    /// Valine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Valine", Order = 17200)]
    Valine = 73,

    /// <summary>
    /// Phenylalanine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Phenylalanine", Order = 17300)]
    Phenylalanine = 74,

    /// <summary>
    /// Histidine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Histidine", Order = 17400)]
    Histidine = 75,

    /// <summary>
    /// Threonine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Threonine", Order = 17500)]
    Threonine = 76,

    /// <summary>
    /// Glycine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Glycine", Order = 17600)]
    Glycine = 77,

    /// <summary>
    /// Betaine
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Betaine", Order = 999999)]
    Betaine = 78,

    /// <summary>
    /// Chlorine Cl
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chlorine Cl", Order = 999999)]
    Chlorine_Cl = 79,

    /// <summary>
    /// Chromium Cr
    /// </summary>
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chromium Cr", Order = 999999)]
    Chromium_Cr = 80,

    /// <summary>
    /// Flavonoids total
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Flavonoids total", Order = 999999)]
    Flavonoids_total = 81,

    /// <summary>
    /// Lithium Li
    /// </summary>
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lithium Li", Order = 999999)]
    Lithium_Li = 82,

    /// <summary>
    /// Polyphenols total
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Polyphenols total", Order = 999999)]
    Polyphenols_total = 83,

    /// <summary>
    /// Vanadium V
    /// </summary>
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vanadium V", Order = 999999)]
    Vanadium_V = 84,
}
