using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum Nutrients
{
    None = 0,

    /// <summary>
    /// Arginine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Arginine Grams", Order = 1)]
    Arginine_Grams = 1,

    /// <summary>
    /// Betaine Milligrams
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Betaine Milligrams", Order = 2)]
    Betaine_Milligrams = 2,

    /// <summary>
    /// Biotin Micrograms
    /// </summary>
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Biotin Micrograms", Order = 3)]
    Biotin_Micrograms = 3,

    /// <summary>
    /// Boron B Micrograms
    /// </summary>
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 20, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Boron B Micrograms", Order = 4)]
    Boron_B_Micrograms = 4,

    /// <summary>
    /// Calcium Ca Milligrams
    /// </summary>
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 2500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Calcium Ca Milligrams", Order = 5)]
    Calcium_Ca_Milligrams = 5,

    /// <summary>
    /// Calories
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Calories", Order = 6)]
    Calories = 6,

    /// <summary>
    /// Carbohydrate by difference Grams
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrate by difference Grams", Order = 7)]
    Carbohydrate_by_difference_Grams = 7,

    /// <summary>
    /// Carbohydrate by summation Grams
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrate by summation Grams", Order = 8)]
    Carbohydrate_by_summation_Grams = 8,

    /// <summary>
    /// Carbohydrates Grams
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(175, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Carbohydrates Grams", Order = 9)]
    Carbohydrates_Grams = 9,

    /// <summary>
    /// Carotene alpha Micrograms
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene alpha Micrograms", Order = 10)]
    Carotene_alpha_Micrograms = 10,

    /// <summary>
    /// Carotene beta Micrograms
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene beta Micrograms", Order = 11)]
    Carotene_beta_Micrograms = 11,

    /// <summary>
    /// Carotene MCG RE
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Carotene MCG RE", Order = 12)]
    Carotene_MCG_RE = 12,

    /// <summary>
    /// Chlorine Cl Milligrams
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chlorine Cl Milligrams", Order = 13)]
    Chlorine_Cl_Milligrams = 13,

    /// <summary>
    /// Cholesterol Milligrams
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Cholesterol Milligrams", Order = 14)]
    Cholesterol_Milligrams = 14,

    /// <summary>
    /// Choline total Milligrams
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Choline total Milligrams", Order = 15)]
    Choline_total_Milligrams = 15,

    /// <summary>
    /// Chromium Cr Micrograms
    /// </summary>
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Chromium Cr Micrograms", Order = 16)]
    Chromium_Cr_Micrograms = 16,

    /// <summary>
    /// Copper Cu Milligrams
    /// </summary>
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(900, 10000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Copper Cu Milligrams", Order = 17)]
    Copper_Cu_Milligrams = 17,

    /// <summary>
    /// Energy Atwater General Factors KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy Atwater General Factors KCalorie", Order = 18)]
    Energy_Atwater_General_Factors_KCalorie = 18,

    /// <summary>
    /// Energy Atwater Specific Factors KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy Atwater Specific Factors KCalorie", Order = 19)]
    Energy_Atwater_Specific_Factors_KCalorie = 19,

    /// <summary>
    /// Energy KCalorie
    /// </summary>
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1000, 1100, Measure.None, Multiplier.Kilocalorie, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Energy KCalorie", Order = 20)]
    Energy_KCalorie = 20,

    /// <summary>
    /// Fats
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fats", Order = 21)]
    Fats = 21,

    /// <summary>
    /// Fatty acids total monounsaturated Grams
    /// </summary>
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total monounsaturated Grams", Order = 22)]
    Fatty_acids_total_monounsaturated_Grams = 22,

    /// <summary>
    /// Fatty acids total polyunsaturated Grams
    /// </summary>
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.8, 5.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total polyunsaturated Grams", Order = 23)]
    Fatty_acids_total_polyunsaturated_Grams = 23,

    /// <summary>
    /// Fatty acids total saturated Grams
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
    [Display(Name = "Fatty acids total saturated Grams", Order = 24)]
    Fatty_acids_total_saturated_Grams = 24,

    /// <summary>
    /// Fatty acids total trans Grams
    /// </summary>
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Fatty acids total trans Grams", Order = 25)]
    Fatty_acids_total_trans_Grams = 25,

    /// <summary>
    /// Fiber insoluble Grams
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber insoluble Grams", Order = 26)]
    Fiber_insoluble_Grams = 26,

    /// <summary>
    /// Fiber soluble Grams
    /// </summary>
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(19, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(12.5, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber soluble Grams", Order = 27)]
    Fiber_soluble_Grams = 27,

    /// <summary>
    /// Fiber total dietary Grams
    /// </summary>
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(38, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Fiber total dietary Grams", Order = 28)]
    Fiber_total_dietary_Grams = 28,

    /// <summary>
    /// Flavonoids total Milligrams
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Flavonoids total Milligrams", Order = 29)]
    Flavonoids_total_Milligrams = 29,

    /// <summary>
    /// Fluoride F Micrograms
    /// </summary>
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Fluoride F Micrograms", Order = 30)]
    Fluoride_F_Micrograms = 30,

    /// <summary>
    /// Folate total Micrograms
    /// </summary>
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(400, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Folate total Micrograms", Order = 31)]
    Folate_total_Micrograms = 31,

    /// <summary>
    /// Glycine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Glycine Grams", Order = 32)]
    Glycine_Grams = 32,

    /// <summary>
    /// Histidine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Histidine Grams", Order = 33)]
    Histidine_Grams = 33,

    /// <summary>
    /// Iodine I Micrograms
    /// </summary>
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(150, 1100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Iodine I Micrograms", Order = 34)]
    Iodine_I_Micrograms = 34,

    /// <summary>
    /// Iron Fe Milligrams
    /// </summary>
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Iron Fe Milligrams", Order = 35)]
    Iron_Fe_Milligrams = 35,

    /// <summary>
    /// Isoleucine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Isoleucine Grams", Order = 36)]
    Isoleucine_Grams = 36,

    /// <summary>
    /// Leucine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Leucine Grams", Order = 37)]
    Leucine_Grams = 37,

    /// <summary>
    /// Lithium Li Micrograms
    /// </summary>
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14.3, -1, Measure.Micrograms, Multiplier.KilogramOfBodyweight, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lithium Li Micrograms", Order = 38)]
    Lithium_Li_Micrograms = 38,

    /// <summary>
    /// Lutein  zeaxanthin Micrograms
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lutein  zeaxanthin Micrograms", Order = 39)]
    Lutein__zeaxanthin_Micrograms = 39,

    /// <summary>
    /// Lysine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Lysine Grams", Order = 40)]
    Lysine_Grams = 40,

    /// <summary>
    /// Magnesium Mg Milligrams
    /// </summary>
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Magnesium Mg Milligrams", Order = 41)]
    Magnesium_Mg_Milligrams = 41,

    /// <summary>
    /// Manganese Mn Milligrams
    /// </summary>
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.3, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.8, 11, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Manganese Mn Milligrams", Order = 42)]
    Manganese_Mn_Milligrams = 42,

    /// <summary>
    /// Methionine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Methionine Grams", Order = 43)]
    Methionine_Grams = 43,

    /// <summary>
    /// Molybdenum Mo Micrograms
    /// </summary>
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Molybdenum Mo Micrograms", Order = 44)]
    Molybdenum_Mo_Micrograms = 44,

    /// <summary>
    /// Niacin Milligrams
    /// </summary>
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(16, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(14, 35, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Niacin Milligrams", Order = 45)]
    Niacin_Milligrams = 45,

    /// <summary>
    /// Oligosaccharides Grams
    /// </summary>
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Oligosaccharides Grams", Order = 46)]
    Oligosaccharides_Grams = 46,

    /// <summary>
    /// Oligosaccharides Milligrams
    /// </summary>
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Oligosaccharides Milligrams", Order = 47)]
    Oligosaccharides_Milligrams = 47,

    /// <summary>
    /// Omega 3
    /// </summary>
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 3", Order = 48)]
    Omega_3 = 48,

    /// <summary>
    /// Omega 6
    /// </summary>
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Omega 6", Order = 49)]
    Omega_6 = 49,

    /// <summary>
    /// Pantothenic acid Milligrams
    /// </summary>
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Pantothenic acid Milligrams", Order = 50)]
    Pantothenic_acid_Milligrams = 50,

    /// <summary>
    /// Phenylalanine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Phenylalanine Grams", Order = 51)]
    Phenylalanine_Grams = 51,

    /// <summary>
    /// Phosphorus P Milligrams
    /// </summary>
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Phosphorus P Milligrams", Order = 52)]
    Phosphorus_P_Milligrams = 52,

    /// <summary>
    /// Polyphenols total Milligrams
    /// </summary>
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Polyphenols total Milligrams", Order = 53)]
    Polyphenols_total_Milligrams = 53,

    /// <summary>
    /// Potassium K Milligrams
    /// </summary>
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(3400, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(2600, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Potassium K Milligrams", Order = 54)]
    Potassium_K_Milligrams = 54,

    /// <summary>
    /// Protein Grams
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
    [Display(Name = "Protein Grams", Order = 55)]
    Protein_Grams = 55,

    /// <summary>
    /// PUFA 18 2 n 6 c c Grams
    /// </summary>
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(2.5, 5, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "PUFA 18 2 n 6 c c Grams", Order = 56)]
    PUFA_18_2_n_6_c_c_Grams = 56,

    /// <summary>
    /// PUFA 18 3 n 3 c c c ALA Grams
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "PUFA 18 3 n 3 c c c ALA Grams", Order = 57)]
    PUFA_18_3_n_3_c_c_c_ALA_Grams = 57,

    /// <summary>
    /// PUFA 20 5 n 3 EPA Grams
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "PUFA 20 5 n 3 EPA Grams", Order = 58)]
    PUFA_20_5_n_3_EPA_Grams = 58,

    /// <summary>
    /// PUFA 22 6 n 3 DHA Grams
    /// </summary>
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.3, 0.6, Measure.Percent, Multiplier.Kilocalorie, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "PUFA 22 6 n 3 DHA Grams", Order = 59)]
    PUFA_22_6_n_3_DHA_Grams = 59,

    /// <summary>
    /// Resistant starch Grams
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Resistant starch Grams", Order = 60)]
    Resistant_starch_Grams = 60,

    /// <summary>
    /// Retinol Micrograms
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Retinol Micrograms", Order = 61)]
    Retinol_Micrograms = 61,

    /// <summary>
    /// Riboflavin Milligrams
    /// </summary>
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Riboflavin Milligrams", Order = 62)]
    Riboflavin_Milligrams = 62,

    /// <summary>
    /// Selenium Se Micrograms
    /// </summary>
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Selenium Se Micrograms", Order = 63)]
    Selenium_Se_Micrograms = 63,

    /// <summary>
    /// Sodium Na Milligrams
    /// </summary>
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Sodium Na Milligrams", Order = 64)]
    Sodium_Na_Milligrams = 64,

    /// <summary>
    /// Starch Grams
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Starch Grams", Order = 65)]
    Starch_Grams = 65,

    /// <summary>
    /// Sugars Total Grams
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Sugars Total Grams", Order = 66)]
    Sugars_Total_Grams = 66,

    /// <summary>
    /// Thiamin Milligrams
    /// </summary>
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Thiamin Milligrams", Order = 67)]
    Thiamin_Milligrams = 67,

    /// <summary>
    /// Threonine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Threonine Grams", Order = 68)]
    Threonine_Grams = 68,

    /// <summary>
    /// Total lipid fat Grams
    /// </summary>
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9, For = Person.Female_31_50_Years)]
    [Display(Name = "Total lipid fat Grams", Order = 69)]
    Total_lipid_fat_Grams = 69,

    /// <summary>
    /// Total Sugars Grams
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "Total Sugars Grams", Order = 70)]
    Total_Sugars_Grams = 70,

    /// <summary>
    /// Tryptophan Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Tryptophan Grams", Order = 71)]
    Tryptophan_Grams = 71,

    /// <summary>
    /// Valine Grams
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Valine Grams", Order = 72)]
    Valine_Grams = 72,

    /// <summary>
    /// Vanadium V Micrograms
    /// </summary>
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vanadium V Micrograms", Order = 73)]
    Vanadium_V_Micrograms = 73,

    /// <summary>
    /// Vitamin A Micrograms
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin A Micrograms", Order = 74)]
    Vitamin_A_Micrograms = 74,

    /// <summary>
    /// Vitamin A RAE Micrograms
    /// </summary>
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(900, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(700, 3000, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin A RAE Micrograms", Order = 75)]
    Vitamin_A_RAE_Micrograms = 75,

    /// <summary>
    /// Vitamin B 12 Micrograms
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
    [Display(Name = "Vitamin B 12 Micrograms", Order = 76)]
    Vitamin_B_12_Micrograms = 76,

    /// <summary>
    /// Vitamin B 6 Milligrams
    /// </summary>
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin B 6 Milligrams", Order = 77)]
    Vitamin_B_6_Milligrams = 77,

    /// <summary>
    /// Vitamin C total ascorbic acid Milligrams
    /// </summary>
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(90, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(75, 2000, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin C total ascorbic acid Milligrams", Order = 78)]
    Vitamin_C_total_ascorbic_acid_Milligrams = 78,

    /// <summary>
    /// Vitamin D D2  D3 Micrograms
    /// </summary>
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin D D2  D3 Micrograms", Order = 79)]
    Vitamin_D_D2__D3_Micrograms = 79,

    /// <summary>
    /// Vitamin E alpha tocopherol Milligrams
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E alpha tocopherol Milligrams", Order = 80)]
    Vitamin_E_alpha_tocopherol_Milligrams = 80,

    /// <summary>
    /// Vitamin E MG ATE
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E MG ATE", Order = 81)]
    Vitamin_E_MG_ATE = 81,

    /// <summary>
    /// Vitamin E Milligrams
    /// </summary>
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin E Milligrams", Order = 82)]
    Vitamin_E_Milligrams = 82,

    /// <summary>
    /// Vitamin K phylloquinone Micrograms
    /// </summary>
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Vitamin K phylloquinone Micrograms", Order = 83)]
    Vitamin_K_phylloquinone_Micrograms = 83,

    /// <summary>
    /// Zinc Zn Milligrams
    /// </summary>
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "Zinc Zn Milligrams", Order = 84)]
    Zinc_Zn_Milligrams = 84,
}
