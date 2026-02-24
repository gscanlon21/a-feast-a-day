using System.Reflection;

namespace Core.Models.User;

[AttributeUsage(AttributeTargets.Field)]
public class NutrientMetadataAttribute : Attribute
{
    public Measure Measure { get; }
    public double? NutrientNumber { get; }
    public double? Rank { get; }

    public NutrientMetadataAttribute(Measure measure, double nutrientNumber, double rank)
    {
        Measure = measure;
        NutrientNumber = nutrientNumber >= 0 ? nutrientNumber : null;
        Rank = rank >= 0 ? rank : null;
    }
}


/// <summary>
/// Non-Flagged Nutrients.
/// https://ods.od.nih.gov/HealthInformation/nutrientrecommendations.aspx
/// https://www.dietaryguidelines.gov/resources/2020-2025-dietary-guidelines-online-materials
/// </summary>
public enum Nutrients2
{
    [NutrientMetadata(Measure.KCalorie, 957, 280.0)]
    Energy__Atwater_General_Factors = 2047,
    
    [NutrientMetadata(Measure.KCalorie, 958, 290.0)]
    Energy__Atwater_Specific_Factors = 2048,
    
    [NutrientMetadata(Measure.Grams, 201, 200.0)]
    Solids = 1001,
    
    [NutrientMetadata(Measure.Grams, 202, 500.0)]
    Nitrogen = 1002,
    
    [NutrientMetadata(Measure.Grams, 203, 600.0)]
    Protein = 1003,
    
    [NutrientMetadata(Measure.Grams, 204, 800.0)]
    Total_lipid__fat = 1004,
    
    [NutrientMetadata(Measure.Grams, 205, 1110.0)]
    Carbohydrate__by_difference = 1005,
    
    [NutrientMetadata(Measure.Grams, 206, 999999.0)]
    Fiber__crude__DO_NOT_USE___Archived = 1006,
    
    [NutrientMetadata(Measure.Grams, 207, 1000.0)]
    Ash = 1007,
    
    [NutrientMetadata(Measure.KCalorie, 208, 300.0)]
    Energy = 1008,
    
    [NutrientMetadata(Measure.Grams, 209, 2200.0)]
    Starch = 1009,
    
    [NutrientMetadata(Measure.Grams, 210, 1600.0)]
    Sucrose = 1010,
    
    [NutrientMetadata(Measure.Grams, 211, 1700.0)]
    Glucose = 1011,
    
    [NutrientMetadata(Measure.Grams, 212, 1800.0)]
    Fructose = 1012,
    
    [NutrientMetadata(Measure.Grams, 213, 1900.0)]
    Lactose = 1013,
    
    [NutrientMetadata(Measure.Grams, 214, 2000.0)]
    Maltose = 1014,
    
    [NutrientMetadata(Measure.Grams, 218, 999999.0)]
    Amylose = 1015,
    
    [NutrientMetadata(Measure.Grams, 219, 999999.0)]
    Amylopectin = 1016,
    
    [NutrientMetadata(Measure.Grams, 220, 999999.0)]
    Pectin = 1017,
    
    [NutrientMetadata(Measure.Grams, 221, 18200.0)]
    Alcohol__ethyl = 1018,
    
    [NutrientMetadata(Measure.Grams, 222, 999999.0)]
    Pentosan = 1019,
    
    [NutrientMetadata(Measure.Grams, 223, 999999.0)]
    Pentoses = 1020,
    
    [NutrientMetadata(Measure.Grams, 224, 999999.0)]
    Hemicellulose = 1021,
    
    [NutrientMetadata(Measure.Grams, 225, 999999.0)]
    Cellulose = 1022,
    
    [NutrientMetadata(Measure.PH, 226, 999999.0)]
    pH = 1023,
    
    [NutrientMetadata(Measure.SpecificGravity, 227, 8955)]
    Specific_Gravity = 1024,
    
    [NutrientMetadata(Measure.Grams, 229, 2850.0)]
    Organic_acids = 1025,
    
    [NutrientMetadata(Measure.Milligrams, 230, 2900.0)]
    Acetic_acid = 1026,
    
    [NutrientMetadata(Measure.Milligrams, 231, 3000.0)]
    Aconitic_acid = 1027,
    
    [NutrientMetadata(Measure.Milligrams, 232, 3100.0)]
    Benzoic_acid = 1028,
    
    [NutrientMetadata(Measure.Milligrams, 233, 3200.0)]
    Chelidonic_acid = 1029,
    
    [NutrientMetadata(Measure.Milligrams, 234, 3300.0)]
    Chlorogenic_acid = 1030,
    
    [NutrientMetadata(Measure.Milligrams, 235, 3400.0)]
    Cinnamic_acid = 1031,
    
    [NutrientMetadata(Measure.Milligrams, 236, 3500.0)]
    Citric_acid = 1032,
    
    [NutrientMetadata(Measure.Milligrams, 237, 3600.0)]
    Fumaric_acid = 1033,
    
    [NutrientMetadata(Measure.Milligrams, 238, 3700.0)]
    Galacturonic_acid = 1034,
    
    [NutrientMetadata(Measure.Milligrams, 239, 3800.0)]
    Gallic_acid = 1035,
    
    [NutrientMetadata(Measure.Milligrams, 240, 3900.0)]
    Glycolic_acid = 1036,
    
    [NutrientMetadata(Measure.Milligrams, 241, 4000.0)]
    Isocitric_acid = 1037,
    
    [NutrientMetadata(Measure.Milligrams, 242, 4100.0)]
    Lactic_acid = 1038,
    
    [NutrientMetadata(Measure.Milligrams, 243, 4200.0)]
    Malic_acid = 1039,
    
    [NutrientMetadata(Measure.Milligrams, 244, 4300.0)]
    Oxaloacetic_acid = 1040,
    
    [NutrientMetadata(Measure.Milligrams, 245, 4400.0)]
    Oxalic_acid = 1041,
    
    [NutrientMetadata(Measure.Milligrams, 246, 4500.0)]
    Phytic_acid = 1042,
    
    [NutrientMetadata(Measure.Milligrams, 247, 4600.0)]
    Pyruvic_acid = 1043,
    
    [NutrientMetadata(Measure.Milligrams, 248, 4700.0)]
    Quinic_acid = 1044,
    
    [NutrientMetadata(Measure.Milligrams, 249, 4800.0)]
    Salicylic_acid = 1045,
    
    [NutrientMetadata(Measure.Milligrams, 250, 4900.0)]
    Succinic_acid = 1046,
    
    [NutrientMetadata(Measure.Milligrams, 251, 5000.0)]
    Tartaric_acid = 1047,
    
    [NutrientMetadata(Measure.Milligrams, 252, 5100.0)]
    Ursolic_acid = 1048,
    
    [NutrientMetadata(Measure.Grams, 253, 999999.0)]
    Solids__non_fat = 1049,
    
    [NutrientMetadata(Measure.Grams, 205.2, 1120.0)]
    Carbohydrate__by_summation = 1050,
    
    [NutrientMetadata(Measure.Grams, 255, 100.0)]
    Water = 1051,
    
    [NutrientMetadata(Measure.Grams, 256, 999999.0)]
    Adjusted_Nitrogen = 1052,
    
    [NutrientMetadata(Measure.Grams, 257, 700.0)]
    Adjusted_Protein = 1053,
    
    [NutrientMetadata(Measure.Grams, 259, 999999.0)]
    Piperine = 1054,
    
    [NutrientMetadata(Measure.Grams, 260, 2500.0)]
    Mannitol = 1055,
    
    [NutrientMetadata(Measure.Grams, 261, 2600.0)]
    Sorbitol = 1056,
    
    [NutrientMetadata(Measure.Milligrams, 262, 18300.0)]
    Caffeine = 1057,
    
    [NutrientMetadata(Measure.Milligrams, 263, 18400.0)]
    Theobromine = 1058,
    
    [NutrientMetadata(Measure.Milligrams, 264, 999999.0)]
    Nitrates = 1059,
    
