using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum CanadaNutrients
{
    None = 0,

    /// <summary>
    /// PROTEIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 203, "PROT")]
    [Display(Name = "PROTEIN")]
    PROTEIN_Grams = 203,

    /// <summary>
    /// FAT (TOTAL LIPIDS)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 204, "FAT")]
    [Display(Name = "FAT (TOTAL LIPIDS)")]
    FAT_TOTAL_LIPIDS_Grams = 204,

    /// <summary>
    /// CARBOHYDRATE, TOTAL (BY DIFFERENCE)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 205, "CARB")]
    [Display(Name = "CARBOHYDRATE, TOTAL (BY DIFFERENCE)")]
    CARBOHYDRATE_TOTAL_BY_DIFFERENCE_Grams = 205,

    /// <summary>
    /// ASH, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 207, "ASH")]
    [Display(Name = "ASH, TOTAL")]
    ASH_TOTAL_Grams = 207,

    /// <summary>
    /// ENERGY (KILOCALORIES)
    /// </summary>
    [HCNutrientsMetadata(Measure.KCalorie, 208, "KCAL")]
    [Display(Name = "ENERGY (KILOCALORIES)")]
    ENERGY_KILOCALORIES_KCalorie = 208,

    /// <summary>
    /// STARCH
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 209, "STAR")]
    [Display(Name = "STARCH")]
    STARCH_Grams = 810,

    /// <summary>
    /// SUCROSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 210, "SUCR")]
    [Display(Name = "SUCROSE")]
    SUCROSE_Grams = 210,

    /// <summary>
    /// GLUCOSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 211, "GLUC")]
    [Display(Name = "GLUCOSE")]
    GLUCOSE_Grams = 211,

    /// <summary>
    /// FRUCTOSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 212, "FRUC")]
    [Display(Name = "FRUCTOSE")]
    FRUCTOSE_Grams = 212,

    /// <summary>
    /// LACTOSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 213, "LACT")]
    [Display(Name = "LACTOSE")]
    LACTOSE_Grams = 213,

    /// <summary>
    /// MALTOSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 214, "MALT")]
    [Display(Name = "MALTOSE")]
    MALTOSE_Grams = 214,

    /// <summary>
    /// ALCOHOL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 221, "ALCO")]
    [Display(Name = "ALCOHOL")]
    ALCOHOL_Grams = 221,

    /// <summary>
    /// OXALIC ACID
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 245, "OXAL")]
    [Display(Name = "OXALIC ACID")]
    OXALIC_ACID_Milligrams = 245,

    /// <summary>
    /// MOISTURE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 255, "H2O")]
    [Display(Name = "MOISTURE")]
    MOISTURE_Grams = 255,

    /// <summary>
    /// MANNITOL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 260, "MANN")]
    [Display(Name = "MANNITOL")]
    MANNITOL_Grams = 260,

    /// <summary>
    /// SORBITOL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 261, "SORB")]
    [Display(Name = "SORBITOL")]
    SORBITOL_Grams = 261,

    /// <summary>
    /// CAFFEINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 262, "CAFF")]
    [Display(Name = "CAFFEINE")]
    CAFFEINE_Milligrams = 262,

    /// <summary>
    /// THEOBROMINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 263, "THBR")]
    [Display(Name = "THEOBROMINE")]
    THEOBROMINE_Milligrams = 263,

    /// <summary>
    /// ENERGY (KILOJOULES)
    /// </summary>
    [HCNutrientsMetadata(Measure.KiloJoule, 268, "KJ")]
    [Display(Name = "ENERGY (KILOJOULES)")]
    ENERGY_KILOJOULES_KiloJoule = 268,

    /// <summary>
    /// SUGARS, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 269, "TSUG")]
    [Display(Name = "SUGARS, TOTAL")]
    SUGARS_TOTAL_Grams = 269,

    /// <summary>
    /// GALACTOSE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 287, "GAL")]
    [Display(Name = "GALACTOSE")]
    GALACTOSE_Grams = 287,

    /// <summary>
    /// FIBRE, TOTAL DIETARY
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 291, "TDF")]
    [Display(Name = "FIBRE, TOTAL DIETARY")]
    FIBRE_TOTAL_DIETARY_Grams = 291,

    /// <summary>
    /// CALCIUM
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 301, "CA")]
    [Display(Name = "CALCIUM")]
    CALCIUM_Milligrams = 301,

    /// <summary>
    /// IRON
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 303, "FE")]
    [Display(Name = "IRON")]
    IRON_Milligrams = 303,

    /// <summary>
    /// MAGNESIUM
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 304, "MG")]
    [Display(Name = "MAGNESIUM")]
    MAGNESIUM_Milligrams = 304,

    /// <summary>
    /// PHOSPHORUS
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 305, "P")]
    [Display(Name = "PHOSPHORUS")]
    PHOSPHORUS_Milligrams = 305,

    /// <summary>
    /// POTASSIUM
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 306, "K")]
    [Display(Name = "POTASSIUM")]
    POTASSIUM_Milligrams = 306,

    /// <summary>
    /// SODIUM
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 307, "NA")]
    [Display(Name = "SODIUM")]
    SODIUM_Milligrams = 307,

    /// <summary>
    /// ZINC
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 309, "ZN")]
    [Display(Name = "ZINC")]
    ZINC_Milligrams = 309,

    /// <summary>
    /// COPPER
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 312, "CU")]
    [Display(Name = "COPPER")]
    COPPER_Milligrams = 312,

    /// <summary>
    /// MANGANESE
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 315, "MN")]
    [Display(Name = "MANGANESE")]
    MANGANESE_Milligrams = 315,

    /// <summary>
    /// SELENIUM
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 317, "SE")]
    [Display(Name = "SELENIUM")]
    SELENIUM_Micrograms = 317,

    /// <summary>
    /// RETINOL
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 319, "RT-�G")]
    [Display(Name = "RETINOL")]
    RETINOL_Micrograms = 319,

    /// <summary>
    /// RETINOL ACTIVITY EQUIVALENTS
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 320, "RAE")]
    [Display(Name = "RETINOL ACTIVITY EQUIVALENTS")]
    RETINOL_ACTIVITY_EQUIVALENTS_Micrograms = 814,

    /// <summary>
    /// BETA CAROTENE
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 321, "BC-�G")]
    [Display(Name = "BETA CAROTENE")]
    BETA_CAROTENE_Micrograms = 321,

    /// <summary>
    /// ALPHA CAROTENE
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 322, "AC-�G")]
    [Display(Name = "ALPHA CAROTENE")]
    ALPHA_CAROTENE_Micrograms = 834,

    /// <summary>
    /// ALPHA-TOCOPHEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 323, "ATMG")]
    [Display(Name = "ALPHA-TOCOPHEROL")]
    ALPHA_TOCOPHEROL_Milligrams = 323,

    /// <summary>
    /// VITAMIN D (INTERNATIONAL UNITS)
    /// </summary>
    [HCNutrientsMetadata(Measure.IU, 324, "D-IU")]
    [Display(Name = "VITAMIN D (INTERNATIONAL UNITS)")]
    VITAMIN_D_INTERNATIONAL_UNITS_IU = 324,

    /// <summary>
    /// VITAMIN D2, ERGOCALCIFEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 325, "D2-�G")]
    [Display(Name = "VITAMIN D2, ERGOCALCIFEROL")]
    VITAMIN_D2_ERGOCALCIFEROL_Micrograms = 876,

    /// <summary>
    /// VITAMIN D (D2 + D3)
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 328, "D3+D2-�G")]
    [Display(Name = "VITAMIN D (D2 + D3)")]
    VITAMIN_D_D2__D3_Micrograms = 339,

    /// <summary>
    /// BETA CRYPTOXANTHIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 334, "CRYPX")]
    [Display(Name = "BETA CRYPTOXANTHIN")]
    BETA_CRYPTOXANTHIN_Micrograms = 835,

    /// <summary>
    /// LYCOPENE
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 337, "LYCPN")]
    [Display(Name = "LYCOPENE")]
    LYCOPENE_Micrograms = 836,

    /// <summary>
    /// LUTEIN AND ZEAXANTHIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 338, "LUT+ZEA")]
    [Display(Name = "LUTEIN AND ZEAXANTHIN")]
    LUTEIN_AND_ZEAXANTHIN_Micrograms = 837,

    /// <summary>
    /// BETA-TOCOPHEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 341, "BTMG")]
    [Display(Name = "BETA-TOCOPHEROL")]
    BETA_TOCOPHEROL_Milligrams = 811,

    /// <summary>
    /// GAMMA-TOCOPHEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 342, "GTMG")]
    [Display(Name = "GAMMA-TOCOPHEROL")]
    GAMMA_TOCOPHEROL_Milligrams = 812,

    /// <summary>
    /// DELTA-TOCOPHEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 343, "DTMG")]
    [Display(Name = "DELTA-TOCOPHEROL")]
    DELTA_TOCOPHEROL_Milligrams = 813,

    /// <summary>
    /// VITAMIN C
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 401, "VITC")]
    [Display(Name = "VITAMIN C")]
    VITAMIN_C_Milligrams = 401,

    /// <summary>
    /// THIAMIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 404, "THIA")]
    [Display(Name = "THIAMIN")]
    THIAMIN_Milligrams = 404,

    /// <summary>
    /// RIBOFLAVIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 405, "RIBO")]
    [Display(Name = "RIBOFLAVIN")]
    RIBOFLAVIN_Milligrams = 405,

    /// <summary>
    /// NIACIN (NICOTINIC ACID) PREFORMED
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 406, "N-MG")]
    [Display(Name = "NIACIN (NICOTINIC ACID) PREFORMED")]
    NIACIN_NICOTINIC_ACID_PREFORMED_Milligrams = 406,

    /// <summary>
    /// TOTAL NIACIN EQUIVALENT
    /// </summary>
    [HCNutrientsMetadata(Measure.None, 409, "N-NE")]
    [Display(Name = "TOTAL NIACIN EQUIVALENT")]
    TOTAL_NIACIN_EQUIVALENT_None = 409,

    /// <summary>
    /// PANTOTHENIC ACID
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 410, "PANT")]
    [Display(Name = "PANTOTHENIC ACID")]
    PANTOTHENIC_ACID_Milligrams = 410,

    /// <summary>
    /// VITAMIN B-6
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 415, "B6")]
    [Display(Name = "VITAMIN B-6")]
    VITAMIN_B_6_Milligrams = 415,

    /// <summary>
    /// BIOTIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 416, "BIOT")]
    [Display(Name = "BIOTIN")]
    BIOTIN_Micrograms = 416,

    /// <summary>
    /// TOTAL FOLACIN
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 417, "FOLA")]
    [Display(Name = "TOTAL FOLACIN")]
    TOTAL_FOLACIN_Micrograms = 417,

    /// <summary>
    /// VITAMIN B-12
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 418, "B12")]
    [Display(Name = "VITAMIN B-12")]
    VITAMIN_B_12_Micrograms = 418,

    /// <summary>
    /// CHOLINE, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 421, "CHOLN")]
    [Display(Name = "CHOLINE, TOTAL")]
    CHOLINE_TOTAL_Milligrams = 862,

    /// <summary>
    /// VITAMIN K
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 430, "VITK")]
    [Display(Name = "VITAMIN K")]
    VITAMIN_K_Micrograms = 430,

    /// <summary>
    /// FOLIC ACID
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 431, "FOAC")]
    [Display(Name = "FOLIC ACID")]
    FOLIC_ACID_Micrograms = 431,

    /// <summary>
    /// NATURALLY OCCURRING FOLATE
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 432, "FOLN")]
    [Display(Name = "NATURALLY OCCURRING FOLATE")]
    NATURALLY_OCCURRING_FOLATE_Micrograms = 806,

    /// <summary>
    /// DIETARY FOLATE EQUIVALENTS
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 435, "DFE")]
    [Display(Name = "DIETARY FOLATE EQUIVALENTS")]
    DIETARY_FOLATE_EQUIVALENTS_Micrograms = 815,

    /// <summary>
    /// BETAINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 454, "BETN")]
    [Display(Name = "BETAINE")]
    BETAINE_Milligrams = 863,

    /// <summary>
    /// TRYPTOPHAN
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 501, "TRP")]
    [Display(Name = "TRYPTOPHAN")]
    TRYPTOPHAN_Grams = 501,

    /// <summary>
    /// THREONINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 502, "THR")]
    [Display(Name = "THREONINE")]
    THREONINE_Grams = 502,

    /// <summary>
    /// ISOLEUCINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 503, "ISO")]
    [Display(Name = "ISOLEUCINE")]
    ISOLEUCINE_Grams = 503,

    /// <summary>
    /// LEUCINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 504, "LEU")]
    [Display(Name = "LEUCINE")]
    LEUCINE_Grams = 504,

    /// <summary>
    /// LYSINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 505, "LYS")]
    [Display(Name = "LYSINE")]
    LYSINE_Grams = 505,

    /// <summary>
    /// METHIONINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 506, "MET")]
    [Display(Name = "METHIONINE")]
    METHIONINE_Grams = 506,

    /// <summary>
    /// CYSTINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 507, "CYS")]
    [Display(Name = "CYSTINE")]
    CYSTINE_Grams = 507,

    /// <summary>
    /// PHENYLALANINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 508, "PHE")]
    [Display(Name = "PHENYLALANINE")]
    PHENYLALANINE_Grams = 508,

    /// <summary>
    /// TYROSINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 509, "TYR")]
    [Display(Name = "TYROSINE")]
    TYROSINE_Grams = 509,

    /// <summary>
    /// VALINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 510, "VAL")]
    [Display(Name = "VALINE")]
    VALINE_Grams = 510,

    /// <summary>
    /// ARGININE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 511, "ARG")]
    [Display(Name = "ARGININE")]
    ARGININE_Grams = 511,

    /// <summary>
    /// HISTIDINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 512, "HIS")]
    [Display(Name = "HISTIDINE")]
    HISTIDINE_Grams = 512,

    /// <summary>
    /// ALANINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 513, "ALA")]
    [Display(Name = "ALANINE")]
    ALANINE_Grams = 513,

    /// <summary>
    /// ASPARTIC ACID
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 514, "ASP")]
    [Display(Name = "ASPARTIC ACID")]
    ASPARTIC_ACID_Grams = 514,

    /// <summary>
    /// GLUTAMIC ACID
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 515, "GLU")]
    [Display(Name = "GLUTAMIC ACID")]
    GLUTAMIC_ACID_Grams = 515,

    /// <summary>
    /// GLYCINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 516, "GLY")]
    [Display(Name = "GLYCINE")]
    GLYCINE_Grams = 516,

    /// <summary>
    /// PROLINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 517, "PRO")]
    [Display(Name = "PROLINE")]
    PROLINE_Grams = 517,

    /// <summary>
    /// SERINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 518, "SER")]
    [Display(Name = "SERINE")]
    SERINE_Grams = 518,

    /// <summary>
    /// HYDROXYPROLINE
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 521, "HYP")]
    [Display(Name = "HYDROXYPROLINE")]
    HYDROXYPROLINE_Grams = 828,

    /// <summary>
    /// ASPARTAME
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 550, "ASPA")]
    [Display(Name = "ASPARTAME")]
    ASPARTAME_Milligrams = 550,

    /// <summary>
    /// ALPHA-TOCOPHEROL, ADDED
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 573, "ATMG-A")]
    [Display(Name = "ALPHA-TOCOPHEROL, ADDED")]
    ALPHA_TOCOPHEROL_ADDED_Milligrams = 875,

    /// <summary>
    /// VITAMIN B12, ADDED
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, 578, "B12-A")]
    [Display(Name = "VITAMIN B12, ADDED")]
    VITAMIN_B12_ADDED_Micrograms = 874,

    /// <summary>
    /// CHOLESTEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 601, "CHOL")]
    [Display(Name = "CHOLESTEROL")]
    CHOLESTEROL_Milligrams = 601,

    /// <summary>
    /// FATTY ACIDS, TRANS, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 605, "TRFA")]
    [Display(Name = "FATTY ACIDS, TRANS, TOTAL")]
    FATTY_ACIDS_TRANS_TOTAL_Grams = 605,

    /// <summary>
    /// FATTY ACIDS, SATURATED, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 606, "TSAT")]
    [Display(Name = "FATTY ACIDS, SATURATED, TOTAL")]
    FATTY_ACIDS_SATURATED_TOTAL_Grams = 606,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 4:0, BUTANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 607, "4:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 4:0, BUTANOIC")]
    FATTY_ACIDS_SATURATED_4_0_BUTANOIC_Grams = 607,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 6:0, HEXANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 608, "6:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 6:0, HEXANOIC")]
    FATTY_ACIDS_SATURATED_6_0_HEXANOIC_Grams = 608,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 8:0, OCTANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 609, "8:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 8:0, OCTANOIC")]
    FATTY_ACIDS_SATURATED_8_0_OCTANOIC_Grams = 609,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 10:0, DECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 610, "10:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 10:0, DECANOIC")]
    FATTY_ACIDS_SATURATED_10_0_DECANOIC_Grams = 610,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 12:0, DODECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 611, "12:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 12:0, DODECANOIC")]
    FATTY_ACIDS_SATURATED_12_0_DODECANOIC_Grams = 611,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 14:0, TETRADECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 612, "14:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 14:0, TETRADECANOIC")]
    FATTY_ACIDS_SATURATED_14_0_TETRADECANOIC_Grams = 612,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 16:0, HEXADECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 613, "16:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 16:0, HEXADECANOIC")]
    FATTY_ACIDS_SATURATED_16_0_HEXADECANOIC_Grams = 613,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 18:0, OCTADECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 614, "18:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 18:0, OCTADECANOIC")]
    FATTY_ACIDS_SATURATED_18_0_OCTADECANOIC_Grams = 614,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 20:0, EICOSANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 615, "20:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 20:0, EICOSANOIC")]
    FATTY_ACIDS_SATURATED_20_0_EICOSANOIC_Grams = 615,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1undifferentiated, OCTADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 617, "18:1undiff")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1undifferentiated, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1undifferentiated_OCTADECENOIC_Grams = 617,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2undifferentiated, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 618, "18:2undiff")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2undifferentiated, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2undifferentiated_LINOLEIC_OCTADECADIENOIC_Grams = 618,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3undifferentiated, LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 619, "18:3undiff")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3undifferentiated, LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3undifferentiated_LINOLENIC_OCTADECATRIENOIC_Grams = 619,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:4, EICOSATETRAENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 620, "20:4undiff")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:4, EICOSATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_4_EICOSATETRAENOIC_Grams = 620,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:6 n-3, DOCOSAHEXAENOIC (DHA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 621, "22:6n-3DHA")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:6 n-3, DOCOSAHEXAENOIC (DHA)")]
    FATTY_ACIDS_POLYUNSATURATED_22_6_n_3_DOCOSAHEXAENOIC_DHA_Grams = 621,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 22:0, DOCOSANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 624, "22:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 22:0, DOCOSANOIC")]
    FATTY_ACIDS_SATURATED_22_0_DOCOSANOIC_Grams = 624,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 14:1, TETRADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 625, "14:1")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 14:1, TETRADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_14_1_TETRADECENOIC_Grams = 625,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1undifferentiated, HEXADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 626, "16:1undiff")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1undifferentiated, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1undifferentiated_HEXADECENOIC_Grams = 626,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:4, OCTADECATETRAENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 627, "18:4")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:4, OCTADECATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_4_OCTADECATETRAENOIC_Grams = 627,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 20:1, EICOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 628, "20:1")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 20:1, EICOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_20_1_EICOSENOIC_Grams = 628,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:5 n-3, EICOSAPENTAENOIC (EPA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 629, "20:5n-3EPA")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:5 n-3, EICOSAPENTAENOIC (EPA)")]
    FATTY_ACIDS_POLYUNSATURATED_20_5_n_3_EICOSAPENTAENOIC_EPA_Grams = 629,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1undifferentiated, DOCOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 630, "22:1undiff")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1undifferentiated, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1undifferentiated_DOCOSENOIC_Grams = 630,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:5 n-3, DOCOSAPENTAENOIC (DPA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 631, "22:5n-3DPA")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:5 n-3, DOCOSAPENTAENOIC (DPA)")]
    FATTY_ACIDS_POLYUNSATURATED_22_5_n_3_DOCOSAPENTAENOIC_DPA_Grams = 631,

    /// <summary>
    /// TOTAL PLANT STEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 636, "TPST")]
    [Display(Name = "TOTAL PLANT STEROL")]
    TOTAL_PLANT_STEROL_Milligrams = 636,

    /// <summary>
    /// STIGMASTEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 638, "STIG")]
    [Display(Name = "STIGMASTEROL")]
    STIGMASTEROL_Milligrams = 638,

    /// <summary>
    /// CAMPESTEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 639, "CAMSTR")]
    [Display(Name = "CAMPESTEROL")]
    CAMPESTEROL_Milligrams = 866,

    /// <summary>
    /// BETA-SITOSTEROL
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, 641, "SITSTR")]
    [Display(Name = "BETA-SITOSTEROL")]
    BETA_SITOSTEROL_Milligrams = 816,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 645, "MUFA")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, TOTAL")]
    FATTY_ACIDS_MONOUNSATURATED_TOTAL_Grams = 645,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 646, "PUFA")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_Grams = 646,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 15:0, PENTADECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 652, "15:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 15:0, PENTADECANOIC")]
    FATTY_ACIDS_SATURATED_15_0_PENTADECANOIC_Grams = 652,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 17:0, HEPTADECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 653, "17:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 17:0, HEPTADECANOIC")]
    FATTY_ACIDS_SATURATED_17_0_HEPTADECANOIC_Grams = 653,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 24:0, TETRACOSANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 654, "24:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 24:0, TETRACOSANOIC")]
    FATTY_ACIDS_SATURATED_24_0_TETRACOSANOIC_Grams = 654,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1t, HEXADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 662, "16:1t")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1t, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1t_HEXADECENOIC_Grams = 817,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1t, OCTADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 663, "18:1t")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1t, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1t_OCTADECENOIC_Grams = 818,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1t, DOCOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 664, "22:1t")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1t, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1t_DOCOSENOIC_Grams = 852,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2i, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 666, "18:2i")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2i, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2i_LINOLEIC_OCTADECADIENOIC_Grams = 819,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2t,t , OCTADECADIENENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 669, "18:2t,t")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2t,t , OCTADECADIENENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2t_t__OCTADECADIENENOIC_Grams = 853,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, CONJUGATED, 18:2 cla, LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 670, "18:2cla")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, CONJUGATED, 18:2 cla, LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_CONJUGATED_18_2_cla_LINOLEIC_OCTADECADIENOIC_Grams = 838,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 24:1c, TETRACOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 671, "24:1c")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 24:1c, TETRACOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_24_1c_TETRACOSENOIC_Grams = 820,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:2 c,c  EICOSADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 672, "20:2cc")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:2 c,c  EICOSADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_2_c_c_EICOSADIENOIC_Grams = 823,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 16:1c, HEXADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 673, "16:1c")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 16:1c, HEXADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_16_1c_HEXADECENOIC_Grams = 821,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 18:1c, OCTADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 674, "18:1c")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 18:1c, OCTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_18_1c_OCTADECENOIC_Grams = 824,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:2 c,c n-6,  LINOLEIC, OCTADECADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 675, "18:2ccn-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:2 c,c n-6,  LINOLEIC, OCTADECADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_2_c_c_n_6__LINOLEIC_OCTADECADIENOIC_Grams = 825,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 22:1c, DOCOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 676, "22:1c")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 22:1c, DOCOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_22_1c_DOCOSENOIC_Grams = 840,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-6, g-LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 685, "18:3cccn-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-6, g-LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3_c_c_c_n_6_g_LINOLENIC_OCTADECATRIENOIC_Grams = 832,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 17:1, HEPTADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 687, "17:1")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 17:1, HEPTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_17_1_HEPTADECENOIC_Grams = 826,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3, EICOSATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 689, "20:3undiff")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3, EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_EICOSATRIENOIC_Grams = 827,

    /// <summary>
    /// FATTY ACIDS, TOTAL TRANS-MONOENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 693, "TRMO")]
    [Display(Name = "FATTY ACIDS, TOTAL TRANS-MONOENOIC")]
    FATTY_ACIDS_TOTAL_TRANS_MONOENOIC_Grams = 829,

    /// <summary>
    /// FATTY ACIDS, TOTAL TRANS-POLYENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 695, "TRPO")]
    [Display(Name = "FATTY ACIDS, TOTAL TRANS-POLYENOIC")]
    FATTY_ACIDS_TOTAL_TRANS_POLYENOIC_Grams = 859,

    /// <summary>
    /// FATTY ACIDS, SATURATED, 13:0 TRIDECANOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 696, "13:0")]
    [Display(Name = "FATTY ACIDS, SATURATED, 13:0 TRIDECANOIC")]
    FATTY_ACIDS_SATURATED_13_0_TRIDECANOIC_Grams = 830,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 15:1, PENTADECENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 697, "15:1")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 15:1, PENTADECENOIC")]
    FATTY_ACIDS_MONOUNSATURATED_15_1_PENTADECENOIC_Grams = 833,

    /// <summary>
    /// TOTAL MONOSACCARIDES
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 802, "TMOS")]
    [Display(Name = "TOTAL MONOSACCARIDES")]
    TOTAL_MONOSACCARIDES_Grams = 802,

    /// <summary>
    /// TOTAL DISACCHARIDES
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 803, "TDIS")]
    [Display(Name = "TOTAL DISACCHARIDES")]
    TOTAL_DISACCHARIDES_Grams = 803,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-3  LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 851, "18:3cccn-3")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3 c,c,c n-3  LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3_c_c_c_n_3_LINOLENIC_OCTADECATRIENOIC_Grams = 831,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3 n-3 EICOSATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 852, "20:3n-3")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3 n-3 EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_n_3_EICOSATRIENOIC_Grams = 861,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:3 n-6, EICOSATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 853, "20:3n-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:3 n-6, EICOSATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_3_n_6_EICOSATRIENOIC_Grams = 854,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 20:4 n-6, ARACHIDONIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 855, "20:4n-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 20:4 n-6, ARACHIDONIC")]
    FATTY_ACIDS_POLYUNSATURATED_20_4_n_6_ARACHIDONIC_Grams = 855,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 18:3i, LINOLENIC, OCTADECATRIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 856, "18:3i")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 18:3i, LINOLENIC, OCTADECATRIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_18_3i_LINOLENIC_OCTADECATRIENOIC_Grams = 841,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 21:5
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 857, "21:5")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 21:5")]
    FATTY_ACIDS_POLYUNSATURATED_21_5_Grams = 843,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:4 n-6, DOCOSATETRAENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 858, "22:4n-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:4 n-6, DOCOSATETRAENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_22_4_n_6_DOCOSATETRAENOIC_Grams = 845,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED,  24:1undifferentiated, TETRACOSENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 859, "24:1undiff")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED,  24:1undifferentiated, TETRACOSENOIC")]
    FATTY_ACIDS_MONOUNSATURATED__24_1undifferentiated_TETRACOSENOIC_Grams = 846,

    /// <summary>
    /// FATTY ACIDS, MONOUNSATURATED, 12:1, LAUROLEIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 860, "12:1")]
    [Display(Name = "FATTY ACIDS, MONOUNSATURATED, 12:1, LAUROLEIC")]
    FATTY_ACIDS_MONOUNSATURATED_12_1_LAUROLEIC_Grams = 847,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:3,
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 861, "22:3")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:3,")]
    FATTY_ACIDS_POLYUNSATURATED_22_3_Grams = 848,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, 22:2, DOCOSADIENOIC
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 862, "22:2")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, 22:2, DOCOSADIENOIC")]
    FATTY_ACIDS_POLYUNSATURATED_22_2_DOCOSADIENOIC_Grams = 849,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA  N-3
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 902, "TOmega n-3")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA  N-3")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA_N_3_Grams = 868,

    /// <summary>
    /// FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA   N-6
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, 903, "TOmega n-6")]
    [Display(Name = "FATTY ACIDS, POLYUNSATURATED, TOTAL OMEGA   N-6")]
    FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA__N_6_Grams = 869,
}
