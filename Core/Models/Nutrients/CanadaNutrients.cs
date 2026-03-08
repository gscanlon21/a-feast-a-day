using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum CanadaNutrients
{
    None = 0,

    /// <summary>
    /// PROTEIN
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
    [Display(Name = "PROTEIN")]
    PROTEIN_Grams = 203,

    /// <summary>
    /// FAT (TOTAL LIPIDS)
    /// </summary>
    [Display(Name = "FAT (TOTAL LIPIDS)")]
    FAT_TOTAL_LIPIDS_Grams = 204,

    /// <summary>
    /// CARBOHYDRATE, TOTAL (BY DIFFERENCE)
    /// </summary>
    [Display(Name = "CARBOHYDRATE, TOTAL (BY DIFFERENCE)")]
    CARBOHYDRATE_TOTAL_BY_DIFFERENCE_Grams = 205,

    /// <summary>
    /// ASH, TOTAL
    /// </summary>
    [Display(Name = "ASH, TOTAL")]
    ASH_TOTAL_Grams = 207,

    /// <summary>
    /// ENERGY (KILOCALORIES)
    /// </summary>
    [Display(Name = "ENERGY (KILOCALORIES)")]
    ENERGY_KILOCALORIES_KCalorie = 208,

    /// <summary>
    /// STARCH
    /// </summary>
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "STARCH")]
    STARCH_Grams = 810,

    /// <summary>
    /// SUCROSE
    /// </summary>
    [Display(Name = "SUCROSE")]
    SUCROSE_Grams = 210,

    /// <summary>
    /// GLUCOSE
    /// </summary>
    [Display(Name = "GLUCOSE")]
    GLUCOSE_Grams = 211,

    /// <summary>
    /// FRUCTOSE
    /// </summary>
    [Display(Name = "FRUCTOSE")]
    FRUCTOSE_Grams = 212,

    /// <summary>
    /// LACTOSE
    /// </summary>
    [Display(Name = "LACTOSE")]
    LACTOSE_Grams = 213,

    /// <summary>
    /// MALTOSE
    /// </summary>
    [Display(Name = "MALTOSE")]
    MALTOSE_Grams = 214,

    /// <summary>
    /// ALCOHOL
    /// </summary>
    [Display(Name = "ALCOHOL")]
    ALCOHOL_Grams = 221,

    /// <summary>
    /// OXALIC ACID
    /// </summary>
    [Display(Name = "OXALIC ACID")]
    OXALIC_ACID_Milligrams = 245,

    /// <summary>
    /// MOISTURE
    /// </summary>
    [Display(Name = "MOISTURE")]
    MOISTURE_Grams = 255,

    /// <summary>
    /// MANNITOL
    /// </summary>
    [Display(Name = "MANNITOL")]
    MANNITOL_Grams = 260,

    /// <summary>
    /// SORBITOL
    /// </summary>
    [Display(Name = "SORBITOL")]
    SORBITOL_Grams = 261,

    /// <summary>
    /// CAFFEINE
    /// </summary>
    [Display(Name = "CAFFEINE")]
    CAFFEINE_Milligrams = 262,

    /// <summary>
    /// THEOBROMINE
    /// </summary>
    [Display(Name = "THEOBROMINE")]
    THEOBROMINE_Milligrams = 263,

    /// <summary>
    /// ENERGY (KILOJOULES)
    /// </summary>
    [Display(Name = "ENERGY (KILOJOULES)")]
    ENERGY_KILOJOULES_KiloJoule = 268,

    /// <summary>
    /// SUGARS, TOTAL
    /// </summary>
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_19_30_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Male_31_50_Years)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4, For = Person.Female_31_50_Years)]
    [Display(Name = "SUGARS, TOTAL")]
    SUGARS_TOTAL_Grams = 269,

    /// <summary>
    /// GALACTOSE
    /// </summary>
    [Display(Name = "GALACTOSE")]
    GALACTOSE_Grams = 287,

    /// <summary>
    /// FIBRE, TOTAL DIETARY
    /// </summary>
    [Display(Name = "FIBRE, TOTAL DIETARY")]
    FIBRE_TOTAL_DIETARY_Grams = 291,

    /// <summary>
    /// CALCIUM
    /// </summary>
    [Display(Name = "CALCIUM")]
    CALCIUM_Milligrams = 301,

    /// <summary>
    /// IRON
    /// </summary>
    [Display(Name = "IRON")]
    IRON_Milligrams = 303,

    /// <summary>
    /// MAGNESIUM
    /// </summary>
    [Display(Name = "MAGNESIUM")]
    MAGNESIUM_Milligrams = 304,

    /// <summary>
    /// PHOSPHORUS
    /// </summary>
    [Display(Name = "PHOSPHORUS")]
    PHOSPHORUS_Milligrams = 305,

    /// <summary>
    /// POTASSIUM
    /// </summary>
    [Display(Name = "POTASSIUM")]
    POTASSIUM_Milligrams = 306,

    /// <summary>
    /// SODIUM
    /// </summary>
    [Display(Name = "SODIUM")]
    SODIUM_Milligrams = 307,

    /// <summary>
    /// ZINC
    /// </summary>
    [Display(Name = "ZINC")]
    ZINC_Milligrams = 309,

    /// <summary>
    /// COPPER
    /// </summary>
    [Display(Name = "COPPER")]
    COPPER_Milligrams = 312,

    /// <summary>
    /// MANGANESE
    /// </summary>
    [Display(Name = "MANGANESE")]
    MANGANESE_Milligrams = 315,

    /// <summary>
    /// SELENIUM
    /// </summary>
    [Display(Name = "SELENIUM")]
    SELENIUM_None = 317,

    /// <summary>
    /// RETINOL
    /// </summary>
    [Display(Name = "RETINOL")]
    RETINOL_None = 319,

    /// <summary>
    /// RETINOL ACTIVITY EQUIVALENTS
    /// </summary>
    [Display(Name = "RETINOL ACTIVITY EQUIVALENTS")]
    RETINOL_ACTIVITY_EQUIVALENTS_None = 814,

    /// <summary>
    /// BETA CAROTENE
    /// </summary>
    [Display(Name = "BETA CAROTENE")]
    BETA_CAROTENE_None = 321,

    /// <summary>
    /// ALPHA CAROTENE
    /// </summary>
    [Display(Name = "ALPHA CAROTENE")]
    ALPHA_CAROTENE_None = 834,

    /// <summary>
    /// ALPHA-TOCOPHEROL
    /// </summary>
    [Display(Name = "ALPHA-TOCOPHEROL")]
    ALPHA_TOCOPHEROL_Milligrams = 323,

    /// <summary>
    /// VITAMIN D (INTERNATIONAL UNITS)
    /// </summary>
    [Display(Name = "VITAMIN D (INTERNATIONAL UNITS)")]
    VITAMIN_D_INTERNATIONAL_UNITS_IU = 324,

    /// <summary>
    /// VITAMIN D2, ERGOCALCIFEROL
    /// </summary>
    [Display(Name = "VITAMIN D2, ERGOCALCIFEROL")]
    VITAMIN_D2_ERGOCALCIFEROL_None = 876,

    /// <summary>
    /// VITAMIN D (D2 + D3)
    /// </summary>
    [Display(Name = "VITAMIN D (D2 + D3)")]
    VITAMIN_D_D2__D3_None = 339,

    /// <summary>
    /// BETA CRYPTOXANTHIN
    /// </summary>
    [Display(Name = "BETA CRYPTOXANTHIN")]
    BETA_CRYPTOXANTHIN_None = 835,

    /// <summary>
    /// LYCOPENE
    /// </summary>
    [Display(Name = "LYCOPENE")]
    LYCOPENE_None = 836,

    /// <summary>
    /// LUTEIN AND ZEAXANTHIN
    /// </summary>
    [Display(Name = "LUTEIN AND ZEAXANTHIN")]
    LUTEIN_AND_ZEAXANTHIN_None = 837,

    /// <summary>
    /// BETA-TOCOPHEROL
    /// </summary>
    [Display(Name = "BETA-TOCOPHEROL")]
    BETA_TOCOPHEROL_Milligrams = 811,

    /// <summary>
    /// GAMMA-TOCOPHEROL
    /// </summary>
    [Display(Name = "GAMMA-TOCOPHEROL")]
    GAMMA_TOCOPHEROL_Milligrams = 812,

    /// <summary>
    /// DELTA-TOCOPHEROL
    /// </summary>
    [Display(Name = "DELTA-TOCOPHEROL")]
    DELTA_TOCOPHEROL_Milligrams = 813,

    /// <summary>
    /// VITAMIN C
    /// </summary>
    [Display(Name = "VITAMIN C")]
    VITAMIN_C_Milligrams = 401,

    /// <summary>
    /// THIAMIN
    /// </summary>
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "THIAMIN")]
    THIAMIN_Milligrams = 404,

    /// <summary>
    /// RIBOFLAVIN
    /// </summary>
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "RIBOFLAVIN")]
    RIBOFLAVIN_Milligrams = 405,

    /// <summary>
    /// NIACIN (NICOTINIC ACID) PREFORMED
    /// </summary>
    [Display(Name = "NIACIN (NICOTINIC ACID) PREFORMED")]
    NIACIN_NICOTINIC_ACID_PREFORMED_Milligrams = 406,

    /// <summary>
    /// TOTAL NIACIN EQUIVALENT
    /// </summary>
    [Display(Name = "TOTAL NIACIN EQUIVALENT")]
    TOTAL_NIACIN_EQUIVALENT_None = 409,

    /// <summary>
    /// PANTOTHENIC ACID
    /// </summary>
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "PANTOTHENIC ACID")]
    PANTOTHENIC_ACID_Milligrams = 410,

    /// <summary>
    /// VITAMIN B-6
    /// </summary>
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(1.3, 100, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "VITAMIN B-6")]
    VITAMIN_B_6_Milligrams = 415,

    /// <summary>
    /// BIOTIN
    /// </summary>
    [Display(Name = "BIOTIN")]
    BIOTIN_None = 416,

    /// <summary>
    /// TOTAL FOLACIN
    /// </summary>
    [Display(Name = "TOTAL FOLACIN")]
    TOTAL_FOLACIN_None = 417,

    /// <summary>
    /// VITAMIN B-12
    /// </summary>
    [Display(Name = "VITAMIN B-12")]
    VITAMIN_B_12_None = 418,

    /// <summary>
    /// CHOLINE, TOTAL
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "CHOLINE, TOTAL")]
    CHOLINE_TOTAL_Milligrams = 862,

    /// <summary>
    /// VITAMIN K
    /// </summary>
    [Display(Name = "VITAMIN K")]
    VITAMIN_K_None = 430,

    /// <summary>
    /// FOLIC ACID
    /// </summary>
    [Display(Name = "FOLIC ACID")]
    FOLIC_ACID_None = 431,

    /// <summary>
    /// NATURALLY OCCURRING FOLATE
    /// </summary>
    [Display(Name = "NATURALLY OCCURRING FOLATE")]
    NATURALLY_OCCURRING_FOLATE_None = 806,

    /// <summary>
    /// DIETARY FOLATE EQUIVALENTS
    /// </summary>
    [Display(Name = "DIETARY FOLATE EQUIVALENTS")]
    DIETARY_FOLATE_EQUIVALENTS_None = 815,

    /// <summary>
    /// BETAINE
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "BETAINE")]
    BETAINE_Milligrams = 863,

    /// <summary>
    /// TRYPTOPHAN
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "TRYPTOPHAN")]
    TRYPTOPHAN_Grams = 501,

    /// <summary>
    /// THREONINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "THREONINE")]
    THREONINE_Grams = 502,

    /// <summary>
    /// ISOLEUCINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "ISOLEUCINE")]
    ISOLEUCINE_Grams = 503,

    /// <summary>
    /// LEUCINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "LEUCINE")]
    LEUCINE_Grams = 504,

    /// <summary>
    /// LYSINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "LYSINE")]
    LYSINE_Grams = 505,

    /// <summary>
    /// METHIONINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "METHIONINE")]
    METHIONINE_Grams = 506,

    /// <summary>
    /// CYSTINE
    /// </summary>
    [Display(Name = "CYSTINE")]
    CYSTINE_Grams = 507,

    /// <summary>
    /// PHENYLALANINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "PHENYLALANINE")]
    PHENYLALANINE_Grams = 508,

    /// <summary>
    /// TYROSINE
    /// </summary>
    [Display(Name = "TYROSINE")]
    TYROSINE_Grams = 509,

    /// <summary>
    /// VALINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "VALINE")]
    VALINE_Grams = 510,

    /// <summary>
    /// ARGININE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "ARGININE")]
    ARGININE_Grams = 511,

    /// <summary>
    /// HISTIDINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "HISTIDINE")]
    HISTIDINE_Grams = 512,

    /// <summary>
    /// ALANINE
    /// </summary>
    [Display(Name = "ALANINE")]
    ALANINE_Grams = 513,

    /// <summary>
    /// ASPARTIC ACID
    /// </summary>
    [Display(Name = "ASPARTIC ACID")]
    ASPARTIC_ACID_Grams = 514,

    /// <summary>
    /// GLUTAMIC ACID
    /// </summary>
    [Display(Name = "GLUTAMIC ACID")]
    GLUTAMIC_ACID_Grams = 515,

    /// <summary>
    /// GLYCINE
    /// </summary>
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(0.5, 10, Measure.Grams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "GLYCINE")]
    GLYCINE_Grams = 516,

    /// <summary>
    /// PROLINE
    /// </summary>
    [Display(Name = "PROLINE")]
    PROLINE_Grams = 517,

    /// <summary>
    /// SERINE
    /// </summary>
    [Display(Name = "SERINE")]
    SERINE_Grams = 518,

    /// <summary>
    /// HYDROXYPROLINE
    /// </summary>
    [Display(Name = "HYDROXYPROLINE")]
    HYDROXYPROLINE_Grams = 828,

    /// <summary>
    /// ASPARTAME
    /// </summary>
    [Display(Name = "ASPARTAME")]
    ASPARTAME_Milligrams = 550,

    /// <summary>
    /// ALPHA-TOCOPHEROL, ADDED
    /// </summary>
    [Display(Name = "ALPHA-TOCOPHEROL, ADDED")]
    ALPHA_TOCOPHEROL_ADDED_Milligrams = 875,

    /// <summary>
    /// VITAMIN B12, ADDED
    /// </summary>
    [Display(Name = "VITAMIN B12, ADDED")]
    VITAMIN_B12_ADDED_None = 874,

    /// <summary>
    /// CHOLESTEROL
    /// </summary>
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_19_30_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Male_31_50_Years)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person, CaloriesPerGram = 0, For = Person.Female_31_50_Years)]
    [Display(Name = "CHOLESTEROL")]
    CHOLESTEROL_Milligrams = 601,

    /// <summary>
    /// FATTY ACIDS, TRANS, TOTAL
    /// </summary>
    [Display(Name = "FATTY ACIDS, TRANS, TOTAL")]
    FATTY_ACIDS_TRANS_TOTAL_Grams = 605,

    /// <summary>
    /// FATTY ACIDS, SATURATED, TOTAL
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, TOTAL")]
    FATTY_ACIDS_SATURATED_TOTAL_Grams = 606,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 4:0, BUTANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 4:0, BUTANOIC")]
    FATTY_ACIDS_SATURATED_4_0_BUTANOIC_Grams = 607,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 6:0, HEXANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 6:0, HEXANOIC")]
    FATTY_ACIDS_SATURATED_6_0_HEXANOIC_Grams = 608,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 8:0, OCTANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 8:0, OCTANOIC")]
    FATTY_ACIDS_SATURATED_8_0_OCTANOIC_Grams = 609,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 10:0, DECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 10:0, DECANOIC")]
    FATTY_ACIDS_SATURATED_10_0_DECANOIC_Grams = 610,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 12:0, DODECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 12:0, DODECANOIC")]
    FATTY_ACIDS_SATURATED_12_0_DODECANOIC_Grams = 611,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 14:0, TETRADECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 14:0, TETRADECANOIC")]
    FATTY_ACIDS_SATURATED_14_0_TETRADECANOIC_Grams = 612,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 16:0, HEXADECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 16:0, HEXADECANOIC")]
    FATTY_ACIDS_SATURATED_16_0_HEXADECANOIC_Grams = 613,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 18:0, OCTADECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 18:0, OCTADECANOIC")]
    FATTY_ACIDS_SATURATED_18_0_OCTADECANOIC_Grams = 614,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 20:0, EICOSANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 20:0, EICOSANOIC")]
    FATTY_ACIDS_SATURATED_20_0_EICOSANOIC_Grams = 615,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1undifferentiated, OCTADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1undifferentiated, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1undifferentiated_OCTADECENOIC_Grams = 617,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2undifferentiated, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2undifferentiated, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2undifferentiated_LINOLEIC_OCTADECADIENOIC_Grams = 618,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3undifferentiated, LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3undifferentiated, LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3undifferentiated_LINOLENIC_OCTADECATRIENOIC_Grams = 619,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:4, EICOSATETRAENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:4, EICOSATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_4_EICOSATETRAENOIC_Grams = 620,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:6 n-3, DOCOSAHEXAENOIC (DHA)
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:6 n-3, DOCOSAHEXAENOIC (DHA)")]
    FATTY_ACIDS_POLYUNSATURATED_22_6_n_3_DOCOSAHEXAENOIC_DHA_Grams = 621,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 22:0, DOCOSANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 22:0, DOCOSANOIC")]
    FATTY_ACIDS_SATURATED_22_0_DOCOSANOIC_Grams = 624,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 14:1, TETRADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 14:1, TETRADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_14_1_TETRADECENOIC_Grams = 625,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1undifferentiated, HEXADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1undifferentiated, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1undifferentiated_HEXADECENOIC_Grams = 626,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:4, OCTADECATETRAENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:4, OCTADECATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_4_OCTADECATETRAENOIC_Grams = 627,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 20:1, EICOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 20:1, EICOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_20_1_EICOSENOIC_Grams = 628,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:5 n-3, EICOSAPENTAENOIC (EPA)
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:5 n-3, EICOSAPENTAENOIC (EPA)")]
    FATTY_ACIDS_POLYUNSATURATED_20_5_n_3_EICOSAPENTAENOIC_EPA_Grams = 629,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1undifferentiated, DOCOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1undifferentiated, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1undifferentiated_DOCOSENOIC_Grams = 630,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:5 n-3, DOCOSAPENTAENOIC (DPA)
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:5 n-3, DOCOSAPENTAENOIC (DPA)")]
    FATTY_ACIDS_POLYUNSATURATED_22_5_n_3_DOCOSAPENTAENOIC_DPA_Grams = 631,

    /// <summary>
    /// TOTAL PLANT STEROL
    /// </summary>
    [Display(Name = "TOTAL PLANT STEROL")]
    TOTAL_PLANT_STEROL_Milligrams = 636,

    /// <summary>
    /// STIGMASTEROL
    /// </summary>
    [Display(Name = "STIGMASTEROL")]
    STIGMASTEROL_Milligrams = 638,

    /// <summary>
    /// CAMPESTEROL
    /// </summary>
    [Display(Name = "CAMPESTEROL")]
    CAMPESTEROL_Milligrams = 866,

    /// <summary>
    /// BETA-SITOSTEROL
    /// </summary>
    [Display(Name = "BETA-SITOSTEROL")]
    BETA_SITOSTEROL_Milligrams = 816,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, TOTAL
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, TOTAL")]
    FATTY_ACIDS_MONOUNSATURATED_TOTAL_Grams = 645,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_Grams = 646,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 15:0, PENTADECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 15:0, PENTADECANOIC")]
    FATTY_ACIDS_SATURATED_15_0_PENTADECANOIC_Grams = 652,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 17:0, HEPTADECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 17:0, HEPTADECANOIC")]
    FATTY_ACIDS_SATURATED_17_0_HEPTADECANOIC_Grams = 653,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 24:0, TETRACOSANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 24:0, TETRACOSANOIC")]
    FATTY_ACIDS_SATURATED_24_0_TETRACOSANOIC_Grams = 654,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1t, HEXADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1t, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1t_HEXADECENOIC_Grams = 817,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1t, OCTADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1t, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1t_OCTADECENOIC_Grams = 818,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1t, DOCOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1t, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1t_DOCOSENOIC_Grams = 852,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2i, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2i, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2i_LINOLEIC_OCTADECADIENOIC_Grams = 819,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2t,t , OCTADECADIENENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2t,t , OCTADECADIENENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2t_t__OCTADECADIENENOIC_Grams = 853,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, CONJUGATED, 18:2 cla, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, CONJUGATED, 18:2 cla, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_CONJUGATED_18_2_cla_LINOLEIC_OCTADECADIENOIC_Grams = 838,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 24:1c, TETRACOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 24:1c, TETRACOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_24_1c_TETRACOSENOIC_Grams = 820,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:2 c,c  EICOSADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:2 c,c  EICOSADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_2_c_c_EICOSADIENOIC_Grams = 823,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1c, HEXADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1c, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1c_HEXADECENOIC_Grams = 821,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1c, OCTADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1c, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1c_OCTADECENOIC_Grams = 824,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2 c,c n-6,  LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2 c,c n-6,  LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2_c_c_n_6__LINOLEIC_OCTADECADIENOIC_Grams = 825,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1c, DOCOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1c, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1c_DOCOSENOIC_Grams = 840,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-6, g-LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-6, g-LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3_c_c_c_n_6_g_LINOLENIC_OCTADECATRIENOIC_Grams = 832,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 17:1, HEPTADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 17:1, HEPTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_17_1_HEPTADECENOIC_Grams = 826,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3, EICOSATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3, EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_EICOSATRIENOIC_Grams = 827,

    /// <summary>
    /// FATTY ACIDS, TOTAL TRANS-MONOENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, TOTAL TRANS-MONOENOIC")]
    FATTY_ACIDS_TOTAL_TRANS_MONOENOIC_Grams = 829,

    /// <summary>
    /// FATTY ACIDS, TOTAL TRANS-POLYENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, TOTAL TRANS-POLYENOIC")]
    FATTY_ACIDS_TOTAL_TRANS_POLYENOIC_Grams = 859,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 13:0 TRIDECANOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, SATURATED, 13:0 TRIDECANOIC")]
    FATTY_ACIDS_SATURATED_13_0_TRIDECANOIC_Grams = 830,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 15:1, PENTADECENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 15:1, PENTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_15_1_PENTADECENOIC_Grams = 833,

    /// <summary>
    /// TOTAL MONOSACCARIDES
    /// </summary>
    [Display(Name = "TOTAL MONOSACCARIDES")]
    TOTAL_MONOSACCARIDES_Grams = 802,

    /// <summary>
    /// TOTAL DISACCHARIDES
    /// </summary>
    [Display(Name = "TOTAL DISACCHARIDES")]
    TOTAL_DISACCHARIDES_Grams = 803,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-3  LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-3  LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3_c_c_c_n_3_LINOLENIC_OCTADECATRIENOIC_Grams = 831,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3 n-3 EICOSATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3 n-3 EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_n_3_EICOSATRIENOIC_Grams = 861,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3 n-6, EICOSATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3 n-6, EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_n_6_EICOSATRIENOIC_Grams = 854,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:4 n-6, ARACHIDONIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:4 n-6, ARACHIDONIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_4_n_6_ARACHIDONIC_Grams = 855,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3i, LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3i, LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3i_LINOLENIC_OCTADECATRIENOIC_Grams = 841,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 21:5
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 21:5")]
    FATTY_ACIDS_POLYUNSATURATED_21_5_Grams = 843,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:4 n-6, DOCOSATETRAENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:4 n-6, DOCOSATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_22_4_n_6_DOCOSATETRAENOIC_Grams = 845,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED,  24:1undifferentiated, TETRACOSENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED,  24:1undifferentiated, TETRACOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED__24_1undifferentiated_TETRACOSENOIC_Grams = 846,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 12:1, LAUROLEIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 12:1, LAUROLEIC")]
    FATTY_ACIDS_MONOUNSATURATED_12_1_LAUROLEIC_Grams = 847,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:3,
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:3,")]
    FATTY_ACIDS_POLYUNSATURATED_22_3_Grams = 848,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:2, DOCOSADIENOIC
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:2, DOCOSADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_22_2_DOCOSADIENOIC_Grams = 849,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA  N-3
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA  N-3")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA_N_3_Grams = 868,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA   N-6
    /// </summary>
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA   N-6")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA__N_6_Grams = 869,
}