    [NutrientMetadata(Measure.Milligrams, 265, 999999.0)]
    Nitrites = 1060,
    
    [NutrientMetadata(Measure.Milligrams, 266, 999999.0)]
    Nitrosamine_total = 1061,
    
    [NutrientMetadata(Measure.KiloJoule, 268, 400.0)]
    Energy2 = 1062,
    
    [NutrientMetadata(Measure.Grams, 269.3, 1500.0)]
    Sugars__Total = 1063,
    
    [NutrientMetadata(Measure.Grams, 271, 999999.0)]
    Solids__soluble = 1064,
    
    [NutrientMetadata(Measure.Grams, 272, 999999.0)]
    Glycogen = 1065,
    
    [NutrientMetadata(Measure.Grams, 273, 999999.0)]
    Fiber__neutral_detergent__DO_NOT_USE___Archived = 1066,
    
    [NutrientMetadata(Measure.Grams, 274, 999999.0)]
    Reducing_sugars = 1067,
    
    [NutrientMetadata(Measure.Grams, 276, 999999.0)]
    Beta_glucans = 1068,
    
    [NutrientMetadata(Measure.Grams, 281, 999999.0)]
    Oligosaccharides = 1069,
    
    [NutrientMetadata(Measure.Grams, 282, 999999.0)]
    Nonstarch_polysaccharides = 1070,
    
    [NutrientMetadata(Measure.Grams, 283, 2225)]
    Resistant_starch = 1071,
    
    [NutrientMetadata(Measure.Grams, 284, -1)]
    Carbohydrate__other = 1072,
    
    [NutrientMetadata(Measure.Grams, 285, 999999.0)]
    Arabinose = 1073,
    
    [NutrientMetadata(Measure.Grams, 286, 999999.0)]
    Xylose = 1074,
    
    [NutrientMetadata(Measure.Grams, 287, 2100.0)]
    Galactose = 1075,
    
    [NutrientMetadata(Measure.Grams, 288, 2300.0)]
    Raffinose = 1076,
    
    [NutrientMetadata(Measure.Grams, 289, 2400.0)]
    Stachyose = 1077,
    
    [NutrientMetadata(Measure.Grams, 290, 2700.0)]
    Xylitol = 1078,
    
    [NutrientMetadata(Measure.Grams, 291, 1200.0)]
    Fiber__total_dietary = 1079,
    
    [NutrientMetadata(Measure.Grams, 292, 999999.0)]
    Lignin = 1080,
    
    [NutrientMetadata(Measure.Grams, 294, 999999.0)]
    Ribose = 1081,
    
    [NutrientMetadata(Measure.Grams, 295, 1240.0)]
    Fiber__soluble = 1082,
    
    [NutrientMetadata(Measure.Milligrams, 296, 999999.0)]
    Theophylline = 1083,
    
    [NutrientMetadata(Measure.Grams, 297, 1260.0)]
    Fiber__insoluble = 1084,
    
    [NutrientMetadata(Measure.Grams, 298, 900.0)]
    Total_fat__NLEA = 1085,
    
    [NutrientMetadata(Measure.Grams, 299, 999999.0)]
    Total_sugar_alcohols = 1086,
    
    [NutrientMetadata(Measure.Milligrams, 301, 5300.0)]
    Calcium__Ca = 1087,
    
    [NutrientMetadata(Measure.Milligrams, 302, 999999.0)]
    Chlorine__Cl = 1088,
    
    [NutrientMetadata(Measure.Milligrams, 303, 5400.0)]
    Iron__Fe = 1089,
    
    [NutrientMetadata(Measure.Milligrams, 304, 5500.0)]
    Magnesium__Mg = 1090,
    
    [NutrientMetadata(Measure.Milligrams, 305, 5600.0)]
    Phosphorus__P = 1091,
    
    [NutrientMetadata(Measure.Milligrams, 306, 5700.0)]
    Potassium__K = 1092,
    
    [NutrientMetadata(Measure.Milligrams, 307, 5800.0)]
    Sodium__Na = 1093,
    
    [NutrientMetadata(Measure.Milligrams, 308, 6241.0)]
    Sulfur__S = 1094,
    
    [NutrientMetadata(Measure.Milligrams, 309, 5900.0)]
    Zinc__Zn = 1095,
    
    [NutrientMetadata(Measure.Micrograms, 310, 999999.0)]
    Chromium__Cr = 1096,
    
    [NutrientMetadata(Measure.Micrograms, 311, 6244.0)]
    Cobalt__Co = 1097,
    
    [NutrientMetadata(Measure.Milligrams, 312, 6000.0)]
    Copper__Cu = 1098,
    
    [NutrientMetadata(Measure.Micrograms, 313, 6240.0)]
    Fluoride__F = 1099,
    
    [NutrientMetadata(Measure.Micrograms, 314, 6150.0)]
    Iodine__I = 1100,
    
    [NutrientMetadata(Measure.Milligrams, 315, 6100.0)]
    Manganese__Mn = 1101,
    
    [NutrientMetadata(Measure.Micrograms, 316, 6243.0)]
    Molybdenum__Mo = 1102,
    
    [NutrientMetadata(Measure.Micrograms, 317, 6200.0)]
    Selenium__Se = 1103,
    
    [NutrientMetadata(Measure.IU, 318, 7500.0)]
    Vitamin_A__IU = 1104,
    
    [NutrientMetadata(Measure.Micrograms, 319, 7430.0)]
    Retinol = 1105,
    
    [NutrientMetadata(Measure.Micrograms, 320, 7420.0)]
    Vitamin_A__RAE = 1106,
    
    [NutrientMetadata(Measure.Micrograms, 321, 7440.0)]
    Carotene__beta = 1107,
    
    [NutrientMetadata(Measure.Micrograms, 322, 7450.0)]
    Carotene__alpha = 1108,
    
    [NutrientMetadata(Measure.Milligrams, 323, 7905.0)]
    Vitamin_E__alpha_tocopherol = 1109,
    
    [NutrientMetadata(Measure.IU, 324, 8650.0)]
    Vitamin_D__D2___D3___International_Units = 1110,
    
    [NutrientMetadata(Measure.Micrograms, 325, 8710.0)]
    Vitamin_D2__ergocalciferol = 1111,
    
    [NutrientMetadata(Measure.Micrograms, 326, 8720.0)]
    Vitamin_D3__cholecalciferol = 1112,
    
    [NutrientMetadata(Measure.Micrograms, 327, 8730.0)]
    _25_hydroxycholecalciferol = 1113,
    
    [NutrientMetadata(Measure.Micrograms, 328, 8700.0)]
    Vitamin_D__D2___D3 = 1114,
    
    [NutrientMetadata(Measure.Micrograms, 329, 8740.0)]
    _25_hydroxyergocalciferol = 1115,
    
    [NutrientMetadata(Measure.Micrograms, 330, 7570.0)]
    Phytoene = 1116,
    
    [NutrientMetadata(Measure.Micrograms, 331, 7580.0)]
    Phytofluene = 1117,
    
    [NutrientMetadata(Measure.Micrograms, 332, 7455.0)]
    Carotene__gamma = 1118,
    
    [NutrientMetadata(Measure.Micrograms, 338.2, 7564.0)]
    Zeaxanthin = 1119,
    
    [NutrientMetadata(Measure.Micrograms, 334, 7460.0)]
    Cryptoxanthin__beta = 1120,
    
    [NutrientMetadata(Measure.Micrograms, 338.1, 7562.0)]
    Lutein = 1121,
    
    [NutrientMetadata(Measure.Micrograms, 337, 7530.0)]
    Lycopene = 1122,
    
    [NutrientMetadata(Measure.Micrograms, 338, 7560.0)]
    Lutein___zeaxanthin = 1123,
    
    [NutrientMetadata(Measure.IU, 340, 999999.0)]
    Vitamin_E__label_entry_primarily = 1124,
    
    [NutrientMetadata(Measure.Milligrams, 341, 8000.0)]
    Tocopherol__beta = 1125,
    
