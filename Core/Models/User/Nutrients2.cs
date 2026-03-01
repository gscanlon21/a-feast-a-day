using Core.Code.Attributes;

namespace Core.Models.User;

public enum Nutrients2
{
    /// <summary>
    /// Energy (Atwater General Factors)
    /// </summary>
    [Nutrients2Metadata(Measure.KCalorie, 957, 280)]
    Energy_Atwater_General_Factors_KCalorie = 2047,

    /// <summary>
    /// Energy (Atwater Specific Factors)
    /// </summary>
    [Nutrients2Metadata(Measure.KCalorie, 958, 290)]
    Energy_Atwater_Specific_Factors_KCalorie = 2048,

    /// <summary>
    /// Solids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 201, 200)]
    Solids_Grams = 1001,

    /// <summary>
    /// Nitrogen
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 202, 500)]
    Nitrogen_Grams = 1002,

    /// <summary>
    /// Protein
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 203, 600)]
    Protein_Grams = 1003,

    /// <summary>
    /// Total lipid (fat)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 204, 800)]
    Total_lipid_fat_Grams = 1004,

    /// <summary>
    /// Carbohydrate, by difference
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 205, 1110)]
    Carbohydrate_by_difference_Grams = 1005,

    /// <summary>
    /// Fiber, crude (DO NOT USE - Archived)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 206, 999999)]
    Fiber_crude_DO_NOT_USE__Archived_Grams = 1006,

    /// <summary>
    /// Ash
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 207, 1000)]
    Ash_Grams = 1007,

    /// <summary>
    /// Energy
    /// </summary>
    [Nutrients2Metadata(Measure.KCalorie, 208, 300)]
    Energy_KCalorie = 1008,

    /// <summary>
    /// Starch
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 209, 2200)]
    Starch_Grams = 1009,

    /// <summary>
    /// Sucrose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 210, 1600)]
    Sucrose_Grams = 1010,

    /// <summary>
    /// Glucose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 211, 1700)]
    Glucose_Grams = 1011,

    /// <summary>
    /// Fructose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 212, 1800)]
    Fructose_Grams = 1012,

    /// <summary>
    /// Lactose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 213, 1900)]
    Lactose_Grams = 1013,

    /// <summary>
    /// Maltose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 214, 2000)]
    Maltose_Grams = 1014,

    /// <summary>
    /// Amylose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 218, 999999)]
    Amylose_Grams = 1015,

    /// <summary>
    /// Amylopectin
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 219, 999999)]
    Amylopectin_Grams = 1016,

    /// <summary>
    /// Pectin
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 220, 999999)]
    Pectin_Grams = 1017,

    /// <summary>
    /// Alcohol, ethyl
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 221, 18200)]
    Alcohol_ethyl_Grams = 1018,

    /// <summary>
    /// Pentosan
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 222, 999999)]
    Pentosan_Grams = 1019,

    /// <summary>
    /// Pentoses
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 223, 999999)]
    Pentoses_Grams = 1020,

    /// <summary>
    /// Hemicellulose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 224, 999999)]
    Hemicellulose_Grams = 1021,

    /// <summary>
    /// Cellulose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 225, 999999)]
    Cellulose_Grams = 1022,

    /// <summary>
    /// pH
    /// </summary>
    [Nutrients2Metadata(Measure.PH, 226, 999999)]
    pH_PH = 1023,

    /// <summary>
    /// Specific Gravity
    /// </summary>
    [Nutrients2Metadata(Measure.SpecificGravity, 227, 8955)]
    Specific_Gravity_SpecificGravity = 1024,

    /// <summary>
    /// Organic acids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 229, 2850)]
    Organic_acids_Grams = 1025,

    /// <summary>
    /// Acetic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 230, 2900)]
    Acetic_acid_Milligrams = 1026,

    /// <summary>
    /// Aconitic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 231, 3000)]
    Aconitic_acid_Milligrams = 1027,

    /// <summary>
    /// Benzoic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 232, 3100)]
    Benzoic_acid_Milligrams = 1028,

    /// <summary>
    /// Chelidonic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 233, 3200)]
    Chelidonic_acid_Milligrams = 1029,

    /// <summary>
    /// Chlorogenic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 234, 3300)]
    Chlorogenic_acid_Milligrams = 1030,

    /// <summary>
    /// Cinnamic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 235, 3400)]
    Cinnamic_acid_Milligrams = 1031,

    /// <summary>
    /// Citric acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 236, 3500)]
    Citric_acid_Milligrams = 1032,

    /// <summary>
    /// Fumaric acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 237, 3600)]
    Fumaric_acid_Milligrams = 1033,

    /// <summary>
    /// Galacturonic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 238, 3700)]
    Galacturonic_acid_Milligrams = 1034,

    /// <summary>
    /// Gallic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 239, 3800)]
    Gallic_acid_Milligrams = 1035,

    /// <summary>
    /// Glycolic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 240, 3900)]
    Glycolic_acid_Milligrams = 1036,

    /// <summary>
    /// Isocitric acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 241, 4000)]
    Isocitric_acid_Milligrams = 1037,

    /// <summary>
    /// Lactic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 242, 4100)]
    Lactic_acid_Milligrams = 1038,

    /// <summary>
    /// Malic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 243, 4200)]
    Malic_acid_Milligrams = 1039,

    /// <summary>
    /// Oxaloacetic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 244, 4300)]
    Oxaloacetic_acid_Milligrams = 1040,

    /// <summary>
    /// Oxalic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 245, 4400)]
    Oxalic_acid_Milligrams = 1041,

    /// <summary>
    /// Phytic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 246, 4500)]
    Phytic_acid_Milligrams = 1042,

    /// <summary>
    /// Pyruvic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 247, 4600)]
    Pyruvic_acid_Milligrams = 1043,

    /// <summary>
    /// Quinic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 248, 4700)]
    Quinic_acid_Milligrams = 1044,

    /// <summary>
    /// Salicylic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 249, 4800)]
    Salicylic_acid_Milligrams = 1045,

    /// <summary>
    /// Succinic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 250, 4900)]
    Succinic_acid_Milligrams = 1046,

    /// <summary>
    /// Tartaric acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 251, 5000)]
    Tartaric_acid_Milligrams = 1047,

    /// <summary>
    /// Ursolic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 252, 5100)]
    Ursolic_acid_Milligrams = 1048,

    /// <summary>
    /// Solids, non-fat
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 253, 999999)]
    Solids_non_fat_Grams = 1049,

    /// <summary>
    /// Carbohydrate, by summation
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 205.2, 1120)]
    Carbohydrate_by_summation_Grams = 1050,

    /// <summary>
    /// Water
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 255, 100)]
    Water_Grams = 1051,

    /// <summary>
    /// Adjusted Nitrogen
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 256, 999999)]
    Adjusted_Nitrogen_Grams = 1052,

    /// <summary>
    /// Adjusted Protein
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 257, 700)]
    Adjusted_Protein_Grams = 1053,

    /// <summary>
    /// Piperine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 259, 999999)]
    Piperine_Grams = 1054,

    /// <summary>
    /// Mannitol
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 260, 2500)]
    Mannitol_Grams = 1055,

    /// <summary>
    /// Sorbitol
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 261, 2600)]
    Sorbitol_Grams = 1056,

    /// <summary>
    /// Caffeine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 262, 18300)]
    Caffeine_Milligrams = 1057,

    /// <summary>
    /// Theobromine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 263, 18400)]
    Theobromine_Milligrams = 1058,

    /// <summary>
    /// Nitrates
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 264, 999999)]
    Nitrates_Milligrams = 1059,

    /// <summary>
    /// Nitrites
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 265, 999999)]
    Nitrites_Milligrams = 1060,

    /// <summary>
    /// Nitrosamine,total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 266, 999999)]
    Nitrosamine_total_Milligrams = 1061,

    /// <summary>
    /// Energy
    /// </summary>
    [Nutrients2Metadata(Measure.KiloJoule, 268, 400)]
    Energy_KiloJoule = 1062,

    /// <summary>
    /// Sugars, Total
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 269.3, 1500)]
    Sugars_Total_Grams = 1063,

    /// <summary>
    /// Solids, soluble
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 271, 999999)]
    Solids_soluble_Grams = 1064,

    /// <summary>
    /// Glycogen
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 272, 999999)]
    Glycogen_Grams = 1065,

    /// <summary>
    /// Fiber, neutral detergent (DO NOT USE - Archived)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 273, 999999)]
    Fiber_neutral_detergent_DO_NOT_USE__Archived_Grams = 1066,

    /// <summary>
    /// Reducing sugars
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 274, 999999)]
    Reducing_sugars_Grams = 1067,

    /// <summary>
    /// Beta-glucans
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 276, 999999)]
    Beta_glucans_Grams = 1068,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 281, 999999)]
    Oligosaccharides_Grams = 1069,

    /// <summary>
    /// Nonstarch polysaccharides
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 282, 999999)]
    Nonstarch_polysaccharides_Grams = 1070,

    /// <summary>
    /// Resistant starch
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 283, 2225)]
    Resistant_starch_Grams = 1071,

    /// <summary>
    /// Carbohydrate, other
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 284, -1)]
    Carbohydrate_other_Grams = 1072,

    /// <summary>
    /// Arabinose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 285, 999999)]
    Arabinose_Grams = 1073,

    /// <summary>
    /// Xylose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 286, 999999)]
    Xylose_Grams = 1074,

    /// <summary>
    /// Galactose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 287, 2100)]
    Galactose_Grams = 1075,

    /// <summary>
    /// Raffinose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 288, 2300)]
    Raffinose_Grams = 1076,

    /// <summary>
    /// Stachyose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 289, 2400)]
    Stachyose_Grams = 1077,

    /// <summary>
    /// Xylitol
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 290, 2700)]
    Xylitol_Grams = 1078,

    /// <summary>
    /// Fiber, total dietary
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 291, 1200)]
    Fiber_total_dietary_Grams = 1079,

    /// <summary>
    /// Lignin
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 292, 999999)]
    Lignin_Grams = 1080,

    /// <summary>
    /// Ribose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 294, 999999)]
    Ribose_Grams = 1081,

    /// <summary>
    /// Fiber, soluble
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 295, 1240)]
    Fiber_soluble_Grams = 1082,

    /// <summary>
    /// Theophylline
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 296, 999999)]
    Theophylline_Milligrams = 1083,

    /// <summary>
    /// Fiber, insoluble
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 297, 1260)]
    Fiber_insoluble_Grams = 1084,

    /// <summary>
    /// Total fat (NLEA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 298, 900)]
    Total_fat_NLEA_Grams = 1085,

    /// <summary>
    /// Total sugar alcohols
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 299, 999999)]
    Total_sugar_alcohols_Grams = 1086,

    /// <summary>
    /// Calcium, Ca
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 301, 5300)]
    Calcium_Ca_Milligrams = 1087,

    /// <summary>
    /// Chlorine, Cl
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 302, 999999)]
    Chlorine_Cl_Milligrams = 1088,

    /// <summary>
    /// Iron, Fe
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 303, 5400)]
    Iron_Fe_Milligrams = 1089,

    /// <summary>
    /// Magnesium, Mg
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 304, 5500)]
    Magnesium_Mg_Milligrams = 1090,

    /// <summary>
    /// Phosphorus, P
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 305, 5600)]
    Phosphorus_P_Milligrams = 1091,

    /// <summary>
    /// Potassium, K
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 306, 5700)]
    Potassium_K_Milligrams = 1092,

    /// <summary>
    /// Sodium, Na
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 307, 5800)]
    Sodium_Na_Milligrams = 1093,

    /// <summary>
    /// Sulfur, S
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 308, 6241)]
    Sulfur_S_Milligrams = 1094,

    /// <summary>
    /// Zinc, Zn
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 309, 5900)]
    Zinc_Zn_Milligrams = 1095,

    /// <summary>
    /// Chromium, Cr
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 310, 999999)]
    Chromium_Cr_Micrograms = 1096,

    /// <summary>
    /// Cobalt, Co
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 311, 6244)]
    Cobalt_Co_Micrograms = 1097,

    /// <summary>
    /// Copper, Cu
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 312, 6000)]
    Copper_Cu_Milligrams = 1098,

    /// <summary>
    /// Fluoride, F
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 313, 6240)]
    Fluoride_F_Micrograms = 1099,

    /// <summary>
    /// Iodine, I
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 314, 6150)]
    Iodine_I_Micrograms = 1100,

    /// <summary>
    /// Manganese, Mn
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 315, 6100)]
    Manganese_Mn_Milligrams = 1101,

    /// <summary>
    /// Molybdenum, Mo
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 316, 6243)]
    Molybdenum_Mo_Micrograms = 1102,

    /// <summary>
    /// Selenium, Se
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 317, 6200)]
    Selenium_Se_Micrograms = 1103,

    /// <summary>
    /// Vitamin A, IU
    /// </summary>
    [Nutrients2Metadata(Measure.IU, 318, 7500)]
    Vitamin_A_IU_IU = 1104,

    /// <summary>
    /// Retinol
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 319, 7430)]
    Retinol_Micrograms = 1105,

    /// <summary>
    /// Vitamin A, RAE
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 320, 7420)]
    Vitamin_A_RAE_Micrograms = 1106,

    /// <summary>
    /// Carotene, beta
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 321, 7440)]
    Carotene_beta_Micrograms = 1107,

    /// <summary>
    /// Carotene, alpha
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 322, 7450)]
    Carotene_alpha_Micrograms = 1108,

    /// <summary>
    /// Vitamin E (alpha-tocopherol)
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 323, 7905)]
    Vitamin_E_alpha_tocopherol_Milligrams = 1109,

    /// <summary>
    /// Vitamin D (D2 + D3), International Units
    /// </summary>
    [Nutrients2Metadata(Measure.IU, 324, 8650)]
    Vitamin_D_D2__D3__International_Units_IU = 1110,

    /// <summary>
    /// Vitamin D2 (ergocalciferol)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 325, 8710)]
    Vitamin_D2_ergocalciferol_Micrograms = 1111,

    /// <summary>
    /// Vitamin D3 (cholecalciferol)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 326, 8720)]
    Vitamin_D3_cholecalciferol_Micrograms = 1112,

    /// <summary>
    /// 25-hydroxycholecalciferol
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 327, 8730)]
    _25_hydroxycholecalciferol_Micrograms = 1113,

    /// <summary>
    /// Vitamin D (D2 + D3)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 328, 8700)]
    Vitamin_D_D2__D3_Micrograms = 1114,

    /// <summary>
    /// 25-hydroxyergocalciferol
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 329, 8740)]
    _25_hydroxyergocalciferol_Micrograms = 1115,

    /// <summary>
    /// Phytoene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 330, 7570)]
    Phytoene_Micrograms = 1116,

    /// <summary>
    /// Phytofluene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 331, 7580)]
    Phytofluene_Micrograms = 1117,

    /// <summary>
    /// Carotene, gamma
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 332, 7455)]
    Carotene_gamma_Micrograms = 1118,

    /// <summary>
    /// Zeaxanthin
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 338.2, 7564)]
    Zeaxanthin_Micrograms = 1119,

    /// <summary>
    /// Cryptoxanthin, beta
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 334, 7460)]
    Cryptoxanthin_beta_Micrograms = 1120,

    /// <summary>
    /// Lutein
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 338.1, 7562)]
    Lutein_Micrograms = 1121,

    /// <summary>
    /// Lycopene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 337, 7530)]
    Lycopene_Micrograms = 1122,

    /// <summary>
    /// Lutein + zeaxanthin
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 338, 7560)]
    Lutein__zeaxanthin_Micrograms = 1123,

    /// <summary>
    /// Vitamin E (label entry primarily)
    /// </summary>
    [Nutrients2Metadata(Measure.IU, 340, 999999)]
    Vitamin_E_label_entry_primarily_IU = 1124,

    /// <summary>
    /// Tocopherol, beta
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 341, 8000)]
    Tocopherol_beta_Milligrams = 1125,

    /// <summary>
    /// Tocopherol, gamma
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 342, 8100)]
    Tocopherol_gamma_Milligrams = 1126,

    /// <summary>
    /// Tocopherol, delta
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 343, 8200)]
    Tocopherol_delta_Milligrams = 1127,

    /// <summary>
    /// Tocotrienol, alpha
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 344, 8300)]
    Tocotrienol_alpha_Milligrams = 1128,

    /// <summary>
    /// Tocotrienol, beta
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 345, 8400)]
    Tocotrienol_beta_Milligrams = 1129,

    /// <summary>
    /// Tocotrienol, gamma
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 346, 8500)]
    Tocotrienol_gamma_Milligrams = 1130,

    /// <summary>
    /// Tocotrienol, delta
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 347, 8600)]
    Tocotrienol_delta_Milligrams = 1131,

    /// <summary>
    /// Aluminum, Al
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 348, 999999)]
    Aluminum_Al_Micrograms = 1132,

    /// <summary>
    /// Antimony, Sb
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 349, 999999)]
    Antimony_Sb_Micrograms = 1133,

    /// <summary>
    /// Arsenic, As
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 350, 999999)]
    Arsenic_As_Micrograms = 1134,

    /// <summary>
    /// Barium, Ba
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 351, 999999)]
    Barium_Ba_Micrograms = 1135,

    /// <summary>
    /// Beryllium, Be
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 352, 999999)]
    Beryllium_Be_Micrograms = 1136,

    /// <summary>
    /// Boron, B
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 354, 6245)]
    Boron_B_Micrograms = 1137,

    /// <summary>
    /// Bromine, Br
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 355, 999999)]
    Bromine_Br_Micrograms = 1138,

    /// <summary>
    /// Cadmium, Cd
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 356, 999999)]
    Cadmium_Cd_Micrograms = 1139,

    /// <summary>
    /// Gold, Au
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 363, 999999)]
    Gold_Au_Micrograms = 1140,

    /// <summary>
    /// Iron, heme
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 364, 999999)]
    Iron_heme_Milligrams = 1141,

    /// <summary>
    /// Iron, non-heme
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 365, 999999)]
    Iron_non_heme_Milligrams = 1142,

    /// <summary>
    /// Lead, Pb
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 367, 999999)]
    Lead_Pb_Micrograms = 1143,

    /// <summary>
    /// Lithium, Li
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 368, 999999)]
    Lithium_Li_Micrograms = 1144,

    /// <summary>
    /// Mercury, Hg
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 370, 999999)]
    Mercury_Hg_Micrograms = 1145,

    /// <summary>
    /// Nickel, Ni
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 371, 6242)]
    Nickel_Ni_Micrograms = 1146,

    /// <summary>
    /// Rubidium, Rb
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 373, 999999)]
    Rubidium_Rb_Micrograms = 1147,

    /// <summary>
    /// Fluoride - DO NOT USE; use 313
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 374, 6250)]
    Fluoride__DO_NOT_USE_use_313_Micrograms = 1148,

    /// <summary>
    /// Salt, NaCl
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 375, 999999)]
    Salt_NaCl_Milligrams = 1149,

    /// <summary>
    /// Silicon, Si
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 378, 999999)]
    Silicon_Si_Micrograms = 1150,

    /// <summary>
    /// Silver, Ag
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 379, 999999)]
    Silver_Ag_Micrograms = 1151,

    /// <summary>
    /// Strontium, Sr
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 380, 999999)]
    Strontium_Sr_Micrograms = 1152,

    /// <summary>
    /// Tin, Sn
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 385, 999999)]
    Tin_Sn_Micrograms = 1153,

    /// <summary>
    /// Titanium, Ti
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 386, 999999)]
    Titanium_Ti_Micrograms = 1154,

    /// <summary>
    /// Vanadium, V
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 389, 999999)]
    Vanadium_V_Micrograms = 1155,

    /// <summary>
    /// Vitamin A, RE
    /// </summary>
    [Nutrients2Metadata(Measure.MCG_RE, 392, 7500)]
    Vitamin_A_RE_MCG_RE = 1156,

    /// <summary>
    /// Carotene
    /// </summary>
    [Nutrients2Metadata(Measure.MCG_RE, 393, 7600)]
    Carotene_MCG_RE = 1157,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [Nutrients2Metadata(Measure.MG_ATE, 394, 7800)]
    Vitamin_E_MG_ATE = 1158,

    /// <summary>
    /// cis-beta-Carotene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 321.1, 7442)]
    cis_beta_Carotene_Micrograms = 1159,

    /// <summary>
    /// cis-Lycopene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 337.1, 7532)]
    cis_Lycopene_Micrograms = 1160,

    /// <summary>
    /// cis-Lutein/Zeaxanthin
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 338.3, 7561)]
    cis_Lutein_Zeaxanthin_Micrograms = 1161,

    /// <summary>
    /// Vitamin C, total ascorbic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 401, 6300)]
    Vitamin_C_total_ascorbic_acid_Milligrams = 1162,

    /// <summary>
    /// Vitamin C, reduced ascorbic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 402, 999999)]
    Vitamin_C_reduced_ascorbic_acid_Milligrams = 1163,

    /// <summary>
    /// Vitamin C, dehydro ascorbic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 403, 999999)]
    Vitamin_C_dehydro_ascorbic_acid_Milligrams = 1164,

    /// <summary>
    /// Thiamin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 404, 6400)]
    Thiamin_Milligrams = 1165,

    /// <summary>
    /// Riboflavin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 405, 6500)]
    Riboflavin_Milligrams = 1166,

    /// <summary>
    /// Niacin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 406, 6600)]
    Niacin_Milligrams = 1167,

    /// <summary>
    /// Niacin from tryptophan, determined
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 407, 999999)]
    Niacin_from_tryptophan_determined_Milligrams = 1168,

    /// <summary>
    /// Niacin equivalent N406 +N407
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 409, 999999)]
    Niacin_equivalent_N406_N407_Milligrams = 1169,

    /// <summary>
    /// Pantothenic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 410, 6700)]
    Pantothenic_acid_Milligrams = 1170,

    /// <summary>
    /// Vitamin B-6, pyridoxine, alcohol form
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 411, 999999)]
    Vitamin_B_6_pyridoxine_alcohol_form_Milligrams = 1171,

    /// <summary>
    /// Vitamin B-6, pyridoxal, aldehyde form
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 412, 999999)]
    Vitamin_B_6_pyridoxal_aldehyde_form_Milligrams = 1172,

    /// <summary>
    /// Vitamin B-6, pyridoxamine, amine form
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 413, 999999)]
    Vitamin_B_6_pyridoxamine_amine_form_Milligrams = 1173,

    /// <summary>
    /// Vitamin B-6, N411 + N412 +N413
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 414, 999999)]
    Vitamin_B_6_N411__N412_N413_Milligrams = 1174,

    /// <summary>
    /// Vitamin B-6
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 415, 6800)]
    Vitamin_B_6_Milligrams = 1175,

    /// <summary>
    /// Biotin
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 416, 6850)]
    Biotin_Micrograms = 1176,

    /// <summary>
    /// Folate, total
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 417, 6900)]
    Folate_total_Micrograms = 1177,

    /// <summary>
    /// Vitamin B-12
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 418, 7300)]
    Vitamin_B_12_Micrograms = 1178,

    /// <summary>
    /// Folate, free
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 419, 999999)]
    Folate_free_Micrograms = 1179,

    /// <summary>
    /// Choline, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 421, 7220)]
    Choline_total_Milligrams = 1180,

    /// <summary>
    /// Inositol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 422, 2800)]
    Inositol_Milligrams = 1181,

    /// <summary>
    /// Inositol phosphate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 423, 999999)]
    Inositol_phosphate_Milligrams = 1182,

    /// <summary>
    /// Vitamin K (Menaquinone-4)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 428, 8950)]
    Vitamin_K_Menaquinone_4_Micrograms = 1183,

    /// <summary>
    /// Vitamin K (Dihydrophylloquinone)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 429, 8900)]
    Vitamin_K_Dihydrophylloquinone_Micrograms = 1184,

    /// <summary>
    /// Vitamin K (phylloquinone)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 430, 8800)]
    Vitamin_K_phylloquinone_Micrograms = 1185,

    /// <summary>
    /// Folic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 431, 7000)]
    Folic_acid_Micrograms = 1186,

    /// <summary>
    /// Folate, food
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 432, 7100)]
    Folate_food_Micrograms = 1187,

    /// <summary>
    /// 5-methyl tetrahydrofolate (5-MTHF)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 433, 8975)]
    _5_methyl_tetrahydrofolate_5_MTHF_Micrograms = 1188,

    /// <summary>
    /// Folate, not 5-MTHF
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 434, 999999)]
    Folate_not_5_MTHF_Micrograms = 1189,

    /// <summary>
    /// Folate, DFE
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 435, 7200)]
    Folate_DFE_Micrograms = 1190,

    /// <summary>
    /// 10-Formyl folic acid (10HCOFA)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 436, 999999)]
    _10_Formyl_folic_acid_10HCOFA_Micrograms = 1191,

    /// <summary>
    /// 5-Formyltetrahydrofolic acid (5-HCOH4
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 437, 999999)]
    _5_Formyltetrahydrofolic_acid_5_HCOH4_Micrograms = 1192,

    /// <summary>
    /// Tetrahydrofolic acid (THF)
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 438, 999999)]
    Tetrahydrofolic_acid_THF_Micrograms = 1193,

    /// <summary>
    /// Choline, free
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 450, 7230)]
    Choline_free_Milligrams = 1194,

    /// <summary>
    /// Choline, from phosphocholine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 451, 7240)]
    Choline_from_phosphocholine_Milligrams = 1195,

    /// <summary>
    /// Choline, from phosphotidyl choline
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 452, 7250)]
    Choline_from_phosphotidyl_choline_Milligrams = 1196,

    /// <summary>
    /// Choline, from glycerophosphocholine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 453, 7260)]
    Choline_from_glycerophosphocholine_Milligrams = 1197,

    /// <summary>
    /// Betaine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 454, 7290)]
    Betaine_Milligrams = 1198,

    /// <summary>
    /// Choline, from sphingomyelin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 455, 7270)]
    Choline_from_sphingomyelin_Milligrams = 1199,

    /// <summary>
    /// p-Hydroxy benzoic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 460, 999999)]
    p_Hydroxy_benzoic_acid_Milligrams = 1200,

    /// <summary>
    /// Caffeic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 461, 999999)]
    Caffeic_acid_Milligrams = 1201,

    /// <summary>
    /// p-Coumaric acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 462, 999999)]
    p_Coumaric_acid_Milligrams = 1202,

    /// <summary>
    /// Ellagic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 463, 999999)]
    Ellagic_acid_Milligrams = 1203,

    /// <summary>
    /// Ferrulic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 464, 999999)]
    Ferrulic_acid_Milligrams = 1204,

    /// <summary>
    /// Gentisic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 465, 999999)]
    Gentisic_acid_Milligrams = 1205,

    /// <summary>
    /// Tyrosol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 466, 999999)]
    Tyrosol_Milligrams = 1206,

    /// <summary>
    /// Vanillic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 467, 999999)]
    Vanillic_acid_Milligrams = 1207,

    /// <summary>
    /// Phenolic acids, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 469, 999999)]
    Phenolic_acids_total_Milligrams = 1208,

    /// <summary>
    /// Polyphenols, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 470, 999999)]
    Polyphenols_total_Milligrams = 1209,

    /// <summary>
    /// Tryptophan
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 501, 16300)]
    Tryptophan_Grams = 1210,

    /// <summary>
    /// Threonine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 502, 16400)]
    Threonine_Grams = 1211,

    /// <summary>
    /// Isoleucine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 503, 16500)]
    Isoleucine_Grams = 1212,

    /// <summary>
    /// Leucine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 504, 16600)]
    Leucine_Grams = 1213,

    /// <summary>
    /// Lysine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 505, 16700)]
    Lysine_Grams = 1214,

    /// <summary>
    /// Methionine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 506, 16800)]
    Methionine_Grams = 1215,

    /// <summary>
    /// Cystine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 507, 16900)]
    Cystine_Grams = 1216,

    /// <summary>
    /// Phenylalanine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 508, 17000)]
    Phenylalanine_Grams = 1217,

    /// <summary>
    /// Tyrosine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 509, 17100)]
    Tyrosine_Grams = 1218,

    /// <summary>
    /// Valine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 510, 17200)]
    Valine_Grams = 1219,

    /// <summary>
    /// Arginine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 511, 17300)]
    Arginine_Grams = 1220,

    /// <summary>
    /// Histidine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 512, 17400)]
    Histidine_Grams = 1221,

    /// <summary>
    /// Alanine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 513, 17500)]
    Alanine_Grams = 1222,

    /// <summary>
    /// Aspartic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 514, 17600)]
    Aspartic_acid_Grams = 1223,

    /// <summary>
    /// Glutamic acid
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 515, 17700)]
    Glutamic_acid_Grams = 1224,

    /// <summary>
    /// Glycine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 516, 17800)]
    Glycine_Grams = 1225,

    /// <summary>
    /// Proline
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 517, 17900)]
    Proline_Grams = 1226,

    /// <summary>
    /// Serine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 518, 18000)]
    Serine_Grams = 1227,

    /// <summary>
    /// Hydroxyproline
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 521, 18100)]
    Hydroxyproline_Grams = 1228,

    /// <summary>
    /// Cysteine and methionine(sulfer containig AA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 522, 999999)]
    Cysteine_and_methionine_sulfer_containig_AA_Grams = 1229,

    /// <summary>
    /// Phenylalanine and tyrosine (aromatic  AA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 523, 16950)]
    Phenylalanine_and_tyrosine_aromatic_AA_Grams = 1230,

    /// <summary>
    /// Asparagine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 525, 999999)]
    Asparagine_Grams = 1231,

    /// <summary>
    /// Cysteine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 526, 18150)]
    Cysteine_Grams = 1232,

    /// <summary>
    /// Glutamine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 528, 999999)]
    Glutamine_Grams = 1233,

    /// <summary>
    /// Taurine
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 529, 999999)]
    Taurine_Grams = 1234,

    /// <summary>
    /// Sugars, added
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 539, 1540)]
    Sugars_added_Grams = 1235,

    /// <summary>
    /// Sugars, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 549, 1520)]
    Sugars_intrinsic_Grams = 1236,

    /// <summary>
    /// Calcium, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 551, 5340)]
    Calcium_added_Milligrams = 1237,

    /// <summary>
    /// Iron, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 553, 5440)]
    Iron_added_Milligrams = 1238,

    /// <summary>
    /// Calcium, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 561, 5320)]
    Calcium_intrinsic_Milligrams = 1239,

    /// <summary>
    /// Iron, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 563, 5420)]
    Iron_intrinsic_Milligrams = 1240,

    /// <summary>
    /// Vitamin C, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 571, 6340)]
    Vitamin_C_added_Milligrams = 1241,

    /// <summary>
    /// Vitamin E, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 573, 7920)]
    Vitamin_E_added_Milligrams = 1242,

    /// <summary>
    /// Thiamin, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 574, 6440)]
    Thiamin_added_Milligrams = 1243,

    /// <summary>
    /// Riboflavin, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 575, 6540)]
    Riboflavin_added_Milligrams = 1244,

    /// <summary>
    /// Niacin, added
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 576, 6640)]
    Niacin_added_Milligrams = 1245,

    /// <summary>
    /// Vitamin B-12, added
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 578, 7340)]
    Vitamin_B_12_added_Micrograms = 1246,

    /// <summary>
    /// Vitamin C, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 581, 6320)]
    Vitamin_C_intrinsic_Milligrams = 1247,

    /// <summary>
    /// Vitamin E, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 583, 7930)]
    Vitamin_E_intrinsic_Milligrams = 1248,

    /// <summary>
    /// Thiamin, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 584, 6420)]
    Thiamin_intrinsic_Milligrams = 1249,

    /// <summary>
    /// Riboflavin, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 585, 6520)]
    Riboflavin_intrinsic_Milligrams = 1250,

    /// <summary>
    /// Niacin, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 586, 6620)]
    Niacin_intrinsic_Milligrams = 1251,

    /// <summary>
    /// Vitamin B-12, intrinsic
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 588, 7320)]
    Vitamin_B_12_intrinsic_Micrograms = 1252,

    /// <summary>
    /// Cholesterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 601, 15700)]
    Cholesterol_Milligrams = 1253,

    /// <summary>
    /// Glycerides
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 602, 999999)]
    Glycerides_Grams = 1254,

    /// <summary>
    /// Phospholipids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 603, 999999)]
    Phospholipids_Grams = 1255,

    /// <summary>
    /// Glycolipids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 604, 999999)]
    Glycolipids_Grams = 1256,

    /// <summary>
    /// Fatty acids, total trans
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 605, 15400)]
    Fatty_acids_total_trans_Grams = 1257,

    /// <summary>
    /// Fatty acids, total saturated
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 606, 9700)]
    Fatty_acids_total_saturated_Grams = 1258,

    /// <summary>
    /// SFA 4:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 607, 9800)]
    SFA_4_0_Grams = 1259,

    /// <summary>
    /// SFA 6:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 608, 9900)]
    SFA_6_0_Grams = 1260,

    /// <summary>
    /// SFA 8:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 609, 10000)]
    SFA_8_0_Grams = 1261,

    /// <summary>
    /// SFA 10:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 610, 10100)]
    SFA_10_0_Grams = 1262,

    /// <summary>
    /// SFA 12:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 611, 10300)]
    SFA_12_0_Grams = 1263,

    /// <summary>
    /// SFA 14:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 612, 10500)]
    SFA_14_0_Grams = 1264,

    /// <summary>
    /// SFA 16:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 613, 10700)]
    SFA_16_0_Grams = 1265,

    /// <summary>
    /// SFA 18:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 614, 10900)]
    SFA_18_0_Grams = 1266,

    /// <summary>
    /// SFA 20:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 615, 11100)]
    SFA_20_0_Grams = 1267,

    /// <summary>
    /// MUFA 18:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 617, 12100)]
    MUFA_18_1_Grams = 1268,

    /// <summary>
    /// PUFA 18:2
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 618, 13100)]
    PUFA_18_2_Grams = 1269,

    /// <summary>
    /// PUFA 18:3
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 619, 13900)]
    PUFA_18_3_Grams = 1270,

    /// <summary>
    /// PUFA 20:4
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 620, 14700)]
    PUFA_20_4_Grams = 1271,

    /// <summary>
    /// PUFA 22:6 n-3 (DHA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 621, 15300)]
    PUFA_22_6_n_3_DHA_Grams = 1272,

    /// <summary>
    /// SFA 22:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 624, 11200)]
    SFA_22_0_Grams = 1273,

    /// <summary>
    /// MUFA 14:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 625, 11500)]
    MUFA_14_1_Grams = 1274,

    /// <summary>
    /// MUFA 16:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 626, 11700)]
    MUFA_16_1_Grams = 1275,

    /// <summary>
    /// PUFA 18:4
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 627, 14250)]
    PUFA_18_4_Grams = 1276,

    /// <summary>
    /// MUFA 20:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 628, 12400)]
    MUFA_20_1_Grams = 1277,

    /// <summary>
    /// PUFA 20:5 n-3 (EPA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 629, 15000)]
    PUFA_20_5_n_3_EPA_Grams = 1278,

    /// <summary>
    /// MUFA 22:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 630, 12500)]
    MUFA_22_1_Grams = 1279,

    /// <summary>
    /// PUFA 22:5 n-3 (DPA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 631, 15200)]
    PUFA_22_5_n_3_DPA_Grams = 1280,

    /// <summary>
    /// TFA 14:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 821, 15510)]
    TFA_14_1_t_Grams = 1281,

    /// <summary>
    /// Phytosterols
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 636, 15800)]
    Phytosterols_Milligrams = 1283,

    /// <summary>
    /// Ergosterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 637, 16220)]
    Ergosterol_Milligrams = 1284,

    /// <summary>
    /// Stigmasterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 638, 15900)]
    Stigmasterol_Milligrams = 1285,

    /// <summary>
    /// Campesterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 639, 16000)]
    Campesterol_Milligrams = 1286,

    /// <summary>
    /// Brassicasterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 640, 16100)]
    Brassicasterol_Milligrams = 1287,

    /// <summary>
    /// Beta-sitosterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 641, 16200)]
    Beta_sitosterol_Milligrams = 1288,

    /// <summary>
    /// Campestanol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 642, 16221)]
    Campestanol_Milligrams = 1289,

    /// <summary>
    /// Unsaponifiable matter (lipids)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 643, 999999)]
    Unsaponifiable_matter_lipids_Grams = 1290,

    /// <summary>
    /// Fatty acids, other than 607-615, 617-621, 624-632, 652-654, 686-689)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 644, 999999)]
    Fatty_acids_other_than_607_615_617_621_624_632_652_654_686_689_Grams = 1291,

    /// <summary>
    /// Fatty acids, total monounsaturated
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 645, 11400)]
    Fatty_acids_total_monounsaturated_Grams = 1292,

    /// <summary>
    /// Fatty acids, total polyunsaturated
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 646, 12900)]
    Fatty_acids_total_polyunsaturated_Grams = 1293,

    /// <summary>
    /// Beta-sitostanol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 647, 16222)]
    Beta_sitostanol_Milligrams = 1294,

    /// <summary>
    /// Delta-7-avenasterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 648, 16223)]
    Delta_7_avenasterol_Milligrams = 1295,

    /// <summary>
    /// Delta-5-avenasterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 649, 16224)]
    Delta_5_avenasterol_Milligrams = 1296,

    /// <summary>
    /// Alpha-spinasterol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 650, 16225)]
    Alpha_spinasterol_Milligrams = 1297,

    /// <summary>
    /// Phytosterols, other
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 651, 16227)]
    Phytosterols_other_Milligrams = 1298,

    /// <summary>
    /// SFA 15:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 652, 10600)]
    SFA_15_0_Grams = 1299,

    /// <summary>
    /// SFA 17:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 653, 10800)]
    SFA_17_0_Grams = 1300,

    /// <summary>
    /// SFA 24:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 654, 11300)]
    SFA_24_0_Grams = 1301,

    /// <summary>
    /// Wax Esters(Total Wax)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 661, 999999)]
    Wax_Esters_Total_Wax_Grams = 1302,

    /// <summary>
    /// TFA 16:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 662, 15520)]
    TFA_16_1_t_Grams = 1303,

    /// <summary>
    /// TFA 18:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 663, 15521)]
    TFA_18_1_t_Grams = 1304,

    /// <summary>
    /// TFA 22:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 664, 15550)]
    TFA_22_1_t_Grams = 1305,

    /// <summary>
    /// TFA 18:2 t not further defined
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 665, 15610)]
    TFA_18_2_t_not_further_defined_Grams = 1306,

    /// <summary>
    /// PUFA 18:2 i
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 666, 13350)]
    PUFA_18_2_i_Grams = 1307,

    /// <summary>
    /// PUFA 18:2 t,c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 667, 13500)]
    PUFA_18_2_t_c_Grams = 1308,

    /// <summary>
    /// PUFA 18:2 c,t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 668, 13400)]
    PUFA_18_2_c_t_Grams = 1309,

    /// <summary>
    /// TFA 18:2 t,t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 669, 15615)]
    TFA_18_2_t_t_Grams = 1310,

    /// <summary>
    /// PUFA 18:2 CLAs
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 670, 13300)]
    PUFA_18_2_CLAs_Grams = 1311,

    /// <summary>
    /// MUFA 24:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 671, 12800)]
    MUFA_24_1_c_Grams = 1312,

    /// <summary>
    /// PUFA 20:2 n-6 c,c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 672, 14300)]
    PUFA_20_2_n_6_c_c_Grams = 1313,

    /// <summary>
    /// MUFA 16:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 673, 11800)]
    MUFA_16_1_c_Grams = 1314,

    /// <summary>
    /// MUFA 18:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 674, 12200)]
    MUFA_18_1_c_Grams = 1315,

    /// <summary>
    /// PUFA 18:2 n-6 c,c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 675, 13200)]
    PUFA_18_2_n_6_c_c_Grams = 1316,

    /// <summary>
    /// MUFA 22:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 676, 12600)]
    MUFA_22_1_c_Grams = 1317,

    /// <summary>
    /// Fatty acids, saturated, other
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 677, 999999)]
    Fatty_acids_saturated_other_Grams = 1318,

    /// <summary>
    /// Fatty acids, monounsat., other
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 678, 999999)]
    Fatty_acids_monounsat__other_Grams = 1319,

    /// <summary>
    /// Fatty acids, polyunsat., other
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 679, 999999)]
    Fatty_acids_polyunsat__other_Grams = 1320,

    /// <summary>
    /// PUFA 18:3 n-6 c,c,c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 685, 14100)]
    PUFA_18_3_n_6_c_c_c_Grams = 1321,

    /// <summary>
    /// SFA 19:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 686, 11000)]
    SFA_19_0_Grams = 1322,

    /// <summary>
    /// MUFA 17:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 687, 12000)]
    MUFA_17_1_Grams = 1323,

    /// <summary>
    /// PUFA 16:2
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 688, 13000)]
    PUFA_16_2_Grams = 1324,

    /// <summary>
    /// PUFA 20:3
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 689, 14400)]
    PUFA_20_3_Grams = 1325,

    /// <summary>
    /// Fatty acids, total sat., NLEA
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 690, 999999)]
    Fatty_acids_total_sat__NLEA_Grams = 1326,

    /// <summary>
    /// Fatty acids, total monounsat., NLEA
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 691, 999999)]
    Fatty_acids_total_monounsat__NLEA_Grams = 1327,

    /// <summary>
    /// Fatty acids, total polyunsat., NLEA
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 692, 999999)]
    Fatty_acids_total_polyunsat__NLEA_Grams = 1328,

    /// <summary>
    /// Fatty acids, total trans-monoenoic
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 693, 15500)]
    Fatty_acids_total_trans_monoenoic_Grams = 1329,

    /// <summary>
    /// Fatty acids, total trans-dienoic
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 694, 15601)]
    Fatty_acids_total_trans_dienoic_Grams = 1330,

    /// <summary>
    /// Fatty acids, total trans-polyenoic
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 695, 15619)]
    Fatty_acids_total_trans_polyenoic_Grams = 1331,

    /// <summary>
    /// SFA 13:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 696, 10400)]
    SFA_13_0_Grams = 1332,

    /// <summary>
    /// MUFA 15:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 697, 11600)]
    MUFA_15_1_Grams = 1333,

    /// <summary>
    /// PUFA 22:2
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 698, 15100)]
    PUFA_22_2_Grams = 1334,

    /// <summary>
    /// SFA 11:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 699, 10200)]
    SFA_11_0_Grams = 1335,

    /// <summary>
    /// ORAC, Hydrophyllic
    /// </summary>
    [Nutrients2Metadata(Measure.UMOL_TE, 706, -1)]
    ORAC_Hydrophyllic_UMOL_TE = 1336,

    /// <summary>
    /// ORAC, Lipophillic
    /// </summary>
    [Nutrients2Metadata(Measure.UMOL_TE, 707, -1)]
    ORAC_Lipophillic_UMOL_TE = 1337,

    /// <summary>
    /// ORAC, Total
    /// </summary>
    [Nutrients2Metadata(Measure.UMOL_TE, 708, -1)]
    ORAC_Total_UMOL_TE = 1338,

    /// <summary>
    /// Total Phenolics
    /// </summary>
    [Nutrients2Metadata(Measure.MG_GAE, 709, -1)]
    Total_Phenolics_MG_GAE = 1339,

    /// <summary>
    /// Daidzein
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 710, 19100)]
    Daidzein_Milligrams = 1340,

    /// <summary>
    /// Genistein
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 711, 19200)]
    Genistein_Milligrams = 1341,

    /// <summary>
    /// Glycitein
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 712, 19300)]
    Glycitein_Milligrams = 1342,

    /// <summary>
    /// Isoflavones
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 713, 19000)]
    Isoflavones_Milligrams = 1343,

    /// <summary>
    /// Biochanin A
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 714, 999999)]
    Biochanin_A_Milligrams = 1344,

    /// <summary>
    /// Formononetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 715, 999999)]
    Formononetin_Milligrams = 1345,

    /// <summary>
    /// Coumestrol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 716, 999999)]
    Coumestrol_Milligrams = 1346,

    /// <summary>
    /// Flavonoids, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 729, 999999)]
    Flavonoids_total_Milligrams = 1347,

    /// <summary>
    /// Anthocyanidins
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 730, 19400)]
    Anthocyanidins_Milligrams = 1348,

    /// <summary>
    /// Cyanidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 731, 19500)]
    Cyanidin_Milligrams = 1349,

    /// <summary>
    /// Proanthocyanidin (dimer-A linkage)
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 732, 19510)]
    Proanthocyanidin_dimer_A_linkage_Milligrams = 1350,

    /// <summary>
    /// Proanthocyanidin monomers
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 733, 19520)]
    Proanthocyanidin_monomers_Milligrams = 1351,

    /// <summary>
    /// Proanthocyanidin dimers
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 734, 19530)]
    Proanthocyanidin_dimers_Milligrams = 1352,

    /// <summary>
    /// Proanthocyanidin trimers
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 735, 19540)]
    Proanthocyanidin_trimers_Milligrams = 1353,

    /// <summary>
    /// Proanthocyanidin 4-6mers
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 736, 19550)]
    Proanthocyanidin_4_6mers_Milligrams = 1354,

    /// <summary>
    /// Proanthocyanidin 7-10mers
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 737, 19560)]
    Proanthocyanidin_7_10mers_Milligrams = 1355,

    /// <summary>
    /// Proanthocyanidin polymers (>10mers)
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 738, 19570)]
    Proanthocyanidin_polymers__10mers_Milligrams = 1356,

    /// <summary>
    /// Delphinidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 741, 19600)]
    Delphinidin_Milligrams = 1357,

    /// <summary>
    /// Malvidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 742, 19700)]
    Malvidin_Milligrams = 1358,

    /// <summary>
    /// Pelargonidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 743, 19800)]
    Pelargonidin_Milligrams = 1359,

    /// <summary>
    /// Peonidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 745, 19900)]
    Peonidin_Milligrams = 1360,

    /// <summary>
    /// Petunidin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 746, 20000)]
    Petunidin_Milligrams = 1361,

    /// <summary>
    /// Flavans, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 747, 20100)]
    Flavans_total_Milligrams = 1362,

    /// <summary>
    /// Catechins, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 748, 20200)]
    Catechins_total_Milligrams = 1363,

    /// <summary>
    /// Catechin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 749, 20300)]
    Catechin_Milligrams = 1364,

    /// <summary>
    /// Epigallocatechin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 750, 20400)]
    Epigallocatechin_Milligrams = 1365,

    /// <summary>
    /// Epicatechin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 751, 20500)]
    Epicatechin_Milligrams = 1366,

    /// <summary>
    /// Epicatechin-3-gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 752, 20600)]
    Epicatechin_3_gallate_Milligrams = 1367,

    /// <summary>
    /// Epigallocatechin-3-gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 753, 20700)]
    Epigallocatechin_3_gallate_Milligrams = 1368,

    /// <summary>
    /// Procyanidins, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 754, 20800)]
    Procyanidins_total_Milligrams = 1369,

    /// <summary>
    /// Theaflavins
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 755, 20900)]
    Theaflavins_Milligrams = 1370,

    /// <summary>
    /// Thearubigins
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 756, 21000)]
    Thearubigins_Milligrams = 1371,

    /// <summary>
    /// Flavanones, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 757, 21200)]
    Flavanones_total_Milligrams = 1372,

    /// <summary>
    /// Eriodictyol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 758, 21300)]
    Eriodictyol_Milligrams = 1373,

    /// <summary>
    /// Hesperetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 759, 21400)]
    Hesperetin_Milligrams = 1374,

    /// <summary>
    /// Isosakuranetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 760, 21500)]
    Isosakuranetin_Milligrams = 1375,

    /// <summary>
    /// Liquiritigenin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 761, 21600)]
    Liquiritigenin_Milligrams = 1376,

    /// <summary>
    /// Naringenin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 762, 21700)]
    Naringenin_Milligrams = 1377,

    /// <summary>
    /// Flavones, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 768, 21800)]
    Flavones_total_Milligrams = 1378,

    /// <summary>
    /// Apigenin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 770, 21900)]
    Apigenin_Milligrams = 1379,

    /// <summary>
    /// Chrysoeriol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 771, 22000)]
    Chrysoeriol_Milligrams = 1380,

    /// <summary>
    /// Diosmetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 772, 22100)]
    Diosmetin_Milligrams = 1381,

    /// <summary>
    /// Luteolin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 773, 22200)]
    Luteolin_Milligrams = 1382,

    /// <summary>
    /// Nobiletin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 781, 22300)]
    Nobiletin_Milligrams = 1383,

    /// <summary>
    /// Sinensetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 782, 22400)]
    Sinensetin_Milligrams = 1384,

    /// <summary>
    /// Tangeretin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 783, 22500)]
    Tangeretin_Milligrams = 1385,

    /// <summary>
    /// Flavonols, total
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 784, 22600)]
    Flavonols_total_Milligrams = 1386,

    /// <summary>
    /// Isorhamnetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 785, 22700)]
    Isorhamnetin_Milligrams = 1387,

    /// <summary>
    /// Kaempferol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 786, 22800)]
    Kaempferol_Milligrams = 1388,

    /// <summary>
    /// Limocitrin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 787, 22900)]
    Limocitrin_Milligrams = 1389,

    /// <summary>
    /// Myricetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 788, 23000)]
    Myricetin_Milligrams = 1390,

    /// <summary>
    /// Quercetin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 789, 23100)]
    Quercetin_Milligrams = 1391,

    /// <summary>
    /// Theogallin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 790, 21100)]
    Theogallin_Milligrams = 1392,

    /// <summary>
    /// Theaflavin -3,3' -digallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 791, -1)]
    Theaflavin_3_3__digallate_Milligrams = 1393,

    /// <summary>
    /// Theaflavin -3' -gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 792, -1)]
    Theaflavin_3__gallate_Milligrams = 1394,

    /// <summary>
    /// Theaflavin -3 -gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 793, -1)]
    Theaflavin_3_gallate_Milligrams = 1395,

    /// <summary>
    /// (+) -Gallo catechin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 794, -1)]
    Gallo_catechin_Milligrams = 1396,

    /// <summary>
    /// (+)-Catechin 3-gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 795, -1)]
    Catechin_3_gallate_Milligrams = 1397,

    /// <summary>
    /// (+)-Gallocatechin 3-gallate
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 796, -1)]
    Gallocatechin_3_gallate_Milligrams = 1398,

    /// <summary>
    /// Mannose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 801, 999999)]
    Mannose_Grams = 1399,

    /// <summary>
    /// Triose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 803, 999999)]
    Triose_Grams = 1400,

    /// <summary>
    /// Tetrose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 804, 999999)]
    Tetrose_Grams = 1401,

    /// <summary>
    /// Other Saccharides
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 805, 999999)]
    Other_Saccharides_Grams = 1402,

    /// <summary>
    /// Inulin
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 806, 999999)]
    Inulin_Grams = 1403,

    /// <summary>
    /// PUFA 18:3 n-3 c,c,c (ALA)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 851, 14000)]
    PUFA_18_3_n_3_c_c_c_ALA_Grams = 1404,

    /// <summary>
    /// PUFA 20:3 n-3
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 852, 14500)]
    PUFA_20_3_n_3_Grams = 1405,

    /// <summary>
    /// PUFA 20:3 n-6
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 853, 14600)]
    PUFA_20_3_n_6_Grams = 1406,

    /// <summary>
    /// PUFA 20:4 n-3
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 854, 14800)]
    PUFA_20_4_n_3_Grams = 1407,

    /// <summary>
    /// PUFA 20:4 n-6
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 855, 14900)]
    PUFA_20_4_n_6_Grams = 1408,

    /// <summary>
    /// PUFA 18:3i
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 856, 14200)]
    PUFA_18_3i_Grams = 1409,

    /// <summary>
    /// PUFA 21:5
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 857, 15100)]
    PUFA_21_5_Grams = 1410,

    /// <summary>
    /// PUFA 22:4
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 858, 15160)]
    PUFA_22_4_Grams = 1411,

    /// <summary>
    /// MUFA 18:1-11 t (18:1t n-7)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 859, 12310)]
    MUFA_18_1_11_t_18_1t_n_7_Grams = 1412,

    /// <summary>
    /// MUFA 18:1-11 c (18:1c n-7)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 860, 12210)]
    MUFA_18_1_11_c_18_1c_n_7_Grams = 1413,

    /// <summary>
    /// PUFA 20:3 n-9
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 861, 14650)]
    PUFA_20_3_n_9_Grams = 1414,

    /// <summary>
    /// Total Sugars
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 269, 1510)]
    Total_Sugars_Grams = 2000,

    /// <summary>
    /// SFA 5:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 632, 9850)]
    SFA_5_0_Grams = 2003,

    /// <summary>
    /// SFA 7:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 633, 9950)]
    SFA_7_0_Grams = 2004,

    /// <summary>
    /// SFA 9:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 634, 10050)]
    SFA_9_0_Grams = 2005,

    /// <summary>
    /// SFA 21:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 681, 11150)]
    SFA_21_0_Grams = 2006,

    /// <summary>
    /// SFA 23:0
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 682, 11250)]
    SFA_23_0_Grams = 2007,

    /// <summary>
    /// MUFA 12:1
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 635, 11450)]
    MUFA_12_1_Grams = 2008,

    /// <summary>
    /// MUFA 14:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 822, 11501)]
    MUFA_14_1_c_Grams = 2009,

    /// <summary>
    /// MUFA 17:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 825, 12001)]
    MUFA_17_1_c_Grams = 2010,

    /// <summary>
    /// TFA 17:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 826, 15525)]
    TFA_17_1_t_Grams = 2011,

    /// <summary>
    /// MUFA 20:1 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 829, 12401)]
    MUFA_20_1_c_Grams = 2012,

    /// <summary>
    /// TFA 20:1 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 830, 15540)]
    TFA_20_1_t_Grams = 2013,

    /// <summary>
    /// MUFA 22:1 n-9
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 676.1, 12601)]
    MUFA_22_1_n_9_Grams = 2014,

    /// <summary>
    /// MUFA 22:1 n-11
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 676.2, 12602)]
    MUFA_22_1_n_11_Grams = 2015,

    /// <summary>
    /// PUFA 18:2 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 831, 13150)]
    PUFA_18_2_c_Grams = 2016,

    /// <summary>
    /// TFA 18:2 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 832, 15611)]
    TFA_18_2_t_Grams = 2017,

    /// <summary>
    /// PUFA 18:3 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 833, 13910)]
    PUFA_18_3_c_Grams = 2018,

    /// <summary>
    /// TFA 18:3 t
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 834, 15660)]
    TFA_18_3_t_Grams = 2019,

    /// <summary>
    /// PUFA 20:3 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 835, 14450)]
    PUFA_20_3_c_Grams = 2020,

    /// <summary>
    /// PUFA 22:3
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 683, 14675)]
    PUFA_22_3_Grams = 2021,

    /// <summary>
    /// PUFA 20:4c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 836, 14750)]
    PUFA_20_4c_Grams = 2022,

    /// <summary>
    /// PUFA 20:5c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 837, 14950)]
    PUFA_20_5c_Grams = 2023,

    /// <summary>
    /// PUFA 22:5 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 838, 15150)]
    PUFA_22_5_c_Grams = 2024,

    /// <summary>
    /// PUFA 22:6 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 839, 15250)]
    PUFA_22_6_c_Grams = 2025,

    /// <summary>
    /// PUFA 20:2 c
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 840, 14250)]
    PUFA_20_2_c_Grams = 2026,

    /// <summary>
    /// Proximate
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 200, 999999)]
    Proximate_Grams = 2027,

    /// <summary>
    /// trans-beta-Carotene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 321.2, 7444)]
    trans_beta_Carotene_Micrograms = 2028,

    /// <summary>
    /// trans-Lycopene
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 337.2, 7534)]
    trans_Lycopene_Micrograms = 2029,

    /// <summary>
    /// Cryptoxanthin, alpha
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 335, 7461)]
    Cryptoxanthin_alpha_Micrograms = 2032,

    /// <summary>
    /// Total dietary fiber (AOAC 2011.25)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 293, 1300)]
    Total_dietary_fiber_AOAC_2011_25_Grams = 2033,

    /// <summary>
    /// Insoluble dietary fiber (IDF)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 293.1, 1310)]
    Insoluble_dietary_fiber_IDF_Grams = 2034,

    /// <summary>
    /// Soluble dietary fiber (SDFP+SDFS)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 293.2, 1320)]
    Soluble_dietary_fiber_SDFP_SDFS_Grams = 2035,

    /// <summary>
    /// Soluble dietary fiber (SDFP)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 954, 1324)]
    Soluble_dietary_fiber_SDFP_Grams = 2036,

    /// <summary>
    /// Soluble dietary fiber (SDFS)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 953, 1326)]
    Soluble_dietary_fiber_SDFS_Grams = 2037,

    /// <summary>
    /// High Molecular Weight Dietary Fiber (HMWDF)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 293.3, 1305)]
    High_Molecular_Weight_Dietary_Fiber_HMWDF_Grams = 2038,

    /// <summary>
    /// Carbohydrates
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 956, 1100)]
    Carbohydrates_Grams = 2039,

    /// <summary>
    /// Other carotenoids
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 955, 7510)]
    Other_carotenoids_Micrograms = 2040,

    /// <summary>
    /// Tocopherols and tocotrienols
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 323.99, 7900)]
    Tocopherols_and_tocotrienols_Milligrams = 2041,

    /// <summary>
    /// Amino acids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 500, 16250)]
    Amino_acids_Grams = 2042,

    /// <summary>
    /// Minerals
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 300, 5200)]
    Minerals_Milligrams = 2043,

    /// <summary>
    /// Lipids
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 950, 9600)]
    Lipids_Grams = 2044,

    /// <summary>
    /// Proximates
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 951, 50)]
    Proximates_Grams = 2045,

    /// <summary>
    /// Vitamins and Other Components
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 952, 6250)]
    Vitamins_and_Other_Components_Grams = 2046,

    /// <summary>
    /// Total Tocopherols
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 7901)]
    Total_Tocopherols_Milligrams = 2055,

    /// <summary>
    /// Total Tocotrienols
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 7902)]
    Total_Tocotrienols_Milligrams = 2054,

    /// <summary>
    /// Stigmastadiene
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 15801)]
    Stigmastadiene_Milligrams = 2053,

    /// <summary>
    /// Delta-7-Stigmastenol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 16226)]
    Delta_7_Stigmastenol_Milligrams = 2052,

    /// <summary>
    /// Daidzin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 717, 19310)]
    Daidzin_Milligrams = 2049,

    /// <summary>
    /// Genistin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 718, 19320)]
    Genistin_Milligrams = 2050,

    /// <summary>
    /// Glycitin
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 719, 19330)]
    Glycitin_Milligrams = 2051,

    /// <summary>
    /// Ergothioneine
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 18500)]
    Ergothioneine_Milligrams = 2057,

    /// <summary>
    /// Beta-glucan
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, -1, 1327)]
    Beta_glucan_Grams = 2058,

    /// <summary>
    /// Vitamin D4
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, -1, 8730)]
    Vitamin_D4_Micrograms = 2059,

    /// <summary>
    /// Ergosta-7-enol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 16210)]
    Ergosta_7_enol_Milligrams = 2060,

    /// <summary>
    /// Ergosta-7,22-dienol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 16211)]
    Ergosta_7_22_dienol_Milligrams = 2061,

    /// <summary>
    /// Ergosta-5,7-dienol
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 16211)]
    Ergosta_5_7_dienol_Milligrams = 2062,

    /// <summary>
    /// Verbascose
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, -1, 2450)]
    Verbascose_Grams = 2063,

    /// <summary>
    /// Oligosaccharides
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, -1, 2250)]
    Oligosaccharides_Milligrams = 2064,

    /// <summary>
    /// Low Molecular Weight Dietary Fiber (LMWDF)
    /// </summary>
    [Nutrients2Metadata(Measure.Grams, 293.4, 1306)]
    Low_Molecular_Weight_Dietary_Fiber_LMWDF_Grams = 2065,

    /// <summary>
    /// Vitamin E
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 959, 7810)]
    Vitamin_E_Milligrams = 2068,

    /// <summary>
    /// Vitamin A
    /// </summary>
    [Nutrients2Metadata(Measure.Micrograms, 960, 7430)]
    Vitamin_A_Micrograms = 2067,

    /// <summary>
    /// Glutathione
    /// </summary>
    [Nutrients2Metadata(Measure.Milligrams, 961, 9000)]
    Glutathione_Milligrams = 2069,

}

