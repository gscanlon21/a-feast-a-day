using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum Nutrients
{
    None = 0,

    /// <summary>
    /// Energy (Atwater General Factors)
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.KCalorie, 957, 280.0)]
    [Display(Name = "Energy (Atwater General Factors)")]
    Energy_Atwater_General_Factors_KCalorie = 2047,

    /// <summary>
    /// Energy (Atwater Specific Factors)
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.KCalorie, 958, 290.0)]
    [Display(Name = "Energy (Atwater Specific Factors)")]
    Energy_Atwater_Specific_Factors_KCalorie = 2048,

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
    [NutrientsMetadata(Measure.Grams, 203, 600.0)]
    [Display(Name = "Protein")]
    Protein_Grams = 1003,

    /// <summary>
    /// Total lipid (fat)
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 204, 800.0)]
    [Display(Name = "Total lipid (fat)")]
    Total_lipid_fat_Grams = 1004,

    /// <summary>
    /// Carbohydrate, by difference
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 205, 1110.0)]
    [Display(Name = "Carbohydrate, by difference")]
    Carbohydrate_by_difference_Grams = 1005,

    /// <summary>
    /// Energy
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.KCalorie, 208, 300.0)]
    [Display(Name = "Energy")]
    Energy_KCalorie = 1008,

    /// <summary>
    /// Starch
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 209, 2200.0)]
    [Display(Name = "Starch")]
    Starch_Grams = 1009,

    /// <summary>
    /// Carbohydrate, by summation
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 205.2, 1120.0)]
    [Display(Name = "Carbohydrate, by summation")]
    Carbohydrate_by_summation_Grams = 1050,

    /// <summary>
    /// Sugars, Total
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 269.3, 1500.0)]
    [Display(Name = "Sugars, Total")]
    Sugars_Total_Grams = 1063,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 281, 999999.0)]
    [Display(Name = "Oligosaccharides")]
    Oligosaccharides_Grams = 1069,

    /// <summary>
    /// Nonstarch polysaccharides
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 282, 999999.0)]
    [Display(Name = "Nonstarch polysaccharides")]
    Nonstarch_polysaccharides_Grams = 1070,

    /// <summary>
    /// Resistant starch
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 283, 2225)]
    [Display(Name = "Resistant starch")]
    Resistant_starch_Grams = 1071,

    /// <summary>
    /// Fiber, total dietary
    /// </summary>
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 291, 1200.0)]
    [Display(Name = "Fiber, total dietary")]
    Fiber_total_dietary_Grams = 1079,

    /// <summary>
    /// Fiber, soluble
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 295, 1240.0)]
    [Display(Name = "Fiber, soluble")]
    Fiber_soluble_Grams = 1082,

    /// <summary>
    /// Fiber, insoluble
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 297, 1260.0)]
    [Display(Name = "Fiber, insoluble")]
    Fiber_insoluble_Grams = 1084,

    /// <summary>
    /// Calcium, Ca
    /// </summary>
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 301, 5300.0)]
    [Display(Name = "Calcium, Ca")]
    Calcium_Ca_Milligrams = 1087,

    /// <summary>
    /// Chlorine, Cl
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 302, 999999.0)]
    [Display(Name = "Chlorine, Cl")]
    Chlorine_Cl_Milligrams = 1088,

    /// <summary>
    /// Iron, Fe
    /// </summary>
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 303, 5400.0)]
    [Display(Name = "Iron, Fe")]
    Iron_Fe_Milligrams = 1089,

    /// <summary>
    /// Magnesium, Mg
    /// </summary>
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 304, 5500.0)]
    [Display(Name = "Magnesium, Mg")]
    Magnesium_Mg_Milligrams = 1090,

    /// <summary>
    /// Phosphorus, P
    /// </summary>
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 305, 5600.0)]
    [Display(Name = "Phosphorus, P")]
    Phosphorus_P_Milligrams = 1091,

    /// <summary>
    /// Potassium, K
    /// </summary>
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 306, 5700.0)]
    [Display(Name = "Potassium, K")]
    Potassium_K_Milligrams = 1092,

    /// <summary>
    /// Sodium, Na
    /// </summary>
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 307, 5800.0)]
    [Display(Name = "Sodium, Na")]
    Sodium_Na_Milligrams = 1093,

    /// <summary>
    /// Zinc, Zn
    /// </summary>
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 309, 5900.0)]
    [Display(Name = "Zinc, Zn")]
    Zinc_Zn_Milligrams = 1095,

    /// <summary>
    /// Chromium, Cr
    /// </summary>
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 310, 999999.0)]
    [Display(Name = "Chromium, Cr")]
    Chromium_Cr_Micrograms = 1096,

    /// <summary>
    /// Copper, Cu
    /// </summary>
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 312, 6000.0)]
    [Display(Name = "Copper, Cu")]
    Copper_Cu_Milligrams = 1098,

    /// <summary>
    /// Fluoride, F
    /// </summary>
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 313, 6240.0)]
    [Display(Name = "Fluoride, F")]
    Fluoride_F_Micrograms = 1099,

    /// <summary>
    /// Iodine, I
    /// </summary>
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 314, 6150.0)]
    [Display(Name = "Iodine, I")]
    Iodine_I_Micrograms = 1100,

    /// <summary>
    /// Manganese, Mn
    /// </summary>
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 315, 6100.0)]
    [Display(Name = "Manganese, Mn")]
    Manganese_Mn_Milligrams = 1101,

    /// <summary>
    /// Molybdenum, Mo
    /// </summary>
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 316, 6243.0)]
    [Display(Name = "Molybdenum, Mo")]
    Molybdenum_Mo_Micrograms = 1102,

    /// <summary>
    /// Selenium, Se
    /// </summary>
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 317, 6200.0)]
    [Display(Name = "Selenium, Se")]
    Selenium_Se_Micrograms = 1103,

    /// <summary>
    /// Retinol
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 319, 7430.0)]
    [Display(Name = "Retinol")]
    Retinol_Micrograms = 1105,

    /// <summary>
    /// Vitamin A, RAE
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 320, 7420.0)]
    [Display(Name = "Vitamin A, RAE")]
    Vitamin_A_RAE_Micrograms = 1106,

    /// <summary>
    /// Carotene, beta
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 321, 7440.0)]
    [Display(Name = "Carotene, beta")]
    Carotene_beta_Micrograms = 1107,

    /// <summary>
    /// Carotene, alpha
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 322, 7450.0)]
    [Display(Name = "Carotene, alpha")]
    Carotene_alpha_Micrograms = 1108,

    /// <summary>
    /// Vitamin E (alpha-tocopherol)
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 323, 7905.0)]
    [Display(Name = "Vitamin E (alpha-tocopherol)")]
    Vitamin_E_alpha_tocopherol_Milligrams = 1109,

    /// <summary>
    /// Vitamin D (D2 + D3)
    /// </summary>
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 328, 8700.0)]
    [Display(Name = "Vitamin D (D2 + D3)")]
    Vitamin_D_D2__D3_Micrograms = 1114,

    /// <summary>
    /// Lutein + zeaxanthin
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 338, 7560.0)]
    [Display(Name = "Lutein + zeaxanthin")]
    Lutein__zeaxanthin_Micrograms = 1123,

    /// <summary>
    /// Boron, B
    /// </summary>
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 354, 6245.0)]
    [Display(Name = "Boron, B")]
    Boron_B_Micrograms = 1137,

    /// <summary>
    /// Lithium, Li
    /// </summary>
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 368, 999999.0)]
    [Display(Name = "Lithium, Li")]
    Lithium_Li_Micrograms = 1144,

    /// <summary>
    /// Vanadium, V
    /// </summary>
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 389, 999999.0)]
    [Display(Name = "Vanadium, V")]
    Vanadium_V_Micrograms = 1155,

    /// <summary>
    /// Carotene
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.MCG_RE, 393, 7600.0)]
    [Display(Name = "Carotene")]
    Carotene_MCG_RE = 1157,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.MG_ATE, 394, 7800.0)]
    [Display(Name = "Vitamin E")]
    Vitamin_E_MG_ATE = 1158,

    /// <summary>
    /// Vitamin C, total ascorbic acid
    /// </summary>
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 401, 6300.0)]
    [Display(Name = "Vitamin C, total ascorbic acid")]
    Vitamin_C_total_ascorbic_acid_Milligrams = 1162,

    /// <summary>
    /// Thiamin
    /// </summary>
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 404, 6400.0)]
    [Display(Name = "Thiamin")]
    Thiamin_Milligrams = 1165,

    /// <summary>
    /// Riboflavin
    /// </summary>
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 405, 6500.0)]
    [Display(Name = "Riboflavin")]
    Riboflavin_Milligrams = 1166,

    /// <summary>
    /// Niacin
    /// </summary>
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 406, 6600.0)]
    [Display(Name = "Niacin")]
    Niacin_Milligrams = 1167,

    /// <summary>
    /// Pantothenic acid
    /// </summary>
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 410, 6700.0)]
    [Display(Name = "Pantothenic acid")]
    Pantothenic_acid_Milligrams = 1170,

    /// <summary>
    /// Vitamin B-6
    /// </summary>
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 415, 6800.0)]
    [Display(Name = "Vitamin B-6")]
    Vitamin_B_6_Milligrams = 1175,

    /// <summary>
    /// Biotin
    /// </summary>
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 416, 6850.0)]
    [Display(Name = "Biotin")]
    Biotin_Micrograms = 1176,

    /// <summary>
    /// Folate, total
    /// </summary>
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 417, 6900.0)]
    [Display(Name = "Folate, total")]
    Folate_total_Micrograms = 1177,

    /// <summary>
    /// Vitamin B-12
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
    [NutrientsMetadata(Measure.Micrograms, 418, 7300.0)]
    [Display(Name = "Vitamin B-12")]
    Vitamin_B_12_Micrograms = 1178,

    /// <summary>
    /// Choline, total
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 421, 7220.0)]
    [Display(Name = "Choline, total")]
    Choline_total_Milligrams = 1180,

    /// <summary>
    /// Vitamin K (phylloquinone)
    /// </summary>
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 430, 8800.0)]
    [Display(Name = "Vitamin K (phylloquinone)")]
    Vitamin_K_phylloquinone_Micrograms = 1185,

    /// <summary>
    /// Betaine
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 454, 7290.0)]
    [Display(Name = "Betaine")]
    Betaine_Milligrams = 1198,

    /// <summary>
    /// Polyphenols, total
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 470, 999999.0)]
    [Display(Name = "Polyphenols, total")]
    Polyphenols_total_Milligrams = 1209,

    /// <summary>
    /// Tryptophan
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 501, 16300.0)]
    [Display(Name = "Tryptophan")]
    Tryptophan_Grams = 1210,

    /// <summary>
    /// Threonine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 502, 16400.0)]
    [Display(Name = "Threonine")]
    Threonine_Grams = 1211,

    /// <summary>
    /// Isoleucine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 503, 16500.0)]
    [Display(Name = "Isoleucine")]
    Isoleucine_Grams = 1212,

    /// <summary>
    /// Leucine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 504, 16600.0)]
    [Display(Name = "Leucine")]
    Leucine_Grams = 1213,

    /// <summary>
    /// Lysine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 505, 16700.0)]
    [Display(Name = "Lysine")]
    Lysine_Grams = 1214,

    /// <summary>
    /// Methionine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 506, 16800.0)]
    [Display(Name = "Methionine")]
    Methionine_Grams = 1215,

    /// <summary>
    /// Phenylalanine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 508, 17000.0)]
    [Display(Name = "Phenylalanine")]
    Phenylalanine_Grams = 1217,

    /// <summary>
    /// Valine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 510, 17200.0)]
    [Display(Name = "Valine")]
    Valine_Grams = 1219,

    /// <summary>
    /// Arginine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 511, 17300.0)]
    [Display(Name = "Arginine")]
    Arginine_Grams = 1220,

    /// <summary>
    /// Histidine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 512, 17400.0)]
    [Display(Name = "Histidine")]
    Histidine_Grams = 1221,

    /// <summary>
    /// Glycine
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 516, 17800.0)]
    [Display(Name = "Glycine")]
    Glycine_Grams = 1225,

    /// <summary>
    /// Cholesterol
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 601, 15700.0)]
    [Display(Name = "Cholesterol")]
    Cholesterol_Milligrams = 1253,

    /// <summary>
    /// Fatty acids, total trans
    /// </summary>
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 605, 15400.0)]
    [Display(Name = "Fatty acids, total trans")]
    Fatty_acids_total_trans_Grams = 1257,

    /// <summary>
    /// Fatty acids, total saturated
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
    [NutrientsMetadata(Measure.Grams, 606, 9700.0)]
    [Display(Name = "Fatty acids, total saturated")]
    Fatty_acids_total_saturated_Grams = 1258,

    /// <summary>
    /// PUFA 22:6 n-3 (DHA)
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 621, 15300.0)]
    [Display(Name = "PUFA 22:6 n-3 (DHA)")]
    PUFA_22_6_n_3_DHA_Grams = 1272,

    /// <summary>
    /// PUFA 20:5 n-3 (EPA)
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 629, 15000.0)]
    [Display(Name = "PUFA 20:5 n-3 (EPA)")]
    PUFA_20_5_n_3_EPA_Grams = 1278,

    /// <summary>
    /// Fatty acids, total monounsaturated
    /// </summary>
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 645, 11400.0)]
    [Display(Name = "Fatty acids, total monounsaturated")]
    Fatty_acids_total_monounsaturated_Grams = 1292,

    /// <summary>
    /// Fatty acids, total polyunsaturated
    /// </summary>
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 646, 12900.0)]
    [Display(Name = "Fatty acids, total polyunsaturated")]
    Fatty_acids_total_polyunsaturated_Grams = 1293,

    /// <summary>
    /// PUFA 18:2 n-6 c,c
    /// </summary>
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 675, 13200.0)]
    [Display(Name = "PUFA 18:2 n-6 c,c")]
    PUFA_18_2_n_6_c_c_Grams = 1316,

    /// <summary>
    /// Flavonoids, total
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 729, 999999.0)]
    [Display(Name = "Flavonoids, total")]
    Flavonoids_total_Milligrams = 1347,

    /// <summary>
    /// PUFA 18:3 n-3 c,c,c (ALA)
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 851, 14000.0)]
    [Display(Name = "PUFA 18:3 n-3 c,c,c (ALA)")]
    PUFA_18_3_n_3_c_c_c_ALA_Grams = 1404,

    /// <summary>
    /// Total Sugars
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 269, 1510.0)]
    [Display(Name = "Total Sugars")]
    Total_Sugars_Grams = 2000,

    /// <summary>
    /// Carbohydrates
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Grams, 956, 1100.0)]
    [Display(Name = "Carbohydrates")]
    Carbohydrates_Grams = 2039,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, -1, 2250.0)]
    [Display(Name = "Oligosaccharides")]
    Oligosaccharides_Milligrams = 2064,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Milligrams, 959, 7810)]
    [Display(Name = "Vitamin E")]
    Vitamin_E_Milligrams = 2068,

    /// <summary>
    /// Vitamin A
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [NutrientsMetadata(Measure.Micrograms, 960, 7430)]
    [Display(Name = "Vitamin A")]
    Vitamin_A_Micrograms = 2067,
}