    [NutrientMetadata(Measure.Milligrams, 342, 8100.0)]
    Tocopherol__gamma = 1126,
    
    [NutrientMetadata(Measure.Milligrams, 343, 8200.0)]
    Tocopherol__delta = 1127,
    
    [NutrientMetadata(Measure.Milligrams, 344, 8300.0)]
    Tocotrienol__alpha = 1128,
    
    [NutrientMetadata(Measure.Milligrams, 345, 8400.0)]
    Tocotrienol__beta = 1129,
    
    [NutrientMetadata(Measure.Milligrams, 346, 8500.0)]
    Tocotrienol__gamma = 1130,
    
    [NutrientMetadata(Measure.Milligrams, 347, 8600.0)]
    Tocotrienol__delta = 1131,
    
    [NutrientMetadata(Measure.Micrograms, 348, 999999.0)]
    Aluminum__Al = 1132,
    
    [NutrientMetadata(Measure.Micrograms, 349, 999999.0)]
    Antimony__Sb = 1133,
    
    [NutrientMetadata(Measure.Micrograms, 350, 999999.0)]
    Arsenic__As = 1134,
    
    [NutrientMetadata(Measure.Micrograms, 351, 999999.0)]
    Barium__Ba = 1135,
    
    [NutrientMetadata(Measure.Micrograms, 352, 999999.0)]
    Beryllium__Be = 1136,
    
    [NutrientMetadata(Measure.Micrograms, 354, 6245.0)]
    Boron__B = 1137,
    
    [NutrientMetadata(Measure.Micrograms, 355, 999999.0)]
    Bromine__Br = 1138,
    
    [NutrientMetadata(Measure.Micrograms, 356, 999999.0)]
    Cadmium__Cd = 1139,
    
    [NutrientMetadata(Measure.Micrograms, 363, 999999.0)]
    Gold__Au = 1140,
    
    [NutrientMetadata(Measure.Milligrams, 364, 999999.0)]
    Iron__heme = 1141,
    
    [NutrientMetadata(Measure.Milligrams, 365, 999999.0)]
    Iron__non_heme = 1142,
    
    [NutrientMetadata(Measure.Micrograms, 367, 999999.0)]
    Lead__Pb = 1143,
    
    [NutrientMetadata(Measure.Micrograms, 368, 999999.0)]
    Lithium__Li = 1144,
    
    [NutrientMetadata(Measure.Micrograms, 370, 999999.0)]
    Mercury__Hg = 1145,
    
    [NutrientMetadata(Measure.Micrograms, 371, 6242.0)]
    Nickel__Ni = 1146,
    
    [NutrientMetadata(Measure.Micrograms, 373, 999999.0)]
    Rubidium__Rb = 1147,
    
    [NutrientMetadata(Measure.Micrograms, 374, 6250.0)]
    Fluoride___DO_NOT_USE__use_313 = 1148,
    
    [NutrientMetadata(Measure.Milligrams, 375, 999999.0)]
    Salt__NaCl = 1149,
    
    [NutrientMetadata(Measure.Micrograms, 378, 999999.0)]
    Silicon__Si = 1150,
    
    [NutrientMetadata(Measure.Micrograms, 379, 999999.0)]
    Silver__Ag = 1151,
    
    [NutrientMetadata(Measure.Micrograms, 380, 999999.0)]
    Strontium__Sr = 1152,
    
    [NutrientMetadata(Measure.Micrograms, 385, 999999.0)]
    Tin__Sn = 1153,
    
    [NutrientMetadata(Measure.Micrograms, 386, 999999.0)]
    Titanium__Ti = 1154,
    
    [NutrientMetadata(Measure.Micrograms, 389, 999999.0)]
    Vanadium__V = 1155,
    
    [NutrientMetadata(Measure.MCG_RE, 392, 7500.0)]
    Vitamin_A__RE = 1156,
    
    [NutrientMetadata(Measure.MCG_RE, 393, 7600.0)]
    Carotene = 1157,
    
    [NutrientMetadata(Measure.MG_ATE, 394, 7800.0)]
    Vitamin_E = 1158,
    
    [NutrientMetadata(Measure.Micrograms, 321.1, 7442.0)]
    cis_beta_Carotene = 1159,
    
    [NutrientMetadata(Measure.Micrograms, 337.1, 7532.0)]
    cis_Lycopene = 1160,
    
    [NutrientMetadata(Measure.Micrograms, 338.3, 7561.0)]
    cis_Lutein_Zeaxanthin = 1161,
    
    [NutrientMetadata(Measure.Milligrams, 401, 6300.0)]
    Vitamin_C__total_ascorbic_acid = 1162,
    
    [NutrientMetadata(Measure.Milligrams, 402, 999999.0)]
    Vitamin_C__reduced_ascorbic_acid = 1163,
    
    [NutrientMetadata(Measure.Milligrams, 403, 999999.0)]
    Vitamin_C__dehydro_ascorbic_acid = 1164,
    
    [NutrientMetadata(Measure.Milligrams, 404, 6400.0)]
    Thiamin = 1165,
    
    [NutrientMetadata(Measure.Milligrams, 405, 6500.0)]
    Riboflavin = 1166,
    
    [NutrientMetadata(Measure.Milligrams, 406, 6600.0)]
    Niacin = 1167,
    
    [NutrientMetadata(Measure.Milligrams, 407, 999999.0)]
    Niacin_from_tryptophan__determined = 1168,
    
    [NutrientMetadata(Measure.Milligrams, 409, 999999.0)]
    Niacin_equivalent_N406__N407 = 1169,
    
    [NutrientMetadata(Measure.Milligrams, 410, 6700.0)]
    Pantothenic_acid = 1170,
    
    [NutrientMetadata(Measure.Milligrams, 411, 999999.0)]
    Vitamin_B_6__pyridoxine__alcohol_form = 1171,
    
    [NutrientMetadata(Measure.Milligrams, 412, 999999.0)]
    Vitamin_B_6__pyridoxal__aldehyde_form = 1172,
    
    [NutrientMetadata(Measure.Milligrams, 413, 999999.0)]
    Vitamin_B_6__pyridoxamine__amine_form = 1173,
    
    [NutrientMetadata(Measure.Milligrams, 414, 999999.0)]
    Vitamin_B_6__N411___N412__N413 = 1174,
    
    [NutrientMetadata(Measure.Milligrams, 415, 6800.0)]
    Vitamin_B_6 = 1175,
    
    [NutrientMetadata(Measure.Micrograms, 416, 6850.0)]
    Biotin = 1176,
    
    [NutrientMetadata(Measure.Micrograms, 417, 6900.0)]
    Folate__total = 1177,
    
    [NutrientMetadata(Measure.Micrograms, 418, 7300.0)]
    Vitamin_B_12 = 1178,
    
    [NutrientMetadata(Measure.Micrograms, 419, 999999.0)]
    Folate__free = 1179,
    
    [NutrientMetadata(Measure.Milligrams, 421, 7220.0)]
    Choline__total = 1180,
    
    [NutrientMetadata(Measure.Milligrams, 422, 2800.0)]
    Inositol = 1181,
    
    [NutrientMetadata(Measure.Milligrams, 423, 999999.0)]
    Inositol_phosphate = 1182,
    
    [NutrientMetadata(Measure.Micrograms, 428, 8950.0)]
    Vitamin_K__Menaquinone_4 = 1183,
    
    [NutrientMetadata(Measure.Micrograms, 429, 8900.0)]
    Vitamin_K__Dihydrophylloquinone = 1184,
    
    [NutrientMetadata(Measure.Micrograms, 430, 8800.0)]
    Vitamin_K__phylloquinone = 1185,
    
    [NutrientMetadata(Measure.Micrograms, 431, 7000.0)]
    Folic_acid = 1186,
    
    [NutrientMetadata(Measure.Micrograms, 432, 7100.0)]
    Folate__food = 1187,
    
