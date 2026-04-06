using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum Nutrients
{
    None = 0,

    /// <summary>
    /// Calories
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Calories", Order = 300)]
    Energy_KCalorie = 1,

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
    Protein = 2,

    /// <summary>
    /// Fats
    /// </summary>
    [DailyAllowance(30, 40, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_1_2_Years)]
    [DailyAllowance(30, 40, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_1_2_Years)]
    [DailyAllowance(30, 40, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_2_3_Years)]
    [DailyAllowance(30, 40, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_2_3_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_4_8_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_4_8_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_9_13_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_9_13_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_14_18_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_14_18_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_51_70_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_51_70_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_71_XX_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_71_XX_Years)]
    [Display(Name = "Fats", Order = 800)]
    Fats = 3,

    /// <summary>
    /// Fats
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fats", Order = 800)]
    Total_lipid_fat = 4,

    /// <summary>
    /// Carbohydrates
    /// </summary>
    [DailyAllowance(60, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_0_6_Months)]
    [DailyAllowance(60, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_0_6_Months)]
    [DailyAllowance(95, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_7_12_Months)]
    [DailyAllowance(95, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_7_12_Months)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_1_2_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_1_2_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_2_3_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_2_3_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_4_8_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_4_8_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_9_13_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_9_13_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_14_18_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_14_18_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(210, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(210, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(210, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_51_70_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_51_70_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_71_XX_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_71_XX_Years)]
    [Display(Name = "Carbohydrates", Order = 1110)]
    Carbohydrates = 5,

    /// <summary>
    /// Dietary Fiber
    /// </summary>
    [DailyAllowance(28, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(29, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(28, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(29, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [DailyAllowance(28, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(29, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Dietary Fiber", Order = 1200)]
    Fiber_Total_Dietary = 6,

    /// <summary>
    /// Soluble Fiber
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Soluble Fiber", Order = 1240)]
    Fiber_soluble = 7,

    /// <summary>
    /// Insoluble Fiber
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Insoluble Fiber", Order = 1260)]
    Fiber_insoluble = 8,

    /// <summary>
    /// Total Sugars
    /// </summary>
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Total Sugars", Order = 1500)]
    Total_Sugars = 9,

    /// <summary>
    /// Added Sugars
    /// </summary>
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 25, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Added Sugars", Order = 1510)]
    Sugars_Added = 10,

    /// <summary>
    /// Starch
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Starch", Order = 2200)]
    Starch = 11,

    /// <summary>
    /// Resistant Starch
    /// </summary>
    [DailyAllowance(6, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2.5, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2.5, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2.5, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, -1, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2.5, For = Person.Female_31_50_Years)]
    [Display(Name = "Resistant Starch", Order = 2225)]
    Resistant_Starch = 12,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [DailyAllowance(4, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2, For = Person.Male_19_30_Years)]
    [DailyAllowance(4, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2, For = Person.Female_19_30_Years)]
    [DailyAllowance(4, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2, For = Person.Male_31_50_Years)]
    [DailyAllowance(4, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 2, For = Person.Female_31_50_Years)]
    [Display(Name = "Oligosaccharides", Order = 2250)]
    Oligosaccharides = 13,

    /// <summary>
    /// Sodium (Na)
    /// </summary>
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Sodium (Na)", Order = 5100)]
    Sodium_Na = 14,

    /// <summary>
    /// Magnesium (Mg)
    /// </summary>
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Magnesium (Mg)", Order = 5300)]
    Magnesium_Mg = 15,

    /// <summary>
    /// Iodine (I)
    /// </summary>
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Iodine (I)", Order = 5350)]
    Iodine_I = 16,

    /// <summary>
    /// Calcium (Ca)
    /// </summary>
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Calcium (Ca)", Order = 5400)]
    Calcium_Ca = 17,

    /// <summary>
    /// Phosphorus (P)
    /// </summary>
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(700, 4000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(700, 3000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(700, 3000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Phosphorus (P)", Order = 5500)]
    Phosphorus_P = 18,

    /// <summary>
    /// Copper (Cu)
    /// </summary>
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Copper (Cu)", Order = 5550)]
    Copper_Cu = 19,

    /// <summary>
    /// Manganese (Mn)
    /// </summary>
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Manganese (Mn)", Order = 5600)]
    Manganese_Mn = 20,

    /// <summary>
    /// Molybdenum (Mo)
    /// </summary>
    [DailyAllowance(45, 2000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(45, 2000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(45, 2000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(45, 2000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Molybdenum (Mo)", Order = 5650)]
    Molybdenum_Mo = 21,

    /// <summary>
    /// Fluoride (F)
    /// </summary>
    [DailyAllowance(4, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(3, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(4, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(3, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Fluoride (F)", Order = 5680)]
    Fluoride_F = 22,

    /// <summary>
    /// Potassium (K)
    /// </summary>
    [DailyAllowance(2500, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2800, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(2800, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Potassium (K)", Order = 5700)]
    Potassium_K = 23,

    /// <summary>
    /// Iron (Fe)
    /// </summary>
    [DailyAllowance(8, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_9_13_Years)]
    [DailyAllowance(8, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_9_13_Years)]
    [DailyAllowance(11, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_14_18_Years)]
    [DailyAllowance(15, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_14_18_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Iron (Fe)", Order = 5800)]
    Iron_Fe = 24,

    /// <summary>
    /// Zinc (Zn)
    /// </summary>
    [DailyAllowance(11, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(8, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(11, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(8, 40, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Zinc (Zn)", Order = 5900)]
    Zinc_Zn = 25,

    /// <summary>
    /// Selenium (Se)
    /// </summary>
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Selenium (Se)", Order = 6200)]
    Selenium_Se = 26,

    /// <summary>
    /// Boron (B)
    /// </summary>
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Boron (B)", Order = 6245)]
    Boron_B = 27,

    /// <summary>
    /// Thiamin (B1)
    /// </summary>
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Thiamin (B1)", Order = 6300)]
    Thiamin_B1 = 28,

    /// <summary>
    /// Vitamin C
    /// </summary>
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vitamin C", Order = 6300)]
    Vitamin_C = 29,

    /// <summary>
    /// Riboflavin (B2)
    /// </summary>
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Riboflavin (B2)", Order = 6500)]
    Riboflavin_B2 = 30,

    /// <summary>
    /// Niacin (B3)
    /// </summary>
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Niacin (B3)", Order = 6600)]
    Niacin_B3 = 31,

    /// <summary>
    /// Vitamin B6
    /// </summary>
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(1.7, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(1.5, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(1.7, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(1.5, 100, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vitamin B6", Order = 6700)]
    Vitamin_B_6 = 32,

    /// <summary>
    /// Vitamin B12
    /// </summary>
    [DailyAllowance(1.8, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_9_13_Years)]
    [DailyAllowance(1.8, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_9_13_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_14_18_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_14_18_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(2.6, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(2.8, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vitamin B12", Order = 6800)]
    Vitamin_B_12 = 33,

    /// <summary>
    /// Biotin (B7)
    /// </summary>
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Biotin (B7)", Order = 6850)]
    Biotin = 34,

    /// <summary>
    /// Folate (B9)
    /// </summary>
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Folate (B9)", Order = 6900)]
    Folate_B9 = 35,

    /// <summary>
    /// Pantothenic Acid (B5)
    /// </summary>
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Pantothenic Acid (B5)", Order = 6900)]
    Pantothenic_Acid_B5 = 36,

    /// <summary>
    /// Choline
    /// </summary>
    [DailyAllowance(550, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(425, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(450, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(550, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(550, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(425, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(450, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(550, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Lactating_31_50_Years)]
    [Display(Name = "Choline", Order = 7220)]
    Choline = 37,

    /// <summary>
    /// Retinol
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Retinol", Order = 7410)]
    Retinol = 38,

    /// <summary>
    /// Vitamin A
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin A", Order = 7420)]
    Vitamin_A = 39,

    /// <summary>
    /// Alpha Carotene
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Alpha Carotene", Order = 7440)]
    Carotene_Alpha = 40,

    /// <summary>
    /// Beta Carotene
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Beta Carotene", Order = 7450)]
    Carotene_Beta = 41,

    /// <summary>
    /// Lutein/Zeaxanthin
    /// </summary>
    [DailyAllowance(1.2, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.2, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, 20, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lutein/Zeaxanthin", Order = 7560)]
    Lutein_Zeaxanthin = 42,

    /// <summary>
    /// Carotenes
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotenes", Order = 7600)]
    Carotene_RAE = 43,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(15, 1000, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vitamin E", Order = 7810)]
    Vitamin_E = 44,

    /// <summary>
    /// Vitamin D
    /// </summary>
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin D", Order = 8700)]
    Vitamin_D_D2__D3 = 45,

    /// <summary>
    /// Vitamin K
    /// </summary>
    [DailyAllowance(120, 1200, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(90, 900, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(120, 1200, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(90, 900, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(120, 1200, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(90, 900, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(120, 1200, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(90, 900, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vitamin K", Order = 8800)]
    Vitamin_K = 46,

    /// <summary>
    /// Saturated Fats
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_0_6_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_0_6_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_7_12_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_7_12_Months)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_1_2_Years)]
    [DailyAllowance(-1, -1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_1_2_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_2_3_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_2_3_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_4_8_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_4_8_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_9_13_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_9_13_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_14_18_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_14_18_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_51_70_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_51_70_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_71_XX_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_71_XX_Years)]
    [Display(Name = "Saturated Fats", Order = 9700)]
    Fatty_acids_total_saturated = 47,

    /// <summary>
    /// Monounsaturated Fats
    /// </summary>
    [DailyAllowance(-1, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 35, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Monounsaturated Fats", Order = 11400)]
    Fatty_acids_total_monounsaturated = 48,

    /// <summary>
    /// Polyunsaturated Fats
    /// </summary>
    [DailyAllowance(5.6, 11.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(5.6, 11.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(5.6, 11.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(5.6, 11.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Polyunsaturated Fats", Order = 12900)]
    Fatty_acids_total_polyunsaturated = 49,

    /// <summary>
    /// Omega 3 Fatty Acids
    /// </summary>
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 Fatty Acids", Order = 14000)]
    Omega_3 = 50,

    /// <summary>
    /// Omega 3 (ALA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.6, 1.2, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (ALA) Fatty Acids", Order = 14000)]
    Omega_3_ALA = 51,

    /// <summary>
    /// Omega 3 (EPA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (EPA) Fatty Acids", Order = 15000)]
    Omega_3_EPA = 52,

    /// <summary>
    /// Omega 3 (EPA/DHA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_1_2_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_1_2_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_2_3_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_2_3_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_4_8_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_4_8_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_9_13_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_9_13_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_14_18_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_14_18_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_14_18_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_14_18_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Pregnant_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Lactating_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_51_70_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_51_70_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_71_XX_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_71_XX_Years)]
    [Display(Name = "Omega 3 (EPA/DHA) Fatty Acids", Order = 15000)]
    Omega_3_EPA_DHA = 53,

    /// <summary>
    /// Omega 6 Fatty Acids
    /// </summary>
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Omega 6 Fatty Acids", Order = 15005)]
    Omega_6 = 54,

    /// <summary>
    /// Omega 6 (LA) Fatty Acids
    /// </summary>
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, 10, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 6 (LA) Fatty Acids", Order = 15010)]
    Omega_6_LA = 55,

    /// <summary>
    /// Omega 3 (DHA) Fatty Acids
    /// </summary>
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.06, 0.12, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3 (DHA) Fatty Acids", Order = 15300)]
    Omega_3_DHA = 56,

    /// <summary>
    /// Trans Fats
    /// </summary>
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_51_70_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_51_70_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Male_71_XX_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.TotalEnergy, CaloriesPerGram = 9, For = Person.Female_71_XX_Years)]
    [Display(Name = "Trans Fats", Order = 15400)]
    Fatty_Acids_Total_Trans = 57,

    /// <summary>
    /// Cholesterol
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Cholesterol", Order = 15700)]
    Cholesterol = 58,

    /// <summary>
    /// Tryptophan
    /// </summary>
    [DailyAllowance(0.4, 4.5, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.4, 4.5, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.4, 4.5, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.4, 4.5, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Tryptophan", Order = 16300)]
    Tryptophan = 59,

    /// <summary>
    /// Arginine
    /// </summary>
    [DailyAllowance(-1, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Arginine", Order = 16700)]
    Arginine = 60,

    /// <summary>
    /// Lysine
    /// </summary>
    [DailyAllowance(2.7, 6, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.7, 6, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.7, 6, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.7, 6, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lysine", Order = 16800)]
    Lysine = 61,

    /// <summary>
    /// Methionine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Methionine", Order = 16900)]
    Methionine = 62,

    /// <summary>
    /// Leucine
    /// </summary>
    [DailyAllowance(2.9, 35, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 35, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.9, 35, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 35, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(2.9, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(-1, 30, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [Display(Name = "Leucine", Order = 17000)]
    Leucine = 63,

    /// <summary>
    /// Isoleucine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Isoleucine", Order = 17100)]
    Isoleucine = 64,

    /// <summary>
    /// Valine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Valine", Order = 17200)]
    Valine = 65,

    /// <summary>
    /// Phenylalanine
    /// </summary>
    [DailyAllowance(2.3, 12, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.3, 12, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.3, 12, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.3, 12, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Phenylalanine", Order = 17300)]
    Phenylalanine = 66,

    /// <summary>
    /// Histidine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Histidine", Order = 17400)]
    Histidine = 67,

    /// <summary>
    /// Threonine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Threonine", Order = 17500)]
    Threonine = 68,

    /// <summary>
    /// Glycine
    /// </summary>
    [DailyAllowance(1.5, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.5, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.5, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.5, 15, Measure.Grams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Glycine", Order = 17600)]
    Glycine = 69,

    /// <summary>
    /// Betaine
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Betaine", Order = 999999)]
    Betaine = 70,

    /// <summary>
    /// Chlorine (Cl)
    /// </summary>
    [DailyAllowance(2300, 3600, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2300, 3600, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2300, 3600, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2300, 3600, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chlorine (Cl)", Order = 999999)]
    Chlorine_Cl = 71,

    /// <summary>
    /// Chromium (Cr)
    /// </summary>
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chromium (Cr)", Order = 999999)]
    Chromium_Cr = 72,

    /// <summary>
    /// Flavonoids
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Flavonoids", Order = 999999)]
    Flavonoids_total = 73,

    /// <summary>
    /// Lithium (Li)
    /// </summary>
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Lithium (Li)", Order = 999999)]
    Lithium_Li = 74,

    /// <summary>
    /// Polyphenols
    /// </summary>
    [DailyAllowance(20.4, -1, Measure.Milligrams, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20.4, -1, Measure.Milligrams, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20.4, -1, Measure.Milligrams, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20.4, -1, Measure.Milligrams, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Polyphenols", Order = 999999)]
    Polyphenols_Total = 75,

    /// <summary>
    /// Vanadium (V)
    /// </summary>
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_51_70_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_51_70_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Male_71_XX_Years)]
    [DailyAllowance(-1, 1.8, Measure.Milligrams, Multiplier.Day, CaloriesPerGram = 0, For = Person.Female_71_XX_Years)]
    [Display(Name = "Vanadium (V)", Order = 999999)]
    Vanadium_V = 76,
}
