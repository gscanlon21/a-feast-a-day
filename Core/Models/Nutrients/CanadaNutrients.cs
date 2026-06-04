using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

public enum CanadaNutrients
{
    None = 0,

    /// <summary>
    /// Protein
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "PROT")]
    [Display(Name = "Protein")]
    Protein_Grams = 203,

    /// <summary>
    /// Fat (total lipids)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "FAT")]
    [Display(Name = "Fat (total lipids)")]
    Fat_total_lipids_Grams = 204,

    /// <summary>
    /// Carbohydrate, total (by difference)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "CARB")]
    [Display(Name = "Carbohydrate, total (by difference)")]
    Carbohydrate_total_by_difference_Grams = 205,

    /// <summary>
    /// Ash, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ASH")]
    [Display(Name = "Ash, total")]
    Ash_total_Grams = 207,

    /// <summary>
    /// Energy (kilocalories)
    /// </summary>
    [HCNutrientsMetadata(Measure.KCalorie, "KCAL")]
    [Display(Name = "Energy (kilocalories)")]
    Energy_kilocalories_KCalorie = 208,

    /// <summary>
    /// Sucrose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "SUCR")]
    [Display(Name = "Sucrose")]
    Sucrose_Grams = 210,

    /// <summary>
    /// Glucose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "GLUC")]
    [Display(Name = "Glucose")]
    Glucose_Grams = 211,

    /// <summary>
    /// Fructose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "FRUC")]
    [Display(Name = "Fructose")]
    Fructose_Grams = 212,

    /// <summary>
    /// Lactose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "LACT")]
    [Display(Name = "Lactose")]
    Lactose_Grams = 213,

    /// <summary>
    /// Maltose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "MALT")]
    [Display(Name = "Maltose")]
    Maltose_Grams = 214,

    /// <summary>
    /// Alcohol
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ALCO")]
    [Display(Name = "Alcohol")]
    Alcohol_Grams = 221,

    /// <summary>
    /// Moisture
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "H2O")]
    [Display(Name = "Moisture")]
    Moisture_Grams = 255,

    /// <summary>
    /// Mannitol
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "MANN")]
    [Display(Name = "Mannitol")]
    Mannitol_Grams = 260,

    /// <summary>
    /// Sorbitol
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "SORB")]
    [Display(Name = "Sorbitol")]
    Sorbitol_Grams = 261,

    /// <summary>
    /// Caffeine
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CAFF")]
    [Display(Name = "Caffeine")]
    Caffeine_Milligrams = 262,

    /// <summary>
    /// Theobromine
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "THBR")]
    [Display(Name = "Theobromine")]
    Theobromine_Milligrams = 263,

    /// <summary>
    /// Energy (kilojoules)
    /// </summary>
    [HCNutrientsMetadata(Measure.KiloJoule, "KJ")]
    [Display(Name = "Energy (kilojoules)")]
    Energy_kilojoules_KiloJoule = 268,

    /// <summary>
    /// Sugars, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TSUG")]
    [Display(Name = "Sugars, total")]
    Sugars_total_Grams = 269,

    /// <summary>
    /// Galactose
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "GAL")]
    [Display(Name = "Galactose")]
    Galactose_Grams = 287,

    /// <summary>
    /// Fibre, total dietary
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TDF")]
    [Display(Name = "Fibre, total dietary")]
    Fibre_total_dietary_Grams = 291,

    /// <summary>
    /// Calcium
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CA")]
    [Display(Name = "Calcium")]
    Calcium_Milligrams = 301,

    /// <summary>
    /// Iron
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "FE")]
    [Display(Name = "Iron")]
    Iron_Milligrams = 303,

    /// <summary>
    /// Magnesium
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "MG")]
    [Display(Name = "Magnesium")]
    Magnesium_Milligrams = 304,

    /// <summary>
    /// Phosphorus
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "P")]
    [Display(Name = "Phosphorus")]
    Phosphorus_Milligrams = 305,

    /// <summary>
    /// Potassium
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "K")]
    [Display(Name = "Potassium")]
    Potassium_Milligrams = 306,

    /// <summary>
    /// Sodium
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "NA")]
    [Display(Name = "Sodium")]
    Sodium_Milligrams = 307,

    /// <summary>
    /// Zinc
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "ZN")]
    [Display(Name = "Zinc")]
    Zinc_Milligrams = 309,

    /// <summary>
    /// Copper
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CU")]
    [Display(Name = "Copper")]
    Copper_Milligrams = 312,

    /// <summary>
    /// Manganese
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "MN")]
    [Display(Name = "Manganese")]
    Manganese_Milligrams = 315,

    /// <summary>
    /// Selenium
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "SE")]
    [Display(Name = "Selenium")]
    Selenium_Micrograms = 317,

    /// <summary>
    /// Retinol
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "RT-µg")]
    [Display(Name = "Retinol")]
    Retinol_Micrograms = 319,

    /// <summary>
    /// Retinol activity equivalents
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "RAE")]
    [Display(Name = "Retinol activity equivalents")]
    Retinol_activity_equivalents_Micrograms = 320,

    /// <summary>
    /// Beta carotene
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "BC-µg")]
    [Display(Name = "Beta carotene")]
    Beta_carotene_Micrograms = 321,

    /// <summary>
    /// Alpha carotene
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "AC-µg")]
    [Display(Name = "Alpha carotene")]
    Alpha_carotene_Micrograms = 322,

    /// <summary>
    /// Alpha-tocopherol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "ATMG")]
    [Display(Name = "Alpha-tocopherol")]
    Alpha_tocopherol_Milligrams = 323,

    /// <summary>
    /// Vitamin D (International Units)
    /// </summary>
    [HCNutrientsMetadata(Measure.IU, "D3+D2-IU")]
    [Display(Name = "Vitamin D (International Units)")]
    Vitamin_D_International_Units_IU = 324,

    /// <summary>
    /// Vitamin D2, ergocalciferol
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "D2-µg")]
    [Display(Name = "Vitamin D2, ergocalciferol")]
    Vitamin_D2_ergocalciferol_Micrograms = 325,

    /// <summary>
    /// Vitamin D3, cholecalciferol
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "D3-µg")]
    [Display(Name = "Vitamin D3, cholecalciferol")]
    Vitamin_D3_cholecalciferol_Micrograms = 326,

    /// <summary>
    /// Vitamin D (D2 + D3)
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "D3+D2-µg")]
    [Display(Name = "Vitamin D (D2 + D3)")]
    Vitamin_D_D2__D3_Micrograms = 328,

    /// <summary>
    /// 25-hydroxycholecalciferol
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "25(OH)D3")]
    [Display(Name = "25-hydroxycholecalciferol")]
    _25_hydroxycholecalciferol_Micrograms = 329,

    /// <summary>
    /// 25-hydroxyergocalciferol
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "25(OH)D2")]
    [Display(Name = "25-hydroxyergocalciferol")]
    _25_hydroxyergocalciferol_Micrograms = 330,

    /// <summary>
    /// Beta cryptoxanthin
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "CRYPX")]
    [Display(Name = "Beta cryptoxanthin")]
    Beta_cryptoxanthin_Micrograms = 334,

    /// <summary>
    /// Lycopene
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "LYCPN")]
    [Display(Name = "Lycopene")]
    Lycopene_Micrograms = 337,

    /// <summary>
    /// Lutein and zeaxanthin
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "LUT+ZEA")]
    [Display(Name = "Lutein and zeaxanthin")]
    Lutein_and_zeaxanthin_Micrograms = 338,

    /// <summary>
    /// Beta-tocopherol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "BTMG")]
    [Display(Name = "Beta-tocopherol")]
    Beta_tocopherol_Milligrams = 341,

    /// <summary>
    /// Gamma-tocopherol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "GTMG")]
    [Display(Name = "Gamma-tocopherol")]
    Gamma_tocopherol_Milligrams = 342,

    /// <summary>
    /// Delta-tocopherol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "DTMG")]
    [Display(Name = "Delta-tocopherol")]
    Delta_tocopherol_Milligrams = 343,

    /// <summary>
    /// Vitamin C
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "VITC")]
    [Display(Name = "Vitamin C")]
    Vitamin_C_Milligrams = 401,

    /// <summary>
    /// Thiamine
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "THIA")]
    [Display(Name = "Thiamine")]
    Thiamine_Milligrams = 404,

    /// <summary>
    /// Riboflavin
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "RIBO")]
    [Display(Name = "Riboflavin")]
    Riboflavin_Milligrams = 405,

    /// <summary>
    /// Niacin (nicotinic acid) preformed
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "N-MG")]
    [Display(Name = "Niacin (nicotinic acid) preformed")]
    Niacin_nicotinic_acid_preformed_Milligrams = 406,

    /// <summary>
    /// Total niacin equivalent
    /// </summary>
    [HCNutrientsMetadata(Measure.MG_NE, "N-NE")]
    [Display(Name = "Total niacin equivalent")]
    Total_niacin_equivalent_MG_NE = 409,

    /// <summary>
    /// Pantothenic acid
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "PANT")]
    [Display(Name = "Pantothenic acid")]
    Pantothenic_acid_Milligrams = 410,

    /// <summary>
    /// Vitamin B-6
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "B6")]
    [Display(Name = "Vitamin B-6")]
    Vitamin_B_6_Milligrams = 415,

    /// <summary>
    /// Biotin
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "BIOT")]
    [Display(Name = "Biotin")]
    Biotin_Micrograms = 416,

    /// <summary>
    /// Total folacin
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "FOLA")]
    [Display(Name = "Total folacin")]
    Total_folacin_Micrograms = 417,

    /// <summary>
    /// Vitamin B-12
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "B12")]
    [Display(Name = "Vitamin B-12")]
    Vitamin_B_12_Micrograms = 418,

    /// <summary>
    /// Choline, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CHOLN")]
    [Display(Name = "Choline, total")]
    Choline_total_Milligrams = 421,

    /// <summary>
    /// Vitamin K (menaquinone-4)
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "MK4")]
    [Display(Name = "Vitamin K (menaquinone-4)")]
    Vitamin_K_menaquinone_4_Micrograms = 428,

    /// <summary>
    /// Vitamin K (dihydrophylloquinone)
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "VITK1D")]
    [Display(Name = "Vitamin K (dihydrophylloquinone)")]
    Vitamin_K_dihydrophylloquinone_Micrograms = 429,

    /// <summary>
    /// Vitamin K (phylloquinone)
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "VITK")]
    [Display(Name = "Vitamin K (phylloquinone)")]
    Vitamin_K_phylloquinone_Micrograms = 430,

    /// <summary>
    /// Folic acid
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "FOAC")]
    [Display(Name = "Folic acid")]
    Folic_acid_Micrograms = 431,

    /// <summary>
    /// Naturally occurring folate
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "FOLN")]
    [Display(Name = "Naturally occurring folate")]
    Naturally_occurring_folate_Micrograms = 432,

    /// <summary>
    /// Dietary folate equivalents
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "DFE")]
    [Display(Name = "Dietary folate equivalents")]
    Dietary_folate_equivalents_Micrograms = 435,

    /// <summary>
    /// Betaine
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "BETN")]
    [Display(Name = "Betaine")]
    Betaine_Milligrams = 454,

    /// <summary>
    /// Tryptophan
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TRP")]
    [Display(Name = "Tryptophan")]
    Tryptophan_Grams = 501,

    /// <summary>
    /// Threonine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "THR")]
    [Display(Name = "Threonine")]
    Threonine_Grams = 502,

    /// <summary>
    /// Isoleucine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ISO")]
    [Display(Name = "Isoleucine")]
    Isoleucine_Grams = 503,

    /// <summary>
    /// Leucine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "LEU")]
    [Display(Name = "Leucine")]
    Leucine_Grams = 504,

    /// <summary>
    /// Lysine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "LYS")]
    [Display(Name = "Lysine")]
    Lysine_Grams = 505,

    /// <summary>
    /// Methionine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "MET")]
    [Display(Name = "Methionine")]
    Methionine_Grams = 506,

    /// <summary>
    /// Cystine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "CYS")]
    [Display(Name = "Cystine")]
    Cystine_Grams = 507,

    /// <summary>
    /// Phenylalanine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "PHE")]
    [Display(Name = "Phenylalanine")]
    Phenylalanine_Grams = 508,

    /// <summary>
    /// Tyrosine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TYR")]
    [Display(Name = "Tyrosine")]
    Tyrosine_Grams = 509,

    /// <summary>
    /// Valine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "VAL")]
    [Display(Name = "Valine")]
    Valine_Grams = 510,

    /// <summary>
    /// Arginine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ARG")]
    [Display(Name = "Arginine")]
    Arginine_Grams = 511,

    /// <summary>
    /// Histidine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "HIS")]
    [Display(Name = "Histidine")]
    Histidine_Grams = 512,

    /// <summary>
    /// Alanine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ALA")]
    [Display(Name = "Alanine")]
    Alanine_Grams = 513,

    /// <summary>
    /// Aspartic acid
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "ASP")]
    [Display(Name = "Aspartic acid")]
    Aspartic_acid_Grams = 514,

    /// <summary>
    /// Glutamic acid
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "GLU")]
    [Display(Name = "Glutamic acid")]
    Glutamic_acid_Grams = 515,

    /// <summary>
    /// Glycine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "GLY")]
    [Display(Name = "Glycine")]
    Glycine_Grams = 516,

    /// <summary>
    /// Proline
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "PRO")]
    [Display(Name = "Proline")]
    Proline_Grams = 517,

    /// <summary>
    /// Serine
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "SER")]
    [Display(Name = "Serine")]
    Serine_Grams = 518,

    /// <summary>
    /// Hydroxyproline
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "HYP")]
    [Display(Name = "Hydroxyproline")]
    Hydroxyproline_Grams = 521,

    /// <summary>
    /// Aspartame
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "ASPA")]
    [Display(Name = "Aspartame")]
    Aspartame_Milligrams = 550,

    /// <summary>
    /// Alpha-tocopherol, added
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "ATMG-A")]
    [Display(Name = "Alpha-tocopherol, added")]
    Alpha_tocopherol_added_Milligrams = 573,

    /// <summary>
    /// Vitamin B-12, added
    /// </summary>
    [HCNutrientsMetadata(Measure.Micrograms, "B12-A")]
    [Display(Name = "Vitamin B-12, added")]
    Vitamin_B_12_added_Micrograms = 578,

    /// <summary>
    /// Cholesterol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CHOL")]
    [Display(Name = "Cholesterol")]
    Cholesterol_Milligrams = 601,

    /// <summary>
    /// Fatty acids, trans, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TRFA")]
    [Display(Name = "Fatty acids, trans, total")]
    Fatty_acids_trans_total_Grams = 605,

    /// <summary>
    /// Fatty acids, saturated, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TSAT")]
    [Display(Name = "Fatty acids, saturated, total")]
    Fatty_acids_saturated_total_Grams = 606,

    /// <summary>
    /// Fatty acids, saturated, 4:0, butanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "4:00")]
    [Display(Name = "Fatty acids, saturated, 4:0, butanoic")]
    Fatty_acids_saturated_4_0_butanoic_Grams = 607,

    /// <summary>
    /// Fatty acids, saturated, 6:0, hexanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "6:00")]
    [Display(Name = "Fatty acids, saturated, 6:0, hexanoic")]
    Fatty_acids_saturated_6_0_hexanoic_Grams = 608,

    /// <summary>
    /// Fatty acids, saturated, 8:0, octanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "8:00")]
    [Display(Name = "Fatty acids, saturated, 8:0, octanoic")]
    Fatty_acids_saturated_8_0_octanoic_Grams = 609,

    /// <summary>
    /// Fatty acids, saturated, 10:0, decanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "10:00")]
    [Display(Name = "Fatty acids, saturated, 10:0, decanoic")]
    Fatty_acids_saturated_10_0_decanoic_Grams = 610,

    /// <summary>
    /// Fatty acids, saturated, 12:0, dodecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "12:00")]
    [Display(Name = "Fatty acids, saturated, 12:0, dodecanoic")]
    Fatty_acids_saturated_12_0_dodecanoic_Grams = 611,

    /// <summary>
    /// Fatty acids, saturated, 14:0, tetradecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "14:00")]
    [Display(Name = "Fatty acids, saturated, 14:0, tetradecanoic")]
    Fatty_acids_saturated_14_0_tetradecanoic_Grams = 612,

    /// <summary>
    /// Fatty acids, saturated, 16:0, hexadecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "16:00")]
    [Display(Name = "Fatty acids, saturated, 16:0, hexadecanoic")]
    Fatty_acids_saturated_16_0_hexadecanoic_Grams = 613,

    /// <summary>
    /// Fatty acids, saturated, 18:0, octadecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:00")]
    [Display(Name = "Fatty acids, saturated, 18:0, octadecanoic")]
    Fatty_acids_saturated_18_0_octadecanoic_Grams = 614,

    /// <summary>
    /// Fatty acids, saturated, 20:0, eicosanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:00")]
    [Display(Name = "Fatty acids, saturated, 20:0, eicosanoic")]
    Fatty_acids_saturated_20_0_eicosanoic_Grams = 615,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1undifferentiated, octadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1undiff")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1undifferentiated, octadecenoic")]
    Fatty_acids_monounsaturated_18_1undifferentiated_octadecenoic_Grams = 617,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2undifferentiated, linoleic, octadecadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2undiff")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2undifferentiated, linoleic, octadecadienoic")]
    Fatty_acids_polyunsaturated_18_2undifferentiated_linoleic_octadecadienoic_Grams = 618,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:3undifferentiated, linolenic, octadecatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:3undiff")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:3undifferentiated, linolenic, octadecatrienoic")]
    Fatty_acids_polyunsaturated_18_3undifferentiated_linolenic_octadecatrienoic_Grams = 619,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:4, eicosatetraenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:4undiff")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:4, eicosatetraenoic")]
    Fatty_acids_polyunsaturated_20_4_eicosatetraenoic_Grams = 620,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:6 n-3, docosahexaenoic (DHA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:6n-3DHA")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:6 n-3, docosahexaenoic (DHA)")]
    Fatty_acids_polyunsaturated_22_6_n_3_docosahexaenoic_DHA_Grams = 621,

    /// <summary>
    /// Fatty acids, saturated, 22:0, docosanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:00")]
    [Display(Name = "Fatty acids, saturated, 22:0, docosanoic")]
    Fatty_acids_saturated_22_0_docosanoic_Grams = 624,

    /// <summary>
    /// Fatty acids, monounsaturated, 14:1, tetradecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "14:01")]
    [Display(Name = "Fatty acids, monounsaturated, 14:1, tetradecenoic")]
    Fatty_acids_monounsaturated_14_1_tetradecenoic_Grams = 625,

    /// <summary>
    /// Fatty acids, monounsaturated, 16:1undifferentiated, hexadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "16:1undiff")]
    [Display(Name = "Fatty acids, monounsaturated, 16:1undifferentiated, hexadecenoic")]
    Fatty_acids_monounsaturated_16_1undifferentiated_hexadecenoic_Grams = 626,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:4, octadecatetraenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:04")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:4, octadecatetraenoic")]
    Fatty_acids_polyunsaturated_18_4_octadecatetraenoic_Grams = 627,

    /// <summary>
    /// Fatty acids, monounsaturated, 20:1, eicosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:01")]
    [Display(Name = "Fatty acids, monounsaturated, 20:1, eicosenoic")]
    Fatty_acids_monounsaturated_20_1_eicosenoic_Grams = 628,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:5 n-3, eicosapentaenoic (EPA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:5n-3EPA")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:5 n-3, eicosapentaenoic (EPA)")]
    Fatty_acids_polyunsaturated_20_5_n_3_eicosapentaenoic_EPA_Grams = 629,

    /// <summary>
    /// Fatty acids, monounsaturated, 22:1undifferentiated, docosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:1undiff")]
    [Display(Name = "Fatty acids, monounsaturated, 22:1undifferentiated, docosenoic")]
    Fatty_acids_monounsaturated_22_1undifferentiated_docosenoic_Grams = 630,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:5 n-3, docosapentaenoic (DPA)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:5n-3DPA")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:5 n-3, docosapentaenoic (DPA)")]
    Fatty_acids_polyunsaturated_22_5_n_3_docosapentaenoic_DPA_Grams = 631,

    /// <summary>
    /// Total plant sterol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "TPST")]
    [Display(Name = "Total plant sterol")]
    Total_plant_sterol_Milligrams = 636,

    /// <summary>
    /// Stigmasterol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "STIG")]
    [Display(Name = "Stigmasterol")]
    Stigmasterol_Milligrams = 638,

    /// <summary>
    /// Campesterol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "CAMSTR")]
    [Display(Name = "Campesterol")]
    Campesterol_Milligrams = 639,

    /// <summary>
    /// Beta-sitosterol
    /// </summary>
    [HCNutrientsMetadata(Measure.Milligrams, "SITSTR")]
    [Display(Name = "Beta-sitosterol")]
    Beta_sitosterol_Milligrams = 641,

    /// <summary>
    /// Fatty acids, monounsaturated, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "MUFA")]
    [Display(Name = "Fatty acids, monounsaturated, total")]
    Fatty_acids_monounsaturated_total_Grams = 645,

    /// <summary>
    /// Fatty acids, polyunsaturated, total
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "PUFA")]
    [Display(Name = "Fatty acids, polyunsaturated, total")]
    Fatty_acids_polyunsaturated_total_Grams = 646,

    /// <summary>
    /// Fatty acids, saturated, 15:0, pentadecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "15:00")]
    [Display(Name = "Fatty acids, saturated, 15:0, pentadecanoic")]
    Fatty_acids_saturated_15_0_pentadecanoic_Grams = 652,

    /// <summary>
    /// Fatty acids, saturated, 17:0, heptadecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "17:00")]
    [Display(Name = "Fatty acids, saturated, 17:0, heptadecanoic")]
    Fatty_acids_saturated_17_0_heptadecanoic_Grams = 653,

    /// <summary>
    /// Fatty acids, saturated, 24:0, tetracosanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "24:00:00")]
    [Display(Name = "Fatty acids, saturated, 24:0, tetracosanoic")]
    Fatty_acids_saturated_24_0_tetracosanoic_Grams = 654,

    /// <summary>
    /// Fatty acids, monounsaturated, 16:1t, hexadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "16:1t")]
    [Display(Name = "Fatty acids, monounsaturated, 16:1t, hexadecenoic")]
    Fatty_acids_monounsaturated_16_1t_hexadecenoic_Grams = 662,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1t, octadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1t, octadecenoic")]
    Fatty_acids_monounsaturated_18_1t_octadecenoic_Grams = 663,

    /// <summary>
    /// Fatty acids, monounsaturated, 22:1t, docosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:1t")]
    [Display(Name = "Fatty acids, monounsaturated, 22:1t, docosenoic")]
    Fatty_acids_monounsaturated_22_1t_docosenoic_Grams = 664,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2t not further defined, linoleic, octadecadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2t")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2t not further defined, linoleic, octadecadienoic")]
    Fatty_acids_polyunsaturated_18_2t_not_further_defined_linoleic_octadecadienoic_Grams = 665,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2i, linoleic, octadecadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2i")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2i, linoleic, octadecadienoic")]
    Fatty_acids_polyunsaturated_18_2i_linoleic_octadecadienoic_Grams = 666,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2t,t , octadecadienenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2t,t")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2t,t , octadecadienenoic")]
    Fatty_acids_polyunsaturated_18_2t_t__octadecadienenoic_Grams = 669,

    /// <summary>
    /// Fatty acids, polyunsaturated, conjugated, 18:2 cla, linoleic, octadecadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2cla")]
    [Display(Name = "Fatty acids, polyunsaturated, conjugated, 18:2 cla, linoleic, octadecadienoic")]
    Fatty_acids_polyunsaturated_conjugated_18_2_cla_linoleic_octadecadienoic_Grams = 670,

    /// <summary>
    /// Fatty acids, monounsaturated, 24:1c, tetracosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "24:1c")]
    [Display(Name = "Fatty acids, monounsaturated, 24:1c, tetracosenoic")]
    Fatty_acids_monounsaturated_24_1c_tetracosenoic_Grams = 671,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:2 c,c  eicosadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:2cc")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:2 c,c  eicosadienoic")]
    Fatty_acids_polyunsaturated_20_2_c_c_eicosadienoic_Grams = 672,

    /// <summary>
    /// Fatty acids, monounsaturated, 16:1c, hexadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "16:1c")]
    [Display(Name = "Fatty acids, monounsaturated, 16:1c, hexadecenoic")]
    Fatty_acids_monounsaturated_16_1c_hexadecenoic_Grams = 673,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1c, octadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1c, octadecenoic")]
    Fatty_acids_monounsaturated_18_1c_octadecenoic_Grams = 674,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2 c,c n-6,  linoleic, octadecadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2ccn-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2 c,c n-6,  linoleic, octadecadienoic")]
    Fatty_acids_polyunsaturated_18_2_c_c_n_6__linoleic_octadecadienoic_Grams = 675,

    /// <summary>
    /// Fatty acids, monounsaturated, 22:1c, docosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:1c")]
    [Display(Name = "Fatty acids, monounsaturated, 22:1c, docosenoic")]
    Fatty_acids_monounsaturated_22_1c_docosenoic_Grams = 676,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:3 c,c,c n-6, g-linolenic, octadecatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:3cccn-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:3 c,c,c n-6, g-linolenic, octadecatrienoic")]
    Fatty_acids_polyunsaturated_18_3_c_c_c_n_6_g_linolenic_octadecatrienoic_Grams = 685,

    /// <summary>
    /// Fatty acids, monounsaturated, 17:1, heptadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "17:01")]
    [Display(Name = "Fatty acids, monounsaturated, 17:1, heptadecenoic")]
    Fatty_acids_monounsaturated_17_1_heptadecenoic_Grams = 687,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:3, eicosatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:3undiff")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:3, eicosatrienoic")]
    Fatty_acids_polyunsaturated_20_3_eicosatrienoic_Grams = 689,

    /// <summary>
    /// Fatty acids, total trans-monoenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TRMO")]
    [Display(Name = "Fatty acids, total trans-monoenoic")]
    Fatty_acids_total_trans_monoenoic_Grams = 693,

    /// <summary>
    /// Fatty acids, total trans-polyenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "TRPO")]
    [Display(Name = "Fatty acids, total trans-polyenoic")]
    Fatty_acids_total_trans_polyenoic_Grams = 695,

    /// <summary>
    /// Fatty acids, saturated, 13:0 tridecanoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "13:00")]
    [Display(Name = "Fatty acids, saturated, 13:0 tridecanoic")]
    Fatty_acids_saturated_13_0_tridecanoic_Grams = 696,

    /// <summary>
    /// Fatty acids, monounsaturated, 15:1, pentadecenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "15:01")]
    [Display(Name = "Fatty acids, monounsaturated, 15:1, pentadecenoic")]
    Fatty_acids_monounsaturated_15_1_pentadecenoic_Grams = 697,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:3 c,c,c n-3  linolenic, octadecatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:3cccn-3")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:3 c,c,c n-3  linolenic, octadecatrienoic")]
    Fatty_acids_polyunsaturated_18_3_c_c_c_n_3_linolenic_octadecatrienoic_Grams = 851,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:3 n-3 eicosatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:3n-3")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:3 n-3 eicosatrienoic")]
    Fatty_acids_polyunsaturated_20_3_n_3_eicosatrienoic_Grams = 852,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:3 n-6, eicosatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:3n-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:3 n-6, eicosatrienoic")]
    Fatty_acids_polyunsaturated_20_3_n_6_eicosatrienoic_Grams = 853,

    /// <summary>
    /// Fatty acids, polyunsaturated, 20:4 n-6, arachidonic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:4n-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 20:4 n-6, arachidonic")]
    Fatty_acids_polyunsaturated_20_4_n_6_arachidonic_Grams = 855,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:3i, linolenic, octadecatrienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:3i")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:3i, linolenic, octadecatrienoic")]
    Fatty_acids_polyunsaturated_18_3i_linolenic_octadecatrienoic_Grams = 856,

    /// <summary>
    /// Fatty acids, polyunsaturated, 21:5
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "21:05")]
    [Display(Name = "Fatty acids, polyunsaturated, 21:5")]
    Fatty_acids_polyunsaturated_21_5_Grams = 857,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:4 n-6, docosatetraenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:4n-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:4 n-6, docosatetraenoic")]
    Fatty_acids_polyunsaturated_22_4_n_6_docosatetraenoic_Grams = 858,

    /// <summary>
    /// Fatty acids, monounsaturated,  24:1undifferentiated, tetracosenoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "24:1undiff")]
    [Display(Name = "Fatty acids, monounsaturated,  24:1undifferentiated, tetracosenoic")]
    Fatty_acids_monounsaturated__24_1undifferentiated_tetracosenoic_Grams = 859,

    /// <summary>
    /// Fatty acids, monounsaturated, 12:1, lauroleic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "12:01")]
    [Display(Name = "Fatty acids, monounsaturated, 12:1, lauroleic")]
    Fatty_acids_monounsaturated_12_1_lauroleic_Grams = 860,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:3,
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:03")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:3,")]
    Fatty_acids_polyunsaturated_22_3_Grams = 861,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:2, docosadienoic
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:02")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:2, docosadienoic")]
    Fatty_acids_polyunsaturated_22_2_docosadienoic_Grams = 862,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 10c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 10c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 10c")]
    Fatty_acids_monounsaturated_18_1_10c_Grams = 884,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 11c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 11c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 11c")]
    Fatty_acids_monounsaturated_18_1_11c_Grams = 885,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 12c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 12c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 12c")]
    Fatty_acids_monounsaturated_18_1_12c_Grams = 886,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 13c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 13c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 13c")]
    Fatty_acids_monounsaturated_18_1_13c_Grams = 888,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 14c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 14c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 14c")]
    Fatty_acids_monounsaturated_18_1_14c_Grams = 891,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 15c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 15c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 15c")]
    Fatty_acids_monounsaturated_18_1_15c_Grams = 895,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 16c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 16c")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 16c")]
    Fatty_acids_monounsaturated_18_1_16c_Grams = 896,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 11t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 11t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 11t")]
    Fatty_acids_monounsaturated_18_1_11t_Grams = 897,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 4t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 4t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 4t")]
    Fatty_acids_monounsaturated_18_1_4t_Grams = 898,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 5t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 5t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 5t")]
    Fatty_acids_monounsaturated_18_1_5t_Grams = 899,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 6t-8t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 6t-8t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 6t-8t")]
    Fatty_acids_monounsaturated_18_1_6t_8t_Grams = 904,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 10t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 10t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 10t")]
    Fatty_acids_monounsaturated_18_1_10t_Grams = 905,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 12t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 12t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 12t")]
    Fatty_acids_monounsaturated_18_1_12t_Grams = 906,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 13t + 14t + 6c-8c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 13t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 13t + 14t + 6c-8c")]
    Fatty_acids_monounsaturated_18_1_13t__14t__6c_8c_Grams = 907,

    /// <summary>
    /// Fatty acids, monounsaturated, 18:1 16t
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:1 16t")]
    [Display(Name = "Fatty acids, monounsaturated, 18:1 16t")]
    Fatty_acids_monounsaturated_18_1_16t_Grams = 908,

    /// <summary>
    /// Fatty acids, monounsaturated, 20:1 5c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "20:1 5c")]
    [Display(Name = "Fatty acids, monounsaturated, 20:1 5c")]
    Fatty_acids_monounsaturated_20_1_5c_Grams = 909,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2 9c,13c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2 9c13c")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2 9c,13c")]
    Fatty_acids_polyunsaturated_18_2_9c_13c_Grams = 910,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2 9c,14c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2 9c14c")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2 9c,14c")]
    Fatty_acids_polyunsaturated_18_2_9c_14c_Grams = 911,

    /// <summary>
    /// Fatty acids, polyunsaturated, 18:2 9c,15c
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "18:2 9c15c")]
    [Display(Name = "Fatty acids, polyunsaturated, 18:2 9c,15c")]
    Fatty_acids_polyunsaturated_18_2_9c_15c_Grams = 912,

    /// <summary>
    /// Fatty acids, polyunsaturated, 22:5n-6
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "22:5n-6")]
    [Display(Name = "Fatty acids, polyunsaturated, 22:5n-6")]
    Fatty_acids_polyunsaturated_22_5n_6_Grams = 913,

    /// <summary>
    /// Fructans (inulin)
    /// </summary>
    [HCNutrientsMetadata(Measure.Grams, "INUL")]
    [Display(Name = "Fructans (inulin)")]
    Fructans_inulin_Grams = 1001,
}