    [NutrientMetadata(Measure.Micrograms, 433, 8975)]
    _5_methyl_tetrahydrofolate__5_MTHF = 1188,
    
    [NutrientMetadata(Measure.Micrograms, 434, 999999.0)]
    Folate__not_5_MTHF = 1189,
    
    [NutrientMetadata(Measure.Micrograms, 435, 7200.0)]
    Folate__DFE = 1190,
    
    [NutrientMetadata(Measure.Micrograms, 436, 999999.0)]
    _10_Formyl_folic_acid__10HCOFA = 1191,
    
    [NutrientMetadata(Measure.Micrograms, 437, 999999.0)]
    _5_Formyltetrahydrofolic_acid__5_HCOH4 = 1192,
    
    [NutrientMetadata(Measure.Micrograms, 438, 999999.0)]
    Tetrahydrofolic_acid__THF = 1193,
    
    [NutrientMetadata(Measure.Milligrams, 450, 7230.0)]
    Choline__free = 1194,
    
    [NutrientMetadata(Measure.Milligrams, 451, 7240.0)]
    Choline__from_phosphocholine = 1195,
    
    [NutrientMetadata(Measure.Milligrams, 452, 7250.0)]
    Choline__from_phosphotidyl_choline = 1196,
    
    [NutrientMetadata(Measure.Milligrams, 453, 7260.0)]
    Choline__from_glycerophosphocholine = 1197,
    
    [NutrientMetadata(Measure.Milligrams, 454, 7290.0)]
    Betaine = 1198,
    
    [NutrientMetadata(Measure.Milligrams, 455, 7270.0)]
    Choline__from_sphingomyelin = 1199,
    
    [NutrientMetadata(Measure.Milligrams, 460, 999999.0)]
    p_Hydroxy_benzoic_acid = 1200,
    
    [NutrientMetadata(Measure.Milligrams, 461, 999999.0)]
    Caffeic_acid = 1201,
    
    [NutrientMetadata(Measure.Milligrams, 462, 999999.0)]
    p_Coumaric_acid = 1202,
    
    [NutrientMetadata(Measure.Milligrams, 463, 999999.0)]
    Ellagic_acid = 1203,
    
    [NutrientMetadata(Measure.Milligrams, 464, 999999.0)]
    Ferrulic_acid = 1204,
    
    [NutrientMetadata(Measure.Milligrams, 465, 999999.0)]
    Gentisic_acid = 1205,
    
    [NutrientMetadata(Measure.Milligrams, 466, 999999.0)]
    Tyrosol = 1206,
    
    [NutrientMetadata(Measure.Milligrams, 467, 999999.0)]
    Vanillic_acid = 1207,
    
    [NutrientMetadata(Measure.Milligrams, 469, 999999.0)]
    Phenolic_acids__total = 1208,
    
    [NutrientMetadata(Measure.Milligrams, 470, 999999.0)]
    Polyphenols__total = 1209,
    
    [NutrientMetadata(Measure.Grams, 501, 16300.0)]
    Tryptophan = 1210,
    
    [NutrientMetadata(Measure.Grams, 502, 16400.0)]
    Threonine = 1211,
    
    [NutrientMetadata(Measure.Grams, 503, 16500.0)]
    Isoleucine = 1212,
    
    [NutrientMetadata(Measure.Grams, 504, 16600.0)]
    Leucine = 1213,
    
    [NutrientMetadata(Measure.Grams, 505, 16700.0)]
    Lysine = 1214,
    
    [NutrientMetadata(Measure.Grams, 506, 16800.0)]
    Methionine = 1215,
    
    [NutrientMetadata(Measure.Grams, 507, 16900.0)]
    Cystine = 1216,
    
    [NutrientMetadata(Measure.Grams, 508, 17000.0)]
    Phenylalanine = 1217,
    
    [NutrientMetadata(Measure.Grams, 509, 17100.0)]
    Tyrosine = 1218,
    
    [NutrientMetadata(Measure.Grams, 510, 17200.0)]
    Valine = 1219,
    
    [NutrientMetadata(Measure.Grams, 511, 17300.0)]
    Arginine = 1220,
    
    [NutrientMetadata(Measure.Grams, 512, 17400.0)]
    Histidine = 1221,
    
    [NutrientMetadata(Measure.Grams, 513, 17500.0)]
    Alanine = 1222,
    
    [NutrientMetadata(Measure.Grams, 514, 17600.0)]
    Aspartic_acid = 1223,
    
    [NutrientMetadata(Measure.Grams, 515, 17700.0)]
    Glutamic_acid = 1224,
    
    [NutrientMetadata(Measure.Grams, 516, 17800.0)]
    Glycine = 1225,
    
    [NutrientMetadata(Measure.Grams, 517, 17900.0)]
    Proline = 1226,
    
    [NutrientMetadata(Measure.Grams, 518, 18000.0)]
    Serine = 1227,
    
    [NutrientMetadata(Measure.Grams, 521, 18100.0)]
    Hydroxyproline = 1228,
    
    [NutrientMetadata(Measure.Grams, 522, 999999.0)]
    Cysteine_and_methionine_sulfer_containig_AA = 1229,
    
    [NutrientMetadata(Measure.Grams, 523, 16950.0)]
    Phenylalanine_and_tyrosine__aromatic__AA = 1230,
    
    [NutrientMetadata(Measure.Grams, 525, 999999.0)]
    Asparagine = 1231,
    
    [NutrientMetadata(Measure.Grams, 526, 18150.0)]
    Cysteine = 1232,
    
    [NutrientMetadata(Measure.Grams, 528, 999999.0)]
    Glutamine = 1233,
    
    [NutrientMetadata(Measure.Grams, 529, 999999.0)]
    Taurine = 1234,
    
    [NutrientMetadata(Measure.Grams, 539, 1540.0)]
    Sugars__added = 1235,
    
    [NutrientMetadata(Measure.Grams, 549, 1520.0)]
    Sugars__intrinsic = 1236,
    
    [NutrientMetadata(Measure.Milligrams, 551, 5340.0)]
    Calcium__added = 1237,
    
    [NutrientMetadata(Measure.Milligrams, 553, 5440.0)]
    Iron__added = 1238,
    
    [NutrientMetadata(Measure.Milligrams, 561, 5320.0)]
    Calcium__intrinsic = 1239,
    
    [NutrientMetadata(Measure.Milligrams, 563, 5420.0)]
    Iron__intrinsic = 1240,
    
    [NutrientMetadata(Measure.Milligrams, 571, 6340.0)]
    Vitamin_C__added = 1241,
    
    [NutrientMetadata(Measure.Milligrams, 573, 7920.0)]
    Vitamin_E__added = 1242,
    
    [NutrientMetadata(Measure.Milligrams, 574, 6440.0)]
    Thiamin__added = 1243,
    
    [NutrientMetadata(Measure.Milligrams, 575, 6540.0)]
    Riboflavin__added = 1244,
    
    [NutrientMetadata(Measure.Milligrams, 576, 6640.0)]
    Niacin__added = 1245,
    
    [NutrientMetadata(Measure.Micrograms, 578, 7340.0)]
    Vitamin_B_12__added = 1246,
    
    [NutrientMetadata(Measure.Milligrams, 581, 6320.0)]
    Vitamin_C__intrinsic = 1247,
    
    [NutrientMetadata(Measure.Milligrams, 583, 7930.0)]
    Vitamin_E__intrinsic = 1248,
    
    [NutrientMetadata(Measure.Milligrams, 584, 6420.0)]
    Thiamin__intrinsic = 1249,
    
    [NutrientMetadata(Measure.Milligrams, 585, 6520.0)]
    Riboflavin__intrinsic = 1250,
    
    [NutrientMetadata(Measure.Milligrams, 586, 6620.0)]
    Niacin__intrinsic = 1251,
    
    [NutrientMetadata(Measure.Micrograms, 588, 7320.0)]
    Vitamin_B_12__intrinsic = 1252,
    
    [NutrientMetadata(Measure.Milligrams, 601, 15700.0)]
    Cholesterol = 1253,
    
    [NutrientMetadata(Measure.Grams, 602, 999999.0)]
    Glycerides = 1254,
    
    [NutrientMetadata(Measure.Grams, 603, 999999.0)]
    Phospholipids = 1255,
    
    [NutrientMetadata(Measure.Grams, 604, 999999.0)]
    Glycolipids = 1256,
    
    [NutrientMetadata(Measure.Grams, 605, 15400.0)]
    Fatty_acids__total_trans = 1257,
    
    [NutrientMetadata(Measure.Grams, 606, 9700.0)]
    Fatty_acids__total_saturated = 1258,
    
    [NutrientMetadata(Measure.Grams, 607, 9800.0)]
    SFA_4_0 = 1259,
    
    [NutrientMetadata(Measure.Grams, 608, 9900.0)]
    SFA_6_0 = 1260,
    
    [NutrientMetadata(Measure.Grams, 609, 10000.0)]
    SFA_8_0 = 1261,
    
    [NutrientMetadata(Measure.Grams, 610, 10100.0)]
    SFA_10_0 = 1262,
    
    [NutrientMetadata(Measure.Grams, 611, 10300.0)]
    SFA_12_0 = 1263,
    
    [NutrientMetadata(Measure.Grams, 612, 10500.0)]
    SFA_14_0 = 1264,
    
    [NutrientMetadata(Measure.Grams, 613, 10700.0)]
    SFA_16_0 = 1265,
    
    [NutrientMetadata(Measure.Grams, 614, 10900.0)]
    SFA_18_0 = 1266,
    
    [NutrientMetadata(Measure.Grams, 615, 11100.0)]
    SFA_20_0 = 1267,
    
    [NutrientMetadata(Measure.Grams, 617, 12100.0)]
    MUFA_18_1 = 1268,
    
    [NutrientMetadata(Measure.Grams, 618, 13100.0)]
    PUFA_18_2 = 1269,
    
    [NutrientMetadata(Measure.Grams, 619, 13900.0)]
    PUFA_18_3 = 1270,
    
    [NutrientMetadata(Measure.Grams, 620, 14700.0)]
    PUFA_20_4 = 1271,
    
    [NutrientMetadata(Measure.Grams, 621, 15300.0)]
    PUFA_22_6_n_3__DHA = 1272,
    
    [NutrientMetadata(Measure.Grams, 624, 11200.0)]
    SFA_22_0 = 1273,
    
    [NutrientMetadata(Measure.Grams, 625, 11500.0)]
    MUFA_14_1 = 1274,
    
    [NutrientMetadata(Measure.Grams, 626, 11700.0)]
    MUFA_16_1 = 1275,
    
    [NutrientMetadata(Measure.Grams, 627, 14250.0)]
    PUFA_18_4 = 1276,
    
    [NutrientMetadata(Measure.Grams, 628, 12400.0)]
    MUFA_20_1 = 1277,
    
    [NutrientMetadata(Measure.Grams, 629, 15000.0)]
    PUFA_20_5_n_3__EPA = 1278,
    
    [NutrientMetadata(Measure.Grams, 630, 12500.0)]
    MUFA_22_1 = 1279,
    
    [NutrientMetadata(Measure.Grams, 631, 15200.0)]
    PUFA_22_5_n_3__DPA = 1280,
    
    [NutrientMetadata(Measure.Grams, 821, 15510.0)]
    TFA_14_1_t = 1281,
    
    [NutrientMetadata(Measure.Milligrams, 636, 15800.0)]
    Phytosterols = 1283,
    
    [NutrientMetadata(Measure.Milligrams, 637, 16220.0)]
    Ergosterol = 1284,
    
    [NutrientMetadata(Measure.Milligrams, 638, 15900.0)]
    Stigmasterol = 1285,
    
    [NutrientMetadata(Measure.Milligrams, 639, 16000.0)]
    Campesterol = 1286,
    
    [NutrientMetadata(Measure.Milligrams, 640, 16100.0)]
    Brassicasterol = 1287,
    
    [NutrientMetadata(Measure.Milligrams, 641, 16200.0)]
    Beta_sitosterol = 1288,
    
    [NutrientMetadata(Measure.Milligrams, 642, 16221.0)]
    Campestanol = 1289,
    
    [NutrientMetadata(Measure.Grams, 643, 999999.0)]
    Unsaponifiable_matter__lipids = 1290,
    
    [NutrientMetadata(Measure.Grams, 644, 999999.0)]
    Fatty_acids__other_than_607_615__617_621__624_632__652_654__686_689 = 1291,
    
    [NutrientMetadata(Measure.Grams, 645, 11400.0)]
    Fatty_acids__total_monounsaturated = 1292,
    
    [NutrientMetadata(Measure.Grams, 646, 12900.0)]
    Fatty_acids__total_polyunsaturated = 1293,
    
    [NutrientMetadata(Measure.Milligrams, 647, 16222.0)]
    Beta_sitostanol = 1294,
    
    [NutrientMetadata(Measure.Milligrams, 648, 16223.0)]
    Delta_7_avenasterol = 1295,
    
    [NutrientMetadata(Measure.Milligrams, 649, 16224.0)]
    Delta_5_avenasterol = 1296,
    
    [NutrientMetadata(Measure.Milligrams, 650, 16225.0)]
    Alpha_spinasterol = 1297,
    
    [NutrientMetadata(Measure.Milligrams, 651, 16227.0)]
    Phytosterols__other = 1298,
    
    [NutrientMetadata(Measure.Grams, 652, 10600.0)]
    SFA_15_0 = 1299,
    
    [NutrientMetadata(Measure.Grams, 653, 10800.0)]
    SFA_17_0 = 1300,
    
    [NutrientMetadata(Measure.Grams, 654, 11300.0)]
    SFA_24_0 = 1301,
    
    [NutrientMetadata(Measure.Grams, 661, 999999.0)]
    Wax_Esters_Total_Wax = 1302,
    
    [NutrientMetadata(Measure.Grams, 662, 15520.0)]
    TFA_16_1_t = 1303,
    
    [NutrientMetadata(Measure.Grams, 663, 15521.0)]
    TFA_18_1_t = 1304,
    
    [NutrientMetadata(Measure.Grams, 664, 15550.0)]
    TFA_22_1_t = 1305,
    
    [NutrientMetadata(Measure.Grams, 665, 15610.0)]
    TFA_18_2_t_not_further_defined = 1306,
    
    [NutrientMetadata(Measure.Grams, 666, 13350.0)]
    PUFA_18_2_i = 1307,
    
    [NutrientMetadata(Measure.Grams, 667, 13500.0)]
    PUFA_18_2_t_c = 1308,
    
    [NutrientMetadata(Measure.Grams, 668, 13400.0)]
    PUFA_18_2_c_t = 1309,
    
    [NutrientMetadata(Measure.Grams, 669, 15615.0)]
    TFA_18_2_t_t = 1310,
    
    [NutrientMetadata(Measure.Grams, 670, 13300.0)]
    PUFA_18_2_CLAs = 1311,
    
    [NutrientMetadata(Measure.Grams, 671, 12800.0)]
    MUFA_24_1_c = 1312,
    
    [NutrientMetadata(Measure.Grams, 672, 14300.0)]
    PUFA_20_2_n_6_c_c = 1313,
    
    [NutrientMetadata(Measure.Grams, 673, 11800.0)]
    MUFA_16_1_c = 1314,
    
    [NutrientMetadata(Measure.Grams, 674, 12200.0)]
    MUFA_18_1_c = 1315,
    
    [NutrientMetadata(Measure.Grams, 675, 13200.0)]
    PUFA_18_2_n_6_c_c = 1316,
    
    [NutrientMetadata(Measure.Grams, 676, 12600.0)]
    MUFA_22_1_c = 1317,
    
    [NutrientMetadata(Measure.Grams, 677, 999999.0)]
    Fatty_acids__saturated__other = 1318,
    
    [NutrientMetadata(Measure.Grams, 678, 999999.0)]
    Fatty_acids__monounsat___other = 1319,
    
    [NutrientMetadata(Measure.Grams, 679, 999999.0)]
    Fatty_acids__polyunsat___other = 1320,
    
    [NutrientMetadata(Measure.Grams, 685, 14100.0)]
    PUFA_18_3_n_6_c_c_c = 1321,
    
    [NutrientMetadata(Measure.Grams, 686, 11000.0)]
    SFA_19_0 = 1322,
    
    [NutrientMetadata(Measure.Grams, 687, 12000.0)]
    MUFA_17_1 = 1323,
    
    [NutrientMetadata(Measure.Grams, 688, 13000.0)]
    PUFA_16_2 = 1324,
    
    [NutrientMetadata(Measure.Grams, 689, 14400.0)]
    PUFA_20_3 = 1325,
    
    [NutrientMetadata(Measure.Grams, 690, 999999.0)]
    Fatty_acids__total_sat___NLEA = 1326,
    
    [NutrientMetadata(Measure.Grams, 691, 999999.0)]
    Fatty_acids__total_monounsat___NLEA = 1327,
    
    [NutrientMetadata(Measure.Grams, 692, 999999.0)]
    Fatty_acids__total_polyunsat___NLEA = 1328,
    
    [NutrientMetadata(Measure.Grams, 693, 15500.0)]
    Fatty_acids__total_trans_monoenoic = 1329,
    
    [NutrientMetadata(Measure.Grams, 694, 15601.0)]
    Fatty_acids__total_trans_dienoic = 1330,
    
    [NutrientMetadata(Measure.Grams, 695, 15619.0)]
    Fatty_acids__total_trans_polyenoic = 1331,
    
    [NutrientMetadata(Measure.Grams, 696, 10400.0)]
    SFA_13_0 = 1332,
    
    [NutrientMetadata(Measure.Grams, 697, 11600.0)]
    MUFA_15_1 = 1333,
    
    [NutrientMetadata(Measure.Grams, 698, 15100.0)]
    PUFA_22_2 = 1334,
    
    [NutrientMetadata(Measure.Grams, 699, 10200.0)]
    SFA_11_0 = 1335,
    
    [NutrientMetadata(Measure.UMOL_TE, 706, -1)]
    ORAC__Hydrophyllic = 1336,
    
    [NutrientMetadata(Measure.UMOL_TE, 707, -1)]
    ORAC__Lipophillic = 1337,
    
    [NutrientMetadata(Measure.UMOL_TE, 708, -1)]
    ORAC__Total = 1338,
    
    [NutrientMetadata(Measure.MG_GAE, 709, -1)]
    Total_Phenolics = 1339,
    
    [NutrientMetadata(Measure.Milligrams, 710, 19100.0)]
    Daidzein = 1340,
    
    [NutrientMetadata(Measure.Milligrams, 711, 19200.0)]
    Genistein = 1341,
    
    [NutrientMetadata(Measure.Milligrams, 712, 19300.0)]
    Glycitein = 1342,
    
    [NutrientMetadata(Measure.Milligrams, 713, 19000.0)]
    Isoflavones = 1343,
    
    [NutrientMetadata(Measure.Milligrams, 714, 999999.0)]
    Biochanin_A = 1344,
    
    [NutrientMetadata(Measure.Milligrams, 715, 999999.0)]
    Formononetin = 1345,
    
    [NutrientMetadata(Measure.Milligrams, 716, 999999.0)]
    Coumestrol = 1346,
    
    [NutrientMetadata(Measure.Milligrams, 729, 999999.0)]
    Flavonoids__total = 1347,
    
    [NutrientMetadata(Measure.Milligrams, 730, 19400.0)]
    Anthocyanidins = 1348,
    
    [NutrientMetadata(Measure.Milligrams, 731, 19500.0)]
    Cyanidin = 1349,
    
    [NutrientMetadata(Measure.Milligrams, 732, 19510.0)]
    Proanthocyanidin__dimer_A_linkage = 1350,
    
    [NutrientMetadata(Measure.Milligrams, 733, 19520.0)]
    Proanthocyanidin_monomers = 1351,
    
    [NutrientMetadata(Measure.Milligrams, 734, 19530.0)]
    Proanthocyanidin_dimers = 1352,
    
    [NutrientMetadata(Measure.Milligrams, 735, 19540.0)]
    Proanthocyanidin_trimers = 1353,
    
    [NutrientMetadata(Measure.Milligrams, 736, 19550.0)]
    Proanthocyanidin_4_6mers = 1354,
    
    [NutrientMetadata(Measure.Milligrams, 737, 19560.0)]
    Proanthocyanidin_7_10mers = 1355,
    
    [NutrientMetadata(Measure.Milligrams, 738, 19570.0)]
    Proanthocyanidin_polymers___10mers = 1356,
    
    [NutrientMetadata(Measure.Milligrams, 741, 19600.0)]
    Delphinidin = 1357,
    
    [NutrientMetadata(Measure.Milligrams, 742, 19700.0)]
    Malvidin = 1358,
    
    [NutrientMetadata(Measure.Milligrams, 743, 19800.0)]
    Pelargonidin = 1359,
    
    [NutrientMetadata(Measure.Milligrams, 745, 19900.0)]
    Peonidin = 1360,
    
    [NutrientMetadata(Measure.Milligrams, 746, 20000.0)]
    Petunidin = 1361,
    
    [NutrientMetadata(Measure.Milligrams, 747, 20100.0)]
    Flavans__total = 1362,
    
    [NutrientMetadata(Measure.Milligrams, 748, 20200.0)]
    Catechins__total = 1363,
    
    [NutrientMetadata(Measure.Milligrams, 749, 20300.0)]
    Catechin = 1364,
    
    [NutrientMetadata(Measure.Milligrams, 750, 20400.0)]
    Epigallocatechin = 1365,
    
    [NutrientMetadata(Measure.Milligrams, 751, 20500.0)]
    Epicatechin = 1366,
    
    [NutrientMetadata(Measure.Milligrams, 752, 20600.0)]
    Epicatechin_3_gallate = 1367,
    
    [NutrientMetadata(Measure.Milligrams, 753, 20700.0)]
    Epigallocatechin_3_gallate = 1368,
    
    [NutrientMetadata(Measure.Milligrams, 754, 20800.0)]
    Procyanidins__total = 1369,
    
    [NutrientMetadata(Measure.Milligrams, 755, 20900.0)]
    Theaflavins = 1370,
    
    [NutrientMetadata(Measure.Milligrams, 756, 21000.0)]
    Thearubigins = 1371,
    
    [NutrientMetadata(Measure.Milligrams, 757, 21200.0)]
    Flavanones__total = 1372,
    
    [NutrientMetadata(Measure.Milligrams, 758, 21300.0)]
    Eriodictyol = 1373,
    
    [NutrientMetadata(Measure.Milligrams, 759, 21400.0)]
    Hesperetin = 1374,
    
    [NutrientMetadata(Measure.Milligrams, 760, 21500.0)]
    Isosakuranetin = 1375,
    
    [NutrientMetadata(Measure.Milligrams, 761, 21600.0)]
    Liquiritigenin = 1376,
    
    [NutrientMetadata(Measure.Milligrams, 762, 21700.0)]
    Naringenin = 1377,
    
    [NutrientMetadata(Measure.Milligrams, 768, 21800.0)]
    Flavones__total = 1378,
    
    [NutrientMetadata(Measure.Milligrams, 770, 21900.0)]
    Apigenin = 1379,
    
    [NutrientMetadata(Measure.Milligrams, 771, 22000.0)]
    Chrysoeriol = 1380,
    
    [NutrientMetadata(Measure.Milligrams, 772, 22100.0)]
    Diosmetin = 1381,
    
    [NutrientMetadata(Measure.Milligrams, 773, 22200.0)]
    Luteolin = 1382,
    
    [NutrientMetadata(Measure.Milligrams, 781, 22300.0)]
    Nobiletin = 1383,
    
    [NutrientMetadata(Measure.Milligrams, 782, 22400.0)]
    Sinensetin = 1384,
    
    [NutrientMetadata(Measure.Milligrams, 783, 22500.0)]
    Tangeretin = 1385,
    
    [NutrientMetadata(Measure.Milligrams, 784, 22600.0)]
    Flavonols__total = 1386,
    
    [NutrientMetadata(Measure.Milligrams, 785, 22700.0)]
    Isorhamnetin = 1387,
    
    [NutrientMetadata(Measure.Milligrams, 786, 22800.0)]
    Kaempferol = 1388,
    
    [NutrientMetadata(Measure.Milligrams, 787, 22900.0)]
    Limocitrin = 1389,
    
    [NutrientMetadata(Measure.Milligrams, 788, 23000.0)]
    Myricetin = 1390,
    
    [NutrientMetadata(Measure.Milligrams, 789, 23100.0)]
    Quercetin = 1391,
    
    [NutrientMetadata(Measure.Milligrams, 790, 21100.0)]
    Theogallin = 1392,
    
    [NutrientMetadata(Measure.Milligrams, 791, -1)]
    Theaflavin__3_3___digallate = 1393,
    
    [NutrientMetadata(Measure.Milligrams, 792, -1)]
    Theaflavin__3___gallate = 1394,
    
    [NutrientMetadata(Measure.Milligrams, 793, -1)]
    Theaflavin__3__gallate = 1395,
    
    [NutrientMetadata(Measure.Milligrams, 794, -1)]
    PLUS_Gallo_catechin = 1396,
    
    [NutrientMetadata(Measure.Milligrams, 795, -1)]
    PLUS_Catechin_3_gallate = 1397,
    
    [NutrientMetadata(Measure.Milligrams, 796, -1)]
    PLUS_Gallocatechin_3_gallate = 1398,
    
    [NutrientMetadata(Measure.Grams, 801, 999999.0)]
    Mannose = 1399,
    
    [NutrientMetadata(Measure.Grams, 803, 999999.0)]
    Triose = 1400,
    
    [NutrientMetadata(Measure.Grams, 804, 999999.0)]
    Tetrose = 1401,
    
    [NutrientMetadata(Measure.Grams, 805, 999999.0)]
    Other_Saccharides = 1402,
    
    [NutrientMetadata(Measure.Grams, 806, 999999.0)]
    Inulin = 1403,
    
    [NutrientMetadata(Measure.Grams, 851, 14000.0)]
    PUFA_18_3_n_3_c_c_c__ALA = 1404,
    
    [NutrientMetadata(Measure.Grams, 852, 14500.0)]
    PUFA_20_3_n_3 = 1405,
    
    [NutrientMetadata(Measure.Grams, 853, 14600.0)]
    PUFA_20_3_n_6 = 1406,
    
    [NutrientMetadata(Measure.Grams, 854, 14800.0)]
    PUFA_20_4_n_3 = 1407,
    
    [NutrientMetadata(Measure.Grams, 855, 14900.0)]
    PUFA_20_4_n_6 = 1408,
    
    [NutrientMetadata(Measure.Grams, 856, 14200.0)]
    PUFA_18_3i = 1409,
    
    [NutrientMetadata(Measure.Grams, 857, 15100.0)]
    PUFA_21_5 = 1410,
    
    [NutrientMetadata(Measure.Grams, 858, 15160.0)]
    PUFA_22_4 = 1411,
    
    [NutrientMetadata(Measure.Grams, 859, 12310.0)]
    MUFA_18_1_11_t__18_1t_n_7 = 1412,
    
    [NutrientMetadata(Measure.Grams, 860, 12210.0)]
    MUFA_18_1_11_c__18_1c_n_7 = 1413,
    
    [NutrientMetadata(Measure.Grams, 861, 14650.0)]
    PUFA_20_3_n_9 = 1414,
    
    [NutrientMetadata(Measure.Grams, 269, 1510.0)]
    Total_Sugars = 2000,
    
    [NutrientMetadata(Measure.Grams, 632, 9850.0)]
    SFA_5_0 = 2003,
    
    [NutrientMetadata(Measure.Grams, 633, 9950.0)]
    SFA_7_0 = 2004,
    
    [NutrientMetadata(Measure.Grams, 634, 10050.0)]
    SFA_9_0 = 2005,
    
    [NutrientMetadata(Measure.Grams, 681, 11150.0)]
    SFA_21_0 = 2006,
    
    [NutrientMetadata(Measure.Grams, 682, 11250.0)]
    SFA_23_0 = 2007,
    
    [NutrientMetadata(Measure.Grams, 635, 11450.0)]
    MUFA_12_1 = 2008,
    
    [NutrientMetadata(Measure.Grams, 822, 11501.0)]
    MUFA_14_1_c = 2009,
    
    [NutrientMetadata(Measure.Grams, 825, 12001.0)]
    MUFA_17_1_c = 2010,
    
    [NutrientMetadata(Measure.Grams, 826, 15525.0)]
    TFA_17_1_t = 2011,
    
    [NutrientMetadata(Measure.Grams, 829, 12401.0)]
    MUFA_20_1_c = 2012,
    
    [NutrientMetadata(Measure.Grams, 830, 15540.0)]
    TFA_20_1_t = 2013,
    
    [NutrientMetadata(Measure.Grams, 676.1, 12601.0)]
    MUFA_22_1_n_9 = 2014,
    
    [NutrientMetadata(Measure.Grams, 676.2, 12602.0)]
    MUFA_22_1_n_11 = 2015,
    
    [NutrientMetadata(Measure.Grams, 831, 13150.0)]
    PUFA_18_2_c = 2016,
    
    [NutrientMetadata(Measure.Grams, 832, 15611.0)]
    TFA_18_2_t = 2017,
    
    [NutrientMetadata(Measure.Grams, 833, 13910.0)]
    PUFA_18_3_c = 2018,
    
    [NutrientMetadata(Measure.Grams, 834, 15660.0)]
    TFA_18_3_t = 2019,
    
    [NutrientMetadata(Measure.Grams, 835, 14450.0)]
    PUFA_20_3_c = 2020,
    
    [NutrientMetadata(Measure.Grams, 683, 14675.0)]
    PUFA_22_3 = 2021,
    
    [NutrientMetadata(Measure.Grams, 836, 14750.0)]
    PUFA_20_4c = 2022,
    
    [NutrientMetadata(Measure.Grams, 837, 14950.0)]
    PUFA_20_5c = 2023,
    
    [NutrientMetadata(Measure.Grams, 838, 15150.0)]
    PUFA_22_5_c = 2024,
    
    [NutrientMetadata(Measure.Grams, 839, 15250.0)]
    PUFA_22_6_c = 2025,
    
    [NutrientMetadata(Measure.Grams, 840, 14250.0)]
    PUFA_20_2_c = 2026,
    
    [NutrientMetadata(Measure.Grams, 200, 999999.0)]
    Proximate = 2027,
    
    [NutrientMetadata(Measure.Micrograms, 321.2, 7444.0)]
    trans_beta_Carotene = 2028,
    
    [NutrientMetadata(Measure.Micrograms, 337.2, 7534.0)]
    trans_Lycopene = 2029,
    
    [NutrientMetadata(Measure.Micrograms, 335, 7461.0)]
    Cryptoxanthin__alpha = 2032,
    
    [NutrientMetadata(Measure.Grams, 293, 1300.0)]
    Total_dietary_fiber__AOAC_2011_25 = 2033,
    
    [NutrientMetadata(Measure.Grams, 293.1, 1310.0)]
    Insoluble_dietary_fiber__IDF = 2034,
    
    [NutrientMetadata(Measure.Grams, 293.2, 1320.0)]
    Soluble_dietary_fiber__SDFP_SDFS = 2035,
    
    [NutrientMetadata(Measure.Grams, 954, 1324.0)]
    Soluble_dietary_fiber__SDFP = 2036,
    
    [NutrientMetadata(Measure.Grams, 953, 1326.0)]
    Soluble_dietary_fiber__SDFS = 2037,
    
    [NutrientMetadata(Measure.Grams, 293.3, 1305)]
    High_Molecular_Weight_Dietary_Fiber__HMWDF = 2038,
    
    [NutrientMetadata(Measure.Grams, 956, 1100.0)]
    Carbohydrates = 2039,
    
    [NutrientMetadata(Measure.Micrograms, 955, 7510.0)]
    Other_carotenoids = 2040, 
    
    [NutrientMetadata(Measure.Milligrams, 323.99, 7900.0)]
    Tocopherols_and_tocotrienols = 2041,
    
    [NutrientMetadata(Measure.Grams, 500, 16250.0)]
    Amino_acids = 2042,
    
    [NutrientMetadata(Measure.Milligrams, 300, 5200.0)]
    Minerals = 2043,
    
    [NutrientMetadata(Measure.Grams, 950, 9600.0)]
    Lipids = 2044,
    
    [NutrientMetadata(Measure.Grams, 951, 50.0)]
    Proximates = 2045,
    
    [NutrientMetadata(Measure.Grams, 952, 6250.0)]
    Vitamins_and_Other_Components = 2046,
    
    [NutrientMetadata(Measure.Milligrams, -1, 7901.0)]
    Total_Tocopherols = 2055,
    
    [NutrientMetadata(Measure.Milligrams, -1, 7902.0)]
    Total_Tocotrienols = 2054,
    
    [NutrientMetadata(Measure.Milligrams, -1, 15801.0)]
    Stigmastadiene = 2053,
    
    [NutrientMetadata(Measure.Milligrams, -1, 16226.0)]
    Delta_7_Stigmastenol = 2052,
    
    [NutrientMetadata(Measure.Milligrams, 717, 19310.0)]
    Daidzin = 2049,
    
    [NutrientMetadata(Measure.Milligrams, 718, 19320.0)]
    Genistin = 2050,
    
    [NutrientMetadata(Measure.Milligrams, 719, 19330.0)]
    Glycitin = 2051,
    
    [NutrientMetadata(Measure.Milligrams, -1, 18500)]
    Ergothioneine = 2057,
    
    [NutrientMetadata(Measure.Grams, -1, 1327.0)]
    Beta_glucan = 2058,
    
    [NutrientMetadata(Measure.Micrograms, -1, 8730.0)]
    Vitamin_D4 = 2059,
    
    [NutrientMetadata(Measure.Milligrams, -1, 16210.0)]
    Ergosta_7_enol = 2060,
    
    [NutrientMetadata(Measure.Milligrams, -1, 16211.0)]
    Ergosta_7_22_dienol = 2061,
    
    [NutrientMetadata(Measure.Milligrams, -1, 16211.0)]
    Ergosta_5_7_dienol = 2062,
    
    [NutrientMetadata(Measure.Grams, -1, 2450.0)]
    Verbascose = 2063,
    
    [NutrientMetadata(Measure.Milligrams, -1, 2250.0)]
    Oligosaccharides2 = 2064,
    
    [NutrientMetadata(Measure.Grams, 293.4, 1306)]
    Low_Molecular_Weight_Dietary_Fiber__LMWDF = 2065,
    
    [NutrientMetadata(Measure.Milligrams, 959, 7810)]
    Vitamin_E2 = 2068,
    
    [NutrientMetadata(Measure.Micrograms, 960, 7430)]
    Vitamin_A = 2067,
    
    [NutrientMetadata(Measure.Milligrams, 961, 9000)]
    Glutathione = 2069,
    
    /*All = Proteins | DietaryCholesterol
        | Starch | SolubleFiber | InsolubleFiber | Sugar | Oligosaccharides
        | MonounsaturatedFats | Omega3 | Omega6 | SaturatedFats | TransFats
        | Flavanoids | NonFlavanoids | NonProvitaminACarotenoids
        | AlphaCarotene | BetaCarotene | Retinol
        | VitaminB1 | VitaminB2 | VitaminB3 | VitaminB5 | VitaminB6 | VitaminB7 | VitaminB9 | VitaminB12
        | VitaminC | VitaminD2 | VitaminD3 | VitaminE | VitaminK1 | VitaminK2
        | Calcium | Chloride | Magnesium | Potassium | Sodium
        | Chromium | Copper | Fluoride | Iodine | Iron | Manganese | Selenium | Zinc | Molybdenum | Phosphorus | Sulfur | Boron | Vanadium
        | Choline | Betaine | Lithium
        | Histidine | Isoleucine | Leucine | Lysine | Methionine | Phenylalanine | Threonine | Tryptophan | Valine | Arginine | Glycine*/
}

public static class NutrientExtensions
{
    private static NutrientMetadataAttribute? GetMetadata(this Nutrients2 nutrient)
    {
        var memberInfo = nutrient.GetType().GetMember(nutrient.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute<NutrientMetadataAttribute>(true);
        }

        return null;
    }

    public static Measure? GetMeasure(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.Measure;
    }

    public static double? GetNutrientNumber(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.NutrientNumber;
    }

    public static double? GetRank(this Nutrients2 nutrient)
    {
        return nutrient.GetMetadata()?.Rank;
    }
}


public static class Nutrients2Helpers
{
    /*public static readonly List<Nutrients2> All = [
        Nutrients2.Vanadium, Nutrients2.Lithium, Nutrients2.Proteins, Nutrients2.Carbohydrates,
        Nutrients2.NetCarbohydrates, Nutrients2.Starch, Nutrients2.Oligosaccharides, Nutrients2.SolubleFiber,
        Nutrients2.InsolubleFiber, Nutrients2.DietaryFiber, Nutrients2.Calcium, Nutrients2.Chloride,
        Nutrients2.Chromium, Nutrients2.Copper, Nutrients2.Fluoride, Nutrients2.Iodine,
        Nutrients2.Magnesium, Nutrients2.Manganese, Nutrients2.Molybdenum, Nutrients2.Phosphorus,
        Nutrients2.Potassium, Nutrients2.Selenium, Nutrients2.Sulfur, Nutrients2.Boron,
        Nutrients2.VitaminB1, Nutrients2.VitaminB2, Nutrients2.VitaminB3, Nutrients2.VitaminB5,
        Nutrients2.VitaminB6, Nutrients2.VitaminB7, Nutrients2.VitaminB9, Nutrients2.VitaminB12,
        Nutrients2.VitaminA, Nutrients2.VitaminC, Nutrients2.NonProvitaminACarotenoids, Nutrients2.AlphaCarotene,
        Nutrients2.BetaCarotene, Nutrients2.ProvitaminACarotenoids, Nutrients2.Carotenoids, Nutrients2.Flavanoids,
        Nutrients2.NonFlavanoids, Nutrients2.Polyphenols, Nutrients2.Retinol, Nutrients2.VitaminD2,
        Nutrients2.VitaminD3, Nutrients2.VitaminD, Nutrients2.VitaminE, Nutrients2.VitaminK1,
        Nutrients2.VitaminK2, Nutrients2.VitaminK, Nutrients2.Zinc, Nutrients2.Choline,
        Nutrients2.Betaine, Nutrients2.Histidine, Nutrients2.Isoleucine, Nutrients2.Leucine,
        Nutrients2.Lysine, Nutrients2.Phenylalanine, Nutrients2.Methionine, Nutrients2.Threonine,
        Nutrients2.Tryptophan, Nutrients2.Valine, Nutrients2.Arginine, Nutrients2.Glycine,
        Nutrients2.Iron, Nutrients2.Calories, Nutrients2.Fats, Nutrients2.Sodium, Nutrients2.DietaryCholesterol,
        Nutrients2.Sugar, Nutrients2.MonounsaturatedFats, Nutrients2.Omega3, Nutrients2.Omega6,
        Nutrients2.PolyunsaturatedFats, Nutrients2.UnsaturatedFats, Nutrients2.SaturatedFats, Nutrients2.TransFats,
    ];*/
}