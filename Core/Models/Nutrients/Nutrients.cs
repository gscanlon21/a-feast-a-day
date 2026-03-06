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
    /// Solids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 201, 200.0)]
    [Display(Name = "Solids")]
    Solids_Grams = 1001,

    /// <summary>
    /// Nitrogen
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 202, 500.0)]
    [Display(Name = "Nitrogen")]
    Nitrogen_Grams = 1002,

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
    /// Fiber, crude (DO NOT USE - Archived)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 206, 999999.0)]
    [Display(Name = "Fiber, crude (DO NOT USE - Archived)")]
    Fiber_crude_DO_NOT_USE__Archived_Grams = 1006,

    /// <summary>
    /// Ash
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 207, 1000.0)]
    [Display(Name = "Ash")]
    Ash_Grams = 1007,

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
    /// Sucrose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 210, 1600.0)]
    [Display(Name = "Sucrose")]
    Sucrose_Grams = 1010,

    /// <summary>
    /// Glucose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 211, 1700.0)]
    [Display(Name = "Glucose")]
    Glucose_Grams = 1011,

    /// <summary>
    /// Fructose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 212, 1800.0)]
    [Display(Name = "Fructose")]
    Fructose_Grams = 1012,

    /// <summary>
    /// Lactose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 213, 1900.0)]
    [Display(Name = "Lactose")]
    Lactose_Grams = 1013,

    /// <summary>
    /// Maltose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 214, 2000.0)]
    [Display(Name = "Maltose")]
    Maltose_Grams = 1014,

    /// <summary>
    /// Amylose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 218, 999999.0)]
    [Display(Name = "Amylose")]
    Amylose_Grams = 1015,

    /// <summary>
    /// Amylopectin
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 219, 999999.0)]
    [Display(Name = "Amylopectin")]
    Amylopectin_Grams = 1016,

    /// <summary>
    /// Pectin
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 220, 999999.0)]
    [Display(Name = "Pectin")]
    Pectin_Grams = 1017,

    /// <summary>
    /// Alcohol, ethyl
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 221, 18200.0)]
    [Display(Name = "Alcohol, ethyl")]
    Alcohol_ethyl_Grams = 1018,

    /// <summary>
    /// Pentosan
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 222, 999999.0)]
    [Display(Name = "Pentosan")]
    Pentosan_Grams = 1019,

    /// <summary>
    /// Pentoses
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 223, 999999.0)]
    [Display(Name = "Pentoses")]
    Pentoses_Grams = 1020,

    /// <summary>
    /// Hemicellulose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 224, 999999.0)]
    [Display(Name = "Hemicellulose")]
    Hemicellulose_Grams = 1021,

    /// <summary>
    /// Cellulose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 225, 999999.0)]
    [Display(Name = "Cellulose")]
    Cellulose_Grams = 1022,

    /// <summary>
    /// pH
    /// </summary>
    [NutrientsMetadata(Measure.PH, 226, 999999.0)]
    [Display(Name = "pH")]
    pH_PH = 1023,

    /// <summary>
    /// Specific Gravity
    /// </summary>
    [NutrientsMetadata(Measure.SpecificGravity, 227, 8955)]
    [Display(Name = "Specific Gravity")]
    Specific_Gravity_SpecificGravity = 1024,

    /// <summary>
    /// Organic acids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 229, 2850.0)]
    [Display(Name = "Organic acids")]
    Organic_acids_Grams = 1025,

    /// <summary>
    /// Acetic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 230, 2900.0)]
    [Display(Name = "Acetic acid")]
    Acetic_acid_Milligrams = 1026,

    /// <summary>
    /// Aconitic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 231, 3000.0)]
    [Display(Name = "Aconitic acid")]
    Aconitic_acid_Milligrams = 1027,

    /// <summary>
    /// Benzoic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 232, 3100.0)]
    [Display(Name = "Benzoic acid")]
    Benzoic_acid_Milligrams = 1028,

    /// <summary>
    /// Chelidonic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 233, 3200.0)]
    [Display(Name = "Chelidonic acid")]
    Chelidonic_acid_Milligrams = 1029,

    /// <summary>
    /// Chlorogenic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 234, 3300.0)]
    [Display(Name = "Chlorogenic acid")]
    Chlorogenic_acid_Milligrams = 1030,

    /// <summary>
    /// Cinnamic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 235, 3400.0)]
    [Display(Name = "Cinnamic acid")]
    Cinnamic_acid_Milligrams = 1031,

    /// <summary>
    /// Citric acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 236, 3500.0)]
    [Display(Name = "Citric acid")]
    Citric_acid_Milligrams = 1032,

    /// <summary>
    /// Fumaric acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 237, 3600.0)]
    [Display(Name = "Fumaric acid")]
    Fumaric_acid_Milligrams = 1033,

    /// <summary>
    /// Galacturonic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 238, 3700.0)]
    [Display(Name = "Galacturonic acid")]
    Galacturonic_acid_Milligrams = 1034,

    /// <summary>
    /// Gallic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 239, 3800.0)]
    [Display(Name = "Gallic acid")]
    Gallic_acid_Milligrams = 1035,

    /// <summary>
    /// Glycolic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 240, 3900.0)]
    [Display(Name = "Glycolic acid")]
    Glycolic_acid_Milligrams = 1036,

    /// <summary>
    /// Isocitric acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 241, 4000.0)]
    [Display(Name = "Isocitric acid")]
    Isocitric_acid_Milligrams = 1037,

    /// <summary>
    /// Lactic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 242, 4100.0)]
    [Display(Name = "Lactic acid")]
    Lactic_acid_Milligrams = 1038,

    /// <summary>
    /// Malic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 243, 4200.0)]
    [Display(Name = "Malic acid")]
    Malic_acid_Milligrams = 1039,

    /// <summary>
    /// Oxaloacetic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 244, 4300.0)]
    [Display(Name = "Oxaloacetic acid")]
    Oxaloacetic_acid_Milligrams = 1040,

    /// <summary>
    /// Oxalic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 245, 4400.0)]
    [Display(Name = "Oxalic acid")]
    Oxalic_acid_Milligrams = 1041,

    /// <summary>
    /// Phytic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 246, 4500.0)]
    [Display(Name = "Phytic acid")]
    Phytic_acid_Milligrams = 1042,

    /// <summary>
    /// Pyruvic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 247, 4600.0)]
    [Display(Name = "Pyruvic acid")]
    Pyruvic_acid_Milligrams = 1043,

    /// <summary>
    /// Quinic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 248, 4700.0)]
    [Display(Name = "Quinic acid")]
    Quinic_acid_Milligrams = 1044,

    /// <summary>
    /// Salicylic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 249, 4800.0)]
    [Display(Name = "Salicylic acid")]
    Salicylic_acid_Milligrams = 1045,

    /// <summary>
    /// Succinic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 250, 4900.0)]
    [Display(Name = "Succinic acid")]
    Succinic_acid_Milligrams = 1046,

    /// <summary>
    /// Tartaric acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 251, 5000.0)]
    [Display(Name = "Tartaric acid")]
    Tartaric_acid_Milligrams = 1047,

    /// <summary>
    /// Ursolic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 252, 5100.0)]
    [Display(Name = "Ursolic acid")]
    Ursolic_acid_Milligrams = 1048,

    /// <summary>
    /// Solids, non-fat
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 253, 999999.0)]
    [Display(Name = "Solids, non-fat")]
    Solids_non_fat_Grams = 1049,

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
    /// Water
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 255, 100.0)]
    [Display(Name = "Water")]
    Water_Grams = 1051,

    /// <summary>
    /// Adjusted Nitrogen
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 256, 999999.0)]
    [Display(Name = "Adjusted Nitrogen")]
    Adjusted_Nitrogen_Grams = 1052,

    /// <summary>
    /// Adjusted Protein
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 257, 700.0)]
    [Display(Name = "Adjusted Protein")]
    Adjusted_Protein_Grams = 1053,

    /// <summary>
    /// Piperine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 259, 999999.0)]
    [Display(Name = "Piperine")]
    Piperine_Grams = 1054,

    /// <summary>
    /// Mannitol
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 260, 2500.0)]
    [Display(Name = "Mannitol")]
    Mannitol_Grams = 1055,

    /// <summary>
    /// Sorbitol
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 261, 2600.0)]
    [Display(Name = "Sorbitol")]
    Sorbitol_Grams = 1056,

    /// <summary>
    /// Caffeine
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 262, 18300.0)]
    [Display(Name = "Caffeine")]
    Caffeine_Milligrams = 1057,

    /// <summary>
    /// Theobromine
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 263, 18400.0)]
    [Display(Name = "Theobromine")]
    Theobromine_Milligrams = 1058,

    /// <summary>
    /// Nitrates
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 264, 999999.0)]
    [Display(Name = "Nitrates")]
    Nitrates_Milligrams = 1059,

    /// <summary>
    /// Nitrites
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 265, 999999.0)]
    [Display(Name = "Nitrites")]
    Nitrites_Milligrams = 1060,

    /// <summary>
    /// Nitrosamine,total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 266, 999999.0)]
    [Display(Name = "Nitrosamine,total")]
    Nitrosamine_total_Milligrams = 1061,

    /// <summary>
    /// Energy
    /// </summary>
    [NutrientsMetadata(Measure.KiloJoule, 268, 400.0)]
    [Display(Name = "Energy")]
    Energy_KiloJoule = 1062,

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
    /// Solids, soluble
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 271, 999999.0)]
    [Display(Name = "Solids, soluble")]
    Solids_soluble_Grams = 1064,

    /// <summary>
    /// Glycogen
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 272, 999999.0)]
    [Display(Name = "Glycogen")]
    Glycogen_Grams = 1065,

    /// <summary>
    /// Fiber, neutral detergent (DO NOT USE - Archived)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 273, 999999.0)]
    [Display(Name = "Fiber, neutral detergent (DO NOT USE - Archived)")]
    Fiber_neutral_detergent_DO_NOT_USE__Archived_Grams = 1066,

    /// <summary>
    /// Reducing sugars
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 274, 999999.0)]
    [Display(Name = "Reducing sugars")]
    Reducing_sugars_Grams = 1067,

    /// <summary>
    /// Beta-glucans
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 276, 999999.0)]
    [Display(Name = "Beta-glucans")]
    Beta_glucans_Grams = 1068,

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
    /// Carbohydrate, other
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 284, -1)]
    [Display(Name = "Carbohydrate, other")]
    Carbohydrate_other_Grams = 1072,

    /// <summary>
    /// Arabinose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 285, 999999.0)]
    [Display(Name = "Arabinose")]
    Arabinose_Grams = 1073,

    /// <summary>
    /// Xylose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 286, 999999.0)]
    [Display(Name = "Xylose")]
    Xylose_Grams = 1074,

    /// <summary>
    /// Galactose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 287, 2100.0)]
    [Display(Name = "Galactose")]
    Galactose_Grams = 1075,

    /// <summary>
    /// Raffinose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 288, 2300.0)]
    [Display(Name = "Raffinose")]
    Raffinose_Grams = 1076,

    /// <summary>
    /// Stachyose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 289, 2400.0)]
    [Display(Name = "Stachyose")]
    Stachyose_Grams = 1077,

    /// <summary>
    /// Xylitol
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 290, 2700.0)]
    [Display(Name = "Xylitol")]
    Xylitol_Grams = 1078,

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
    /// Lignin
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 292, 999999.0)]
    [Display(Name = "Lignin")]
    Lignin_Grams = 1080,

    /// <summary>
    /// Ribose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 294, 999999.0)]
    [Display(Name = "Ribose")]
    Ribose_Grams = 1081,

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
    /// Theophylline
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 296, 999999.0)]
    [Display(Name = "Theophylline")]
    Theophylline_Milligrams = 1083,

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
    /// Total fat (NLEA)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 298, 900.0)]
    [Display(Name = "Total fat (NLEA)")]
    Total_fat_NLEA_Grams = 1085,

    /// <summary>
    /// Total sugar alcohols
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 299, 999999.0)]
    [Display(Name = "Total sugar alcohols")]
    Total_sugar_alcohols_Grams = 1086,

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
    /// Sulfur, S
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 308, 6241.0)]
    [Display(Name = "Sulfur, S")]
    Sulfur_S_Milligrams = 1094,

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
    /// Cobalt, Co
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 311, 6244.0)]
    [Display(Name = "Cobalt, Co")]
    Cobalt_Co_Micrograms = 1097,

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
    /// Vitamin A, IU
    /// </summary>
    [NutrientsMetadata(Measure.IU, 318, 7500.0)]
    [Display(Name = "Vitamin A, IU")]
    Vitamin_A_IU_IU = 1104,

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
    /// Vitamin D (D2 + D3), International Units
    /// </summary>
    [NutrientsMetadata(Measure.IU, 324, 8650.0)]
    [Display(Name = "Vitamin D (D2 + D3), International Units")]
    Vitamin_D_D2__D3__International_Units_IU = 1110,

    /// <summary>
    /// Vitamin D2 (ergocalciferol)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 325, 8710.0)]
    [Display(Name = "Vitamin D2 (ergocalciferol)")]
    Vitamin_D2_ergocalciferol_Micrograms = 1111,

    /// <summary>
    /// Vitamin D3 (cholecalciferol)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 326, 8720.0)]
    [Display(Name = "Vitamin D3 (cholecalciferol)")]
    Vitamin_D3_cholecalciferol_Micrograms = 1112,

    /// <summary>
    /// 25-hydroxycholecalciferol
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 327, 8730.0)]
    [Display(Name = "25-hydroxycholecalciferol")]
    _25_hydroxycholecalciferol_Micrograms = 1113,

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
    /// 25-hydroxyergocalciferol
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 329, 8740.0)]
    [Display(Name = "25-hydroxyergocalciferol")]
    _25_hydroxyergocalciferol_Micrograms = 1115,

    /// <summary>
    /// Phytoene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 330, 7570.0)]
    [Display(Name = "Phytoene")]
    Phytoene_Micrograms = 1116,

    /// <summary>
    /// Phytofluene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 331, 7580.0)]
    [Display(Name = "Phytofluene")]
    Phytofluene_Micrograms = 1117,

    /// <summary>
    /// Carotene, gamma
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 332, 7455.0)]
    [Display(Name = "Carotene, gamma")]
    Carotene_gamma_Micrograms = 1118,

    /// <summary>
    /// Zeaxanthin
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 338.2, 7564.0)]
    [Display(Name = "Zeaxanthin")]
    Zeaxanthin_Micrograms = 1119,

    /// <summary>
    /// Cryptoxanthin, beta
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 334, 7460.0)]
    [Display(Name = "Cryptoxanthin, beta")]
    Cryptoxanthin_beta_Micrograms = 1120,

    /// <summary>
    /// Lutein
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 338.1, 7562.0)]
    [Display(Name = "Lutein")]
    Lutein_Micrograms = 1121,

    /// <summary>
    /// Lycopene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 337, 7530.0)]
    [Display(Name = "Lycopene")]
    Lycopene_Micrograms = 1122,

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
    /// Vitamin E (label entry primarily)
    /// </summary>
    [NutrientsMetadata(Measure.IU, 340, 999999.0)]
    [Display(Name = "Vitamin E (label entry primarily)")]
    Vitamin_E_label_entry_primarily_IU = 1124,

    /// <summary>
    /// Tocopherol, beta
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 341, 8000.0)]
    [Display(Name = "Tocopherol, beta")]
    Tocopherol_beta_Milligrams = 1125,

    /// <summary>
    /// Tocopherol, gamma
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 342, 8100.0)]
    [Display(Name = "Tocopherol, gamma")]
    Tocopherol_gamma_Milligrams = 1126,

    /// <summary>
    /// Tocopherol, delta
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 343, 8200.0)]
    [Display(Name = "Tocopherol, delta")]
    Tocopherol_delta_Milligrams = 1127,

    /// <summary>
    /// Tocotrienol, alpha
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 344, 8300.0)]
    [Display(Name = "Tocotrienol, alpha")]
    Tocotrienol_alpha_Milligrams = 1128,

    /// <summary>
    /// Tocotrienol, beta
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 345, 8400.0)]
    [Display(Name = "Tocotrienol, beta")]
    Tocotrienol_beta_Milligrams = 1129,

    /// <summary>
    /// Tocotrienol, gamma
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 346, 8500.0)]
    [Display(Name = "Tocotrienol, gamma")]
    Tocotrienol_gamma_Milligrams = 1130,

    /// <summary>
    /// Tocotrienol, delta
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 347, 8600.0)]
    [Display(Name = "Tocotrienol, delta")]
    Tocotrienol_delta_Milligrams = 1131,

    /// <summary>
    /// Aluminum, Al
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 348, 999999.0)]
    [Display(Name = "Aluminum, Al")]
    Aluminum_Al_Micrograms = 1132,

    /// <summary>
    /// Antimony, Sb
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 349, 999999.0)]
    [Display(Name = "Antimony, Sb")]
    Antimony_Sb_Micrograms = 1133,

    /// <summary>
    /// Arsenic, As
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 350, 999999.0)]
    [Display(Name = "Arsenic, As")]
    Arsenic_As_Micrograms = 1134,

    /// <summary>
    /// Barium, Ba
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 351, 999999.0)]
    [Display(Name = "Barium, Ba")]
    Barium_Ba_Micrograms = 1135,

    /// <summary>
    /// Beryllium, Be
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 352, 999999.0)]
    [Display(Name = "Beryllium, Be")]
    Beryllium_Be_Micrograms = 1136,

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
    /// Bromine, Br
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 355, 999999.0)]
    [Display(Name = "Bromine, Br")]
    Bromine_Br_Micrograms = 1138,

    /// <summary>
    /// Cadmium, Cd
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 356, 999999.0)]
    [Display(Name = "Cadmium, Cd")]
    Cadmium_Cd_Micrograms = 1139,

    /// <summary>
    /// Gold, Au
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 363, 999999.0)]
    [Display(Name = "Gold, Au")]
    Gold_Au_Micrograms = 1140,

    /// <summary>
    /// Iron, heme
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 364, 999999.0)]
    [Display(Name = "Iron, heme")]
    Iron_heme_Milligrams = 1141,

    /// <summary>
    /// Iron, non-heme
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 365, 999999.0)]
    [Display(Name = "Iron, non-heme")]
    Iron_non_heme_Milligrams = 1142,

    /// <summary>
    /// Lead, Pb
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 367, 999999.0)]
    [Display(Name = "Lead, Pb")]
    Lead_Pb_Micrograms = 1143,

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
    /// Mercury, Hg
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 370, 999999.0)]
    [Display(Name = "Mercury, Hg")]
    Mercury_Hg_Micrograms = 1145,

    /// <summary>
    /// Nickel, Ni
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 371, 6242.0)]
    [Display(Name = "Nickel, Ni")]
    Nickel_Ni_Micrograms = 1146,

    /// <summary>
    /// Rubidium, Rb
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 373, 999999.0)]
    [Display(Name = "Rubidium, Rb")]
    Rubidium_Rb_Micrograms = 1147,

    /// <summary>
    /// Fluoride - DO NOT USE; use 313
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 374, 6250.0)]
    [Display(Name = "Fluoride - DO NOT USE; use 313")]
    Fluoride__DO_NOT_USE_use_313_Micrograms = 1148,

    /// <summary>
    /// Salt, NaCl
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 375, 999999.0)]
    [Display(Name = "Salt, NaCl")]
    Salt_NaCl_Milligrams = 1149,

    /// <summary>
    /// Silicon, Si
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 378, 999999.0)]
    [Display(Name = "Silicon, Si")]
    Silicon_Si_Micrograms = 1150,

    /// <summary>
    /// Silver, Ag
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 379, 999999.0)]
    [Display(Name = "Silver, Ag")]
    Silver_Ag_Micrograms = 1151,

    /// <summary>
    /// Strontium, Sr
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 380, 999999.0)]
    [Display(Name = "Strontium, Sr")]
    Strontium_Sr_Micrograms = 1152,

    /// <summary>
    /// Tin, Sn
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 385, 999999.0)]
    [Display(Name = "Tin, Sn")]
    Tin_Sn_Micrograms = 1153,

    /// <summary>
    /// Titanium, Ti
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 386, 999999.0)]
    [Display(Name = "Titanium, Ti")]
    Titanium_Ti_Micrograms = 1154,

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
    /// Vitamin A, RE
    /// </summary>
    [NutrientsMetadata(Measure.MCG_RE, 392, 7500.0)]
    [Display(Name = "Vitamin A, RE")]
    Vitamin_A_RE_MCG_RE = 1156,

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
    /// cis-beta-Carotene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 321.1, 7442.0)]
    [Display(Name = "cis-beta-Carotene")]
    cis_beta_Carotene_Micrograms = 1159,

    /// <summary>
    /// cis-Lycopene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 337.1, 7532.0)]
    [Display(Name = "cis-Lycopene")]
    cis_Lycopene_Micrograms = 1160,

    /// <summary>
    /// cis-Lutein/Zeaxanthin
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 338.3, 7561.0)]
    [Display(Name = "cis-Lutein/Zeaxanthin")]
    cis_Lutein_Zeaxanthin_Micrograms = 1161,

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
    /// Vitamin C, reduced ascorbic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 402, 999999.0)]
    [Display(Name = "Vitamin C, reduced ascorbic acid")]
    Vitamin_C_reduced_ascorbic_acid_Milligrams = 1163,

    /// <summary>
    /// Vitamin C, dehydro ascorbic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 403, 999999.0)]
    [Display(Name = "Vitamin C, dehydro ascorbic acid")]
    Vitamin_C_dehydro_ascorbic_acid_Milligrams = 1164,

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
    /// Niacin from tryptophan, determined
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 407, 999999.0)]
    [Display(Name = "Niacin from tryptophan, determined")]
    Niacin_from_tryptophan_determined_Milligrams = 1168,

    /// <summary>
    /// Niacin equivalent N406 +N407
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 409, 999999.0)]
    [Display(Name = "Niacin equivalent N406 +N407")]
    Niacin_equivalent_N406_N407_Milligrams = 1169,

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
    /// Vitamin B-6, pyridoxine, alcohol form
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 411, 999999.0)]
    [Display(Name = "Vitamin B-6, pyridoxine, alcohol form")]
    Vitamin_B_6_pyridoxine_alcohol_form_Milligrams = 1171,

    /// <summary>
    /// Vitamin B-6, pyridoxal, aldehyde form
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 412, 999999.0)]
    [Display(Name = "Vitamin B-6, pyridoxal, aldehyde form")]
    Vitamin_B_6_pyridoxal_aldehyde_form_Milligrams = 1172,

    /// <summary>
    /// Vitamin B-6, pyridoxamine, amine form
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 413, 999999.0)]
    [Display(Name = "Vitamin B-6, pyridoxamine, amine form")]
    Vitamin_B_6_pyridoxamine_amine_form_Milligrams = 1173,

    /// <summary>
    /// Vitamin B-6, N411 + N412 +N413
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 414, 999999.0)]
    [Display(Name = "Vitamin B-6, N411 + N412 +N413")]
    Vitamin_B_6_N411__N412_N413_Milligrams = 1174,

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
    /// Folate, free
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 419, 999999.0)]
    [Display(Name = "Folate, free")]
    Folate_free_Micrograms = 1179,

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
    /// Inositol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 422, 2800.0)]
    [Display(Name = "Inositol")]
    Inositol_Milligrams = 1181,

    /// <summary>
    /// Inositol phosphate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 423, 999999.0)]
    [Display(Name = "Inositol phosphate")]
    Inositol_phosphate_Milligrams = 1182,

    /// <summary>
    /// Vitamin K (Menaquinone-4)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 428, 8950.0)]
    [Display(Name = "Vitamin K (Menaquinone-4)")]
    Vitamin_K_Menaquinone_4_Micrograms = 1183,

    /// <summary>
    /// Vitamin K (Dihydrophylloquinone)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 429, 8900.0)]
    [Display(Name = "Vitamin K (Dihydrophylloquinone)")]
    Vitamin_K_Dihydrophylloquinone_Micrograms = 1184,

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
    /// Folic acid
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 431, 7000.0)]
    [Display(Name = "Folic acid")]
    Folic_acid_Micrograms = 1186,

    /// <summary>
    /// Folate, food
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 432, 7100.0)]
    [Display(Name = "Folate, food")]
    Folate_food_Micrograms = 1187,

    /// <summary>
    /// 5-methyl tetrahydrofolate (5-MTHF)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 433, 8975)]
    [Display(Name = "5-methyl tetrahydrofolate (5-MTHF)")]
    _5_methyl_tetrahydrofolate_5_MTHF_Micrograms = 1188,

    /// <summary>
    /// Folate, not 5-MTHF
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 434, 999999.0)]
    [Display(Name = "Folate, not 5-MTHF")]
    Folate_not_5_MTHF_Micrograms = 1189,

    /// <summary>
    /// Folate, DFE
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 435, 7200.0)]
    [Display(Name = "Folate, DFE")]
    Folate_DFE_Micrograms = 1190,

    /// <summary>
    /// 10-Formyl folic acid (10HCOFA)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 436, 999999.0)]
    [Display(Name = "10-Formyl folic acid (10HCOFA)")]
    _10_Formyl_folic_acid_10HCOFA_Micrograms = 1191,

    /// <summary>
    /// 5-Formyltetrahydrofolic acid (5-HCOH4
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 437, 999999.0)]
    [Display(Name = "5-Formyltetrahydrofolic acid (5-HCOH4")]
    _5_Formyltetrahydrofolic_acid_5_HCOH4_Micrograms = 1192,

    /// <summary>
    /// Tetrahydrofolic acid (THF)
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 438, 999999.0)]
    [Display(Name = "Tetrahydrofolic acid (THF)")]
    Tetrahydrofolic_acid_THF_Micrograms = 1193,

    /// <summary>
    /// Choline, free
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 450, 7230.0)]
    [Display(Name = "Choline, free")]
    Choline_free_Milligrams = 1194,

    /// <summary>
    /// Choline, from phosphocholine
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 451, 7240.0)]
    [Display(Name = "Choline, from phosphocholine")]
    Choline_from_phosphocholine_Milligrams = 1195,

    /// <summary>
    /// Choline, from phosphotidyl choline
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 452, 7250.0)]
    [Display(Name = "Choline, from phosphotidyl choline")]
    Choline_from_phosphotidyl_choline_Milligrams = 1196,

    /// <summary>
    /// Choline, from glycerophosphocholine
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 453, 7260.0)]
    [Display(Name = "Choline, from glycerophosphocholine")]
    Choline_from_glycerophosphocholine_Milligrams = 1197,

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
    /// Choline, from sphingomyelin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 455, 7270.0)]
    [Display(Name = "Choline, from sphingomyelin")]
    Choline_from_sphingomyelin_Milligrams = 1199,

    /// <summary>
    /// p-Hydroxy benzoic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 460, 999999.0)]
    [Display(Name = "p-Hydroxy benzoic acid")]
    p_Hydroxy_benzoic_acid_Milligrams = 1200,

    /// <summary>
    /// Caffeic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 461, 999999.0)]
    [Display(Name = "Caffeic acid")]
    Caffeic_acid_Milligrams = 1201,

    /// <summary>
    /// p-Coumaric acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 462, 999999.0)]
    [Display(Name = "p-Coumaric acid")]
    p_Coumaric_acid_Milligrams = 1202,

    /// <summary>
    /// Ellagic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 463, 999999.0)]
    [Display(Name = "Ellagic acid")]
    Ellagic_acid_Milligrams = 1203,

    /// <summary>
    /// Ferrulic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 464, 999999.0)]
    [Display(Name = "Ferrulic acid")]
    Ferrulic_acid_Milligrams = 1204,

    /// <summary>
    /// Gentisic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 465, 999999.0)]
    [Display(Name = "Gentisic acid")]
    Gentisic_acid_Milligrams = 1205,

    /// <summary>
    /// Tyrosol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 466, 999999.0)]
    [Display(Name = "Tyrosol")]
    Tyrosol_Milligrams = 1206,

    /// <summary>
    /// Vanillic acid
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 467, 999999.0)]
    [Display(Name = "Vanillic acid")]
    Vanillic_acid_Milligrams = 1207,

    /// <summary>
    /// Phenolic acids, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 469, 999999.0)]
    [Display(Name = "Phenolic acids, total")]
    Phenolic_acids_total_Milligrams = 1208,

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
    /// Cystine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 507, 16900.0)]
    [Display(Name = "Cystine")]
    Cystine_Grams = 1216,

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
    /// Tyrosine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 509, 17100.0)]
    [Display(Name = "Tyrosine")]
    Tyrosine_Grams = 1218,

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
    /// Alanine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 513, 17500.0)]
    [Display(Name = "Alanine")]
    Alanine_Grams = 1222,

    /// <summary>
    /// Aspartic acid
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 514, 17600.0)]
    [Display(Name = "Aspartic acid")]
    Aspartic_acid_Grams = 1223,

    /// <summary>
    /// Glutamic acid
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 515, 17700.0)]
    [Display(Name = "Glutamic acid")]
    Glutamic_acid_Grams = 1224,

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
    /// Proline
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 517, 17900.0)]
    [Display(Name = "Proline")]
    Proline_Grams = 1226,

    /// <summary>
    /// Serine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 518, 18000.0)]
    [Display(Name = "Serine")]
    Serine_Grams = 1227,

    /// <summary>
    /// Hydroxyproline
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 521, 18100.0)]
    [Display(Name = "Hydroxyproline")]
    Hydroxyproline_Grams = 1228,

    /// <summary>
    /// Cysteine and methionine(sulfer containig AA)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 522, 999999.0)]
    [Display(Name = "Cysteine and methionine(sulfer containig AA)")]
    Cysteine_and_methionine_sulfer_containig_AA_Grams = 1229,

    /// <summary>
    /// Phenylalanine and tyrosine (aromatic  AA)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 523, 16950.0)]
    [Display(Name = "Phenylalanine and tyrosine (aromatic  AA)")]
    Phenylalanine_and_tyrosine_aromatic_AA_Grams = 1230,

    /// <summary>
    /// Asparagine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 525, 999999.0)]
    [Display(Name = "Asparagine")]
    Asparagine_Grams = 1231,

    /// <summary>
    /// Cysteine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 526, 18150.0)]
    [Display(Name = "Cysteine")]
    Cysteine_Grams = 1232,

    /// <summary>
    /// Glutamine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 528, 999999.0)]
    [Display(Name = "Glutamine")]
    Glutamine_Grams = 1233,

    /// <summary>
    /// Taurine
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 529, 999999.0)]
    [Display(Name = "Taurine")]
    Taurine_Grams = 1234,

    /// <summary>
    /// Sugars, added
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 539, 1540.0)]
    [Display(Name = "Sugars, added")]
    Sugars_added_Grams = 1235,

    /// <summary>
    /// Sugars, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 549, 1520.0)]
    [Display(Name = "Sugars, intrinsic")]
    Sugars_intrinsic_Grams = 1236,

    /// <summary>
    /// Calcium, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 551, 5340.0)]
    [Display(Name = "Calcium, added")]
    Calcium_added_Milligrams = 1237,

    /// <summary>
    /// Iron, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 553, 5440.0)]
    [Display(Name = "Iron, added")]
    Iron_added_Milligrams = 1238,

    /// <summary>
    /// Calcium, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 561, 5320.0)]
    [Display(Name = "Calcium, intrinsic")]
    Calcium_intrinsic_Milligrams = 1239,

    /// <summary>
    /// Iron, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 563, 5420.0)]
    [Display(Name = "Iron, intrinsic")]
    Iron_intrinsic_Milligrams = 1240,

    /// <summary>
    /// Vitamin C, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 571, 6340.0)]
    [Display(Name = "Vitamin C, added")]
    Vitamin_C_added_Milligrams = 1241,

    /// <summary>
    /// Vitamin E, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 573, 7920.0)]
    [Display(Name = "Vitamin E, added")]
    Vitamin_E_added_Milligrams = 1242,

    /// <summary>
    /// Thiamin, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 574, 6440.0)]
    [Display(Name = "Thiamin, added")]
    Thiamin_added_Milligrams = 1243,

    /// <summary>
    /// Riboflavin, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 575, 6540.0)]
    [Display(Name = "Riboflavin, added")]
    Riboflavin_added_Milligrams = 1244,

    /// <summary>
    /// Niacin, added
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 576, 6640.0)]
    [Display(Name = "Niacin, added")]
    Niacin_added_Milligrams = 1245,

    /// <summary>
    /// Vitamin B-12, added
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 578, 7340.0)]
    [Display(Name = "Vitamin B-12, added")]
    Vitamin_B_12_added_Micrograms = 1246,

    /// <summary>
    /// Vitamin C, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 581, 6320.0)]
    [Display(Name = "Vitamin C, intrinsic")]
    Vitamin_C_intrinsic_Milligrams = 1247,

    /// <summary>
    /// Vitamin E, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 583, 7930.0)]
    [Display(Name = "Vitamin E, intrinsic")]
    Vitamin_E_intrinsic_Milligrams = 1248,

    /// <summary>
    /// Thiamin, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 584, 6420.0)]
    [Display(Name = "Thiamin, intrinsic")]
    Thiamin_intrinsic_Milligrams = 1249,

    /// <summary>
    /// Riboflavin, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 585, 6520.0)]
    [Display(Name = "Riboflavin, intrinsic")]
    Riboflavin_intrinsic_Milligrams = 1250,

    /// <summary>
    /// Niacin, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 586, 6620.0)]
    [Display(Name = "Niacin, intrinsic")]
    Niacin_intrinsic_Milligrams = 1251,

    /// <summary>
    /// Vitamin B-12, intrinsic
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 588, 7320.0)]
    [Display(Name = "Vitamin B-12, intrinsic")]
    Vitamin_B_12_intrinsic_Micrograms = 1252,

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
    /// Glycerides
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 602, 999999.0)]
    [Display(Name = "Glycerides")]
    Glycerides_Grams = 1254,

    /// <summary>
    /// Phospholipids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 603, 999999.0)]
    [Display(Name = "Phospholipids")]
    Phospholipids_Grams = 1255,

    /// <summary>
    /// Glycolipids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 604, 999999.0)]
    [Display(Name = "Glycolipids")]
    Glycolipids_Grams = 1256,

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
    /// SFA 4:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 607, 9800.0)]
    [Display(Name = "SFA 4:0")]
    SFA_4_0_Grams = 1259,

    /// <summary>
    /// SFA 6:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 608, 9900.0)]
    [Display(Name = "SFA 6:0")]
    SFA_6_0_Grams = 1260,

    /// <summary>
    /// SFA 8:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 609, 10000.0)]
    [Display(Name = "SFA 8:0")]
    SFA_8_0_Grams = 1261,

    /// <summary>
    /// SFA 10:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 610, 10100.0)]
    [Display(Name = "SFA 10:0")]
    SFA_10_0_Grams = 1262,

    /// <summary>
    /// SFA 12:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 611, 10300.0)]
    [Display(Name = "SFA 12:0")]
    SFA_12_0_Grams = 1263,

    /// <summary>
    /// SFA 14:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 612, 10500.0)]
    [Display(Name = "SFA 14:0")]
    SFA_14_0_Grams = 1264,

    /// <summary>
    /// SFA 16:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 613, 10700.0)]
    [Display(Name = "SFA 16:0")]
    SFA_16_0_Grams = 1265,

    /// <summary>
    /// SFA 18:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 614, 10900.0)]
    [Display(Name = "SFA 18:0")]
    SFA_18_0_Grams = 1266,

    /// <summary>
    /// SFA 20:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 615, 11100.0)]
    [Display(Name = "SFA 20:0")]
    SFA_20_0_Grams = 1267,

    /// <summary>
    /// MUFA 18:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 617, 12100.0)]
    [Display(Name = "MUFA 18:1")]
    MUFA_18_1_Grams = 1268,

    /// <summary>
    /// PUFA 18:2
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 618, 13100.0)]
    [Display(Name = "PUFA 18:2")]
    PUFA_18_2_Grams = 1269,

    /// <summary>
    /// PUFA 18:3
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 619, 13900.0)]
    [Display(Name = "PUFA 18:3")]
    PUFA_18_3_Grams = 1270,

    /// <summary>
    /// PUFA 20:4
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 620, 14700.0)]
    [Display(Name = "PUFA 20:4")]
    PUFA_20_4_Grams = 1271,

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
    /// SFA 22:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 624, 11200.0)]
    [Display(Name = "SFA 22:0")]
    SFA_22_0_Grams = 1273,

    /// <summary>
    /// MUFA 14:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 625, 11500.0)]
    [Display(Name = "MUFA 14:1")]
    MUFA_14_1_Grams = 1274,

    /// <summary>
    /// MUFA 16:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 626, 11700.0)]
    [Display(Name = "MUFA 16:1")]
    MUFA_16_1_Grams = 1275,

    /// <summary>
    /// PUFA 18:4
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 627, 14250.0)]
    [Display(Name = "PUFA 18:4")]
    PUFA_18_4_Grams = 1276,

    /// <summary>
    /// MUFA 20:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 628, 12400.0)]
    [Display(Name = "MUFA 20:1")]
    MUFA_20_1_Grams = 1277,

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
    /// MUFA 22:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 630, 12500.0)]
    [Display(Name = "MUFA 22:1")]
    MUFA_22_1_Grams = 1279,

    /// <summary>
    /// PUFA 22:5 n-3 (DPA)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 631, 15200.0)]
    [Display(Name = "PUFA 22:5 n-3 (DPA)")]
    PUFA_22_5_n_3_DPA_Grams = 1280,

    /// <summary>
    /// TFA 14:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 821, 15510.0)]
    [Display(Name = "TFA 14:1 t")]
    TFA_14_1_t_Grams = 1281,

    /// <summary>
    /// Phytosterols
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 636, 15800.0)]
    [Display(Name = "Phytosterols")]
    Phytosterols_Milligrams = 1283,

    /// <summary>
    /// Ergosterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 637, 16220.0)]
    [Display(Name = "Ergosterol")]
    Ergosterol_Milligrams = 1284,

    /// <summary>
    /// Stigmasterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 638, 15900.0)]
    [Display(Name = "Stigmasterol")]
    Stigmasterol_Milligrams = 1285,

    /// <summary>
    /// Campesterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 639, 16000.0)]
    [Display(Name = "Campesterol")]
    Campesterol_Milligrams = 1286,

    /// <summary>
    /// Brassicasterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 640, 16100.0)]
    [Display(Name = "Brassicasterol")]
    Brassicasterol_Milligrams = 1287,

    /// <summary>
    /// Beta-sitosterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 641, 16200.0)]
    [Display(Name = "Beta-sitosterol")]
    Beta_sitosterol_Milligrams = 1288,

    /// <summary>
    /// Campestanol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 642, 16221.0)]
    [Display(Name = "Campestanol")]
    Campestanol_Milligrams = 1289,

    /// <summary>
    /// Unsaponifiable matter (lipids)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 643, 999999.0)]
    [Display(Name = "Unsaponifiable matter (lipids)")]
    Unsaponifiable_matter_lipids_Grams = 1290,

    /// <summary>
    /// Fatty acids, other than 607-615, 617-621, 624-632, 652-654, 686-689)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 644, 999999.0)]
    [Display(Name = "Fatty acids, other than 607-615, 617-621, 624-632, 652-654, 686-689)")]
    Fatty_acids_other_than_607_615_617_621_624_632_652_654_686_689_Grams = 1291,

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
    /// Beta-sitostanol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 647, 16222.0)]
    [Display(Name = "Beta-sitostanol")]
    Beta_sitostanol_Milligrams = 1294,

    /// <summary>
    /// Delta-7-avenasterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 648, 16223.0)]
    [Display(Name = "Delta-7-avenasterol")]
    Delta_7_avenasterol_Milligrams = 1295,

    /// <summary>
    /// Delta-5-avenasterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 649, 16224.0)]
    [Display(Name = "Delta-5-avenasterol")]
    Delta_5_avenasterol_Milligrams = 1296,

    /// <summary>
    /// Alpha-spinasterol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 650, 16225.0)]
    [Display(Name = "Alpha-spinasterol")]
    Alpha_spinasterol_Milligrams = 1297,

    /// <summary>
    /// Phytosterols, other
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 651, 16227.0)]
    [Display(Name = "Phytosterols, other")]
    Phytosterols_other_Milligrams = 1298,

    /// <summary>
    /// SFA 15:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 652, 10600.0)]
    [Display(Name = "SFA 15:0")]
    SFA_15_0_Grams = 1299,

    /// <summary>
    /// SFA 17:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 653, 10800.0)]
    [Display(Name = "SFA 17:0")]
    SFA_17_0_Grams = 1300,

    /// <summary>
    /// SFA 24:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 654, 11300.0)]
    [Display(Name = "SFA 24:0")]
    SFA_24_0_Grams = 1301,

    /// <summary>
    /// Wax Esters(Total Wax)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 661, 999999.0)]
    [Display(Name = "Wax Esters(Total Wax)")]
    Wax_Esters_Total_Wax_Grams = 1302,

    /// <summary>
    /// TFA 16:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 662, 15520.0)]
    [Display(Name = "TFA 16:1 t")]
    TFA_16_1_t_Grams = 1303,

    /// <summary>
    /// TFA 18:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 663, 15521.0)]
    [Display(Name = "TFA 18:1 t")]
    TFA_18_1_t_Grams = 1304,

    /// <summary>
    /// TFA 22:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 664, 15550.0)]
    [Display(Name = "TFA 22:1 t")]
    TFA_22_1_t_Grams = 1305,

    /// <summary>
    /// TFA 18:2 t not further defined
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 665, 15610.0)]
    [Display(Name = "TFA 18:2 t not further defined")]
    TFA_18_2_t_not_further_defined_Grams = 1306,

    /// <summary>
    /// PUFA 18:2 i
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 666, 13350.0)]
    [Display(Name = "PUFA 18:2 i")]
    PUFA_18_2_i_Grams = 1307,

    /// <summary>
    /// PUFA 18:2 t,c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 667, 13500.0)]
    [Display(Name = "PUFA 18:2 t,c")]
    PUFA_18_2_t_c_Grams = 1308,

    /// <summary>
    /// PUFA 18:2 c,t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 668, 13400.0)]
    [Display(Name = "PUFA 18:2 c,t")]
    PUFA_18_2_c_t_Grams = 1309,

    /// <summary>
    /// TFA 18:2 t,t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 669, 15615.0)]
    [Display(Name = "TFA 18:2 t,t")]
    TFA_18_2_t_t_Grams = 1310,

    /// <summary>
    /// PUFA 18:2 CLAs
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 670, 13300.0)]
    [Display(Name = "PUFA 18:2 CLAs")]
    PUFA_18_2_CLAs_Grams = 1311,

    /// <summary>
    /// MUFA 24:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 671, 12800.0)]
    [Display(Name = "MUFA 24:1 c")]
    MUFA_24_1_c_Grams = 1312,

    /// <summary>
    /// PUFA 20:2 n-6 c,c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 672, 14300.0)]
    [Display(Name = "PUFA 20:2 n-6 c,c")]
    PUFA_20_2_n_6_c_c_Grams = 1313,

    /// <summary>
    /// MUFA 16:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 673, 11800.0)]
    [Display(Name = "MUFA 16:1 c")]
    MUFA_16_1_c_Grams = 1314,

    /// <summary>
    /// MUFA 18:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 674, 12200.0)]
    [Display(Name = "MUFA 18:1 c")]
    MUFA_18_1_c_Grams = 1315,

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
    /// MUFA 22:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 676, 12600.0)]
    [Display(Name = "MUFA 22:1 c")]
    MUFA_22_1_c_Grams = 1317,

    /// <summary>
    /// Fatty acids, saturated, other
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 677, 999999.0)]
    [Display(Name = "Fatty acids, saturated, other")]
    Fatty_acids_saturated_other_Grams = 1318,

    /// <summary>
    /// Fatty acids, monounsat., other
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 678, 999999.0)]
    [Display(Name = "Fatty acids, monounsat., other")]
    Fatty_acids_monounsat__other_Grams = 1319,

    /// <summary>
    /// Fatty acids, polyunsat., other
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 679, 999999.0)]
    [Display(Name = "Fatty acids, polyunsat., other")]
    Fatty_acids_polyunsat__other_Grams = 1320,

    /// <summary>
    /// PUFA 18:3 n-6 c,c,c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 685, 14100.0)]
    [Display(Name = "PUFA 18:3 n-6 c,c,c")]
    PUFA_18_3_n_6_c_c_c_Grams = 1321,

    /// <summary>
    /// SFA 19:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 686, 11000.0)]
    [Display(Name = "SFA 19:0")]
    SFA_19_0_Grams = 1322,

    /// <summary>
    /// MUFA 17:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 687, 12000.0)]
    [Display(Name = "MUFA 17:1")]
    MUFA_17_1_Grams = 1323,

    /// <summary>
    /// PUFA 16:2
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 688, 13000.0)]
    [Display(Name = "PUFA 16:2")]
    PUFA_16_2_Grams = 1324,

    /// <summary>
    /// PUFA 20:3
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 689, 14400.0)]
    [Display(Name = "PUFA 20:3")]
    PUFA_20_3_Grams = 1325,

    /// <summary>
    /// Fatty acids, total sat., NLEA
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 690, 999999.0)]
    [Display(Name = "Fatty acids, total sat., NLEA")]
    Fatty_acids_total_sat__NLEA_Grams = 1326,

    /// <summary>
    /// Fatty acids, total monounsat., NLEA
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 691, 999999.0)]
    [Display(Name = "Fatty acids, total monounsat., NLEA")]
    Fatty_acids_total_monounsat__NLEA_Grams = 1327,

    /// <summary>
    /// Fatty acids, total polyunsat., NLEA
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 692, 999999.0)]
    [Display(Name = "Fatty acids, total polyunsat., NLEA")]
    Fatty_acids_total_polyunsat__NLEA_Grams = 1328,

    /// <summary>
    /// Fatty acids, total trans-monoenoic
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 693, 15500.0)]
    [Display(Name = "Fatty acids, total trans-monoenoic")]
    Fatty_acids_total_trans_monoenoic_Grams = 1329,

    /// <summary>
    /// Fatty acids, total trans-dienoic
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 694, 15601.0)]
    [Display(Name = "Fatty acids, total trans-dienoic")]
    Fatty_acids_total_trans_dienoic_Grams = 1330,

    /// <summary>
    /// Fatty acids, total trans-polyenoic
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 695, 15619.0)]
    [Display(Name = "Fatty acids, total trans-polyenoic")]
    Fatty_acids_total_trans_polyenoic_Grams = 1331,

    /// <summary>
    /// SFA 13:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 696, 10400.0)]
    [Display(Name = "SFA 13:0")]
    SFA_13_0_Grams = 1332,

    /// <summary>
    /// MUFA 15:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 697, 11600.0)]
    [Display(Name = "MUFA 15:1")]
    MUFA_15_1_Grams = 1333,

    /// <summary>
    /// PUFA 22:2
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 698, 15100.0)]
    [Display(Name = "PUFA 22:2")]
    PUFA_22_2_Grams = 1334,

    /// <summary>
    /// SFA 11:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 699, 10200.0)]
    [Display(Name = "SFA 11:0")]
    SFA_11_0_Grams = 1335,

    /// <summary>
    /// ORAC, Hydrophyllic
    /// </summary>
    [NutrientsMetadata(Measure.UMOL_TE, 706, -1)]
    [Display(Name = "ORAC, Hydrophyllic")]
    ORAC_Hydrophyllic_UMOL_TE = 1336,

    /// <summary>
    /// ORAC, Lipophillic
    /// </summary>
    [NutrientsMetadata(Measure.UMOL_TE, 707, -1)]
    [Display(Name = "ORAC, Lipophillic")]
    ORAC_Lipophillic_UMOL_TE = 1337,

    /// <summary>
    /// ORAC, Total
    /// </summary>
    [NutrientsMetadata(Measure.UMOL_TE, 708, -1)]
    [Display(Name = "ORAC, Total")]
    ORAC_Total_UMOL_TE = 1338,

    /// <summary>
    /// Total Phenolics
    /// </summary>
    [NutrientsMetadata(Measure.MG_GAE, 709, -1)]
    [Display(Name = "Total Phenolics")]
    Total_Phenolics_MG_GAE = 1339,

    /// <summary>
    /// Daidzein
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 710, 19100.0)]
    [Display(Name = "Daidzein")]
    Daidzein_Milligrams = 1340,

    /// <summary>
    /// Genistein
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 711, 19200.0)]
    [Display(Name = "Genistein")]
    Genistein_Milligrams = 1341,

    /// <summary>
    /// Glycitein
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 712, 19300.0)]
    [Display(Name = "Glycitein")]
    Glycitein_Milligrams = 1342,

    /// <summary>
    /// Isoflavones
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 713, 19000.0)]
    [Display(Name = "Isoflavones")]
    Isoflavones_Milligrams = 1343,

    /// <summary>
    /// Biochanin A
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 714, 999999.0)]
    [Display(Name = "Biochanin A")]
    Biochanin_A_Milligrams = 1344,

    /// <summary>
    /// Formononetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 715, 999999.0)]
    [Display(Name = "Formononetin")]
    Formononetin_Milligrams = 1345,

    /// <summary>
    /// Coumestrol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 716, 999999.0)]
    [Display(Name = "Coumestrol")]
    Coumestrol_Milligrams = 1346,

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
    /// Anthocyanidins
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 730, 19400.0)]
    [Display(Name = "Anthocyanidins")]
    Anthocyanidins_Milligrams = 1348,

    /// <summary>
    /// Cyanidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 731, 19500.0)]
    [Display(Name = "Cyanidin")]
    Cyanidin_Milligrams = 1349,

    /// <summary>
    /// Proanthocyanidin (dimer-A linkage)
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 732, 19510.0)]
    [Display(Name = "Proanthocyanidin (dimer-A linkage)")]
    Proanthocyanidin_dimer_A_linkage_Milligrams = 1350,

    /// <summary>
    /// Proanthocyanidin monomers
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 733, 19520.0)]
    [Display(Name = "Proanthocyanidin monomers")]
    Proanthocyanidin_monomers_Milligrams = 1351,

    /// <summary>
    /// Proanthocyanidin dimers
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 734, 19530.0)]
    [Display(Name = "Proanthocyanidin dimers")]
    Proanthocyanidin_dimers_Milligrams = 1352,

    /// <summary>
    /// Proanthocyanidin trimers
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 735, 19540.0)]
    [Display(Name = "Proanthocyanidin trimers")]
    Proanthocyanidin_trimers_Milligrams = 1353,

    /// <summary>
    /// Proanthocyanidin 4-6mers
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 736, 19550.0)]
    [Display(Name = "Proanthocyanidin 4-6mers")]
    Proanthocyanidin_4_6mers_Milligrams = 1354,

    /// <summary>
    /// Proanthocyanidin 7-10mers
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 737, 19560.0)]
    [Display(Name = "Proanthocyanidin 7-10mers")]
    Proanthocyanidin_7_10mers_Milligrams = 1355,

    /// <summary>
    /// Proanthocyanidin polymers (>10mers)
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 738, 19570.0)]
    [Display(Name = "Proanthocyanidin polymers (>10mers)")]
    Proanthocyanidin_polymers__10mers_Milligrams = 1356,

    /// <summary>
    /// Delphinidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 741, 19600.0)]
    [Display(Name = "Delphinidin")]
    Delphinidin_Milligrams = 1357,

    /// <summary>
    /// Malvidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 742, 19700.0)]
    [Display(Name = "Malvidin")]
    Malvidin_Milligrams = 1358,

    /// <summary>
    /// Pelargonidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 743, 19800.0)]
    [Display(Name = "Pelargonidin")]
    Pelargonidin_Milligrams = 1359,

    /// <summary>
    /// Peonidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 745, 19900.0)]
    [Display(Name = "Peonidin")]
    Peonidin_Milligrams = 1360,

    /// <summary>
    /// Petunidin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 746, 20000.0)]
    [Display(Name = "Petunidin")]
    Petunidin_Milligrams = 1361,

    /// <summary>
    /// Flavans, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 747, 20100.0)]
    [Display(Name = "Flavans, total")]
    Flavans_total_Milligrams = 1362,

    /// <summary>
    /// Catechins, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 748, 20200.0)]
    [Display(Name = "Catechins, total")]
    Catechins_total_Milligrams = 1363,

    /// <summary>
    /// Catechin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 749, 20300.0)]
    [Display(Name = "Catechin")]
    Catechin_Milligrams = 1364,

    /// <summary>
    /// Epigallocatechin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 750, 20400.0)]
    [Display(Name = "Epigallocatechin")]
    Epigallocatechin_Milligrams = 1365,

    /// <summary>
    /// Epicatechin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 751, 20500.0)]
    [Display(Name = "Epicatechin")]
    Epicatechin_Milligrams = 1366,

    /// <summary>
    /// Epicatechin-3-gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 752, 20600.0)]
    [Display(Name = "Epicatechin-3-gallate")]
    Epicatechin_3_gallate_Milligrams = 1367,

    /// <summary>
    /// Epigallocatechin-3-gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 753, 20700.0)]
    [Display(Name = "Epigallocatechin-3-gallate")]
    Epigallocatechin_3_gallate_Milligrams = 1368,

    /// <summary>
    /// Procyanidins, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 754, 20800.0)]
    [Display(Name = "Procyanidins, total")]
    Procyanidins_total_Milligrams = 1369,

    /// <summary>
    /// Theaflavins
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 755, 20900.0)]
    [Display(Name = "Theaflavins")]
    Theaflavins_Milligrams = 1370,

    /// <summary>
    /// Thearubigins
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 756, 21000.0)]
    [Display(Name = "Thearubigins")]
    Thearubigins_Milligrams = 1371,

    /// <summary>
    /// Flavanones, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 757, 21200.0)]
    [Display(Name = "Flavanones, total")]
    Flavanones_total_Milligrams = 1372,

    /// <summary>
    /// Eriodictyol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 758, 21300.0)]
    [Display(Name = "Eriodictyol")]
    Eriodictyol_Milligrams = 1373,

    /// <summary>
    /// Hesperetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 759, 21400.0)]
    [Display(Name = "Hesperetin")]
    Hesperetin_Milligrams = 1374,

    /// <summary>
    /// Isosakuranetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 760, 21500.0)]
    [Display(Name = "Isosakuranetin")]
    Isosakuranetin_Milligrams = 1375,

    /// <summary>
    /// Liquiritigenin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 761, 21600.0)]
    [Display(Name = "Liquiritigenin")]
    Liquiritigenin_Milligrams = 1376,

    /// <summary>
    /// Naringenin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 762, 21700.0)]
    [Display(Name = "Naringenin")]
    Naringenin_Milligrams = 1377,

    /// <summary>
    /// Flavones, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 768, 21800.0)]
    [Display(Name = "Flavones, total")]
    Flavones_total_Milligrams = 1378,

    /// <summary>
    /// Apigenin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 770, 21900.0)]
    [Display(Name = "Apigenin")]
    Apigenin_Milligrams = 1379,

    /// <summary>
    /// Chrysoeriol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 771, 22000.0)]
    [Display(Name = "Chrysoeriol")]
    Chrysoeriol_Milligrams = 1380,

    /// <summary>
    /// Diosmetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 772, 22100.0)]
    [Display(Name = "Diosmetin")]
    Diosmetin_Milligrams = 1381,

    /// <summary>
    /// Luteolin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 773, 22200.0)]
    [Display(Name = "Luteolin")]
    Luteolin_Milligrams = 1382,

    /// <summary>
    /// Nobiletin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 781, 22300.0)]
    [Display(Name = "Nobiletin")]
    Nobiletin_Milligrams = 1383,

    /// <summary>
    /// Sinensetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 782, 22400.0)]
    [Display(Name = "Sinensetin")]
    Sinensetin_Milligrams = 1384,

    /// <summary>
    /// Tangeretin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 783, 22500.0)]
    [Display(Name = "Tangeretin")]
    Tangeretin_Milligrams = 1385,

    /// <summary>
    /// Flavonols, total
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 784, 22600.0)]
    [Display(Name = "Flavonols, total")]
    Flavonols_total_Milligrams = 1386,

    /// <summary>
    /// Isorhamnetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 785, 22700.0)]
    [Display(Name = "Isorhamnetin")]
    Isorhamnetin_Milligrams = 1387,

    /// <summary>
    /// Kaempferol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 786, 22800.0)]
    [Display(Name = "Kaempferol")]
    Kaempferol_Milligrams = 1388,

    /// <summary>
    /// Limocitrin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 787, 22900.0)]
    [Display(Name = "Limocitrin")]
    Limocitrin_Milligrams = 1389,

    /// <summary>
    /// Myricetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 788, 23000.0)]
    [Display(Name = "Myricetin")]
    Myricetin_Milligrams = 1390,

    /// <summary>
    /// Quercetin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 789, 23100.0)]
    [Display(Name = "Quercetin")]
    Quercetin_Milligrams = 1391,

    /// <summary>
    /// Theogallin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 790, 21100.0)]
    [Display(Name = "Theogallin")]
    Theogallin_Milligrams = 1392,

    /// <summary>
    /// Theaflavin -3,3' -digallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 791, -1)]
    [Display(Name = "Theaflavin -3,3' -digallate")]
    Theaflavin_3_3__digallate_Milligrams = 1393,

    /// <summary>
    /// Theaflavin -3' -gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 792, -1)]
    [Display(Name = "Theaflavin -3' -gallate")]
    Theaflavin_3__gallate_Milligrams = 1394,

    /// <summary>
    /// Theaflavin -3 -gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 793, -1)]
    [Display(Name = "Theaflavin -3 -gallate")]
    Theaflavin_3_gallate_Milligrams = 1395,

    /// <summary>
    /// (+) -Gallo catechin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 794, -1)]
    [Display(Name = "(+) -Gallo catechin")]
    Gallo_catechin_Milligrams = 1396,

    /// <summary>
    /// (+)-Catechin 3-gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 795, -1)]
    [Display(Name = "(+)-Catechin 3-gallate")]
    Catechin_3_gallate_Milligrams = 1397,

    /// <summary>
    /// (+)-Gallocatechin 3-gallate
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 796, -1)]
    [Display(Name = "(+)-Gallocatechin 3-gallate")]
    Gallocatechin_3_gallate_Milligrams = 1398,

    /// <summary>
    /// Mannose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 801, 999999.0)]
    [Display(Name = "Mannose")]
    Mannose_Grams = 1399,

    /// <summary>
    /// Triose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 803, 999999.0)]
    [Display(Name = "Triose")]
    Triose_Grams = 1400,

    /// <summary>
    /// Tetrose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 804, 999999.0)]
    [Display(Name = "Tetrose")]
    Tetrose_Grams = 1401,

    /// <summary>
    /// Other Saccharides
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 805, 999999.0)]
    [Display(Name = "Other Saccharides")]
    Other_Saccharides_Grams = 1402,

    /// <summary>
    /// Inulin
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 806, 999999.0)]
    [Display(Name = "Inulin")]
    Inulin_Grams = 1403,

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
    /// PUFA 20:3 n-3
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 852, 14500.0)]
    [Display(Name = "PUFA 20:3 n-3")]
    PUFA_20_3_n_3_Grams = 1405,

    /// <summary>
    /// PUFA 20:3 n-6
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 853, 14600.0)]
    [Display(Name = "PUFA 20:3 n-6")]
    PUFA_20_3_n_6_Grams = 1406,

    /// <summary>
    /// PUFA 20:4 n-3
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 854, 14800.0)]
    [Display(Name = "PUFA 20:4 n-3")]
    PUFA_20_4_n_3_Grams = 1407,

    /// <summary>
    /// PUFA 20:4 n-6
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 855, 14900.0)]
    [Display(Name = "PUFA 20:4 n-6")]
    PUFA_20_4_n_6_Grams = 1408,

    /// <summary>
    /// PUFA 18:3i
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 856, 14200.0)]
    [Display(Name = "PUFA 18:3i")]
    PUFA_18_3i_Grams = 1409,

    /// <summary>
    /// PUFA 21:5
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 857, 15100.0)]
    [Display(Name = "PUFA 21:5")]
    PUFA_21_5_Grams = 1410,

    /// <summary>
    /// PUFA 22:4
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 858, 15160.0)]
    [Display(Name = "PUFA 22:4")]
    PUFA_22_4_Grams = 1411,

    /// <summary>
    /// MUFA 18:1-11 t (18:1t n-7)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 859, 12310.0)]
    [Display(Name = "MUFA 18:1-11 t (18:1t n-7)")]
    MUFA_18_1_11_t_18_1t_n_7_Grams = 1412,

    /// <summary>
    /// MUFA 18:1-11 c (18:1c n-7)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 860, 12210.0)]
    [Display(Name = "MUFA 18:1-11 c (18:1c n-7)")]
    MUFA_18_1_11_c_18_1c_n_7_Grams = 1413,

    /// <summary>
    /// PUFA 20:3 n-9
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 861, 14650.0)]
    [Display(Name = "PUFA 20:3 n-9")]
    PUFA_20_3_n_9_Grams = 1414,

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
    /// SFA 5:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 632, 9850.0)]
    [Display(Name = "SFA 5:0")]
    SFA_5_0_Grams = 2003,

    /// <summary>
    /// SFA 7:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 633, 9950.0)]
    [Display(Name = "SFA 7:0")]
    SFA_7_0_Grams = 2004,

    /// <summary>
    /// SFA 9:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 634, 10050.0)]
    [Display(Name = "SFA 9:0")]
    SFA_9_0_Grams = 2005,

    /// <summary>
    /// SFA 21:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 681, 11150.0)]
    [Display(Name = "SFA 21:0")]
    SFA_21_0_Grams = 2006,

    /// <summary>
    /// SFA 23:0
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 682, 11250.0)]
    [Display(Name = "SFA 23:0")]
    SFA_23_0_Grams = 2007,

    /// <summary>
    /// MUFA 12:1
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 635, 11450.0)]
    [Display(Name = "MUFA 12:1")]
    MUFA_12_1_Grams = 2008,

    /// <summary>
    /// MUFA 14:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 822, 11501.0)]
    [Display(Name = "MUFA 14:1 c")]
    MUFA_14_1_c_Grams = 2009,

    /// <summary>
    /// MUFA 17:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 825, 12001.0)]
    [Display(Name = "MUFA 17:1 c")]
    MUFA_17_1_c_Grams = 2010,

    /// <summary>
    /// TFA 17:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 826, 15525.0)]
    [Display(Name = "TFA 17:1 t")]
    TFA_17_1_t_Grams = 2011,

    /// <summary>
    /// MUFA 20:1 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 829, 12401.0)]
    [Display(Name = "MUFA 20:1 c")]
    MUFA_20_1_c_Grams = 2012,

    /// <summary>
    /// TFA 20:1 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 830, 15540.0)]
    [Display(Name = "TFA 20:1 t")]
    TFA_20_1_t_Grams = 2013,

    /// <summary>
    /// MUFA 22:1 n-9
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 676.1, 12601.0)]
    [Display(Name = "MUFA 22:1 n-9")]
    MUFA_22_1_n_9_Grams = 2014,

    /// <summary>
    /// MUFA 22:1 n-11
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 676.2, 12602.0)]
    [Display(Name = "MUFA 22:1 n-11")]
    MUFA_22_1_n_11_Grams = 2015,

    /// <summary>
    /// PUFA 18:2 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 831, 13150.0)]
    [Display(Name = "PUFA 18:2 c")]
    PUFA_18_2_c_Grams = 2016,

    /// <summary>
    /// TFA 18:2 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 832, 15611.0)]
    [Display(Name = "TFA 18:2 t")]
    TFA_18_2_t_Grams = 2017,

    /// <summary>
    /// PUFA 18:3 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 833, 13910.0)]
    [Display(Name = "PUFA 18:3 c")]
    PUFA_18_3_c_Grams = 2018,

    /// <summary>
    /// TFA 18:3 t
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 834, 15660.0)]
    [Display(Name = "TFA 18:3 t")]
    TFA_18_3_t_Grams = 2019,

    /// <summary>
    /// PUFA 20:3 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 835, 14450.0)]
    [Display(Name = "PUFA 20:3 c")]
    PUFA_20_3_c_Grams = 2020,

    /// <summary>
    /// PUFA 22:3
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 683, 14675.0)]
    [Display(Name = "PUFA 22:3")]
    PUFA_22_3_Grams = 2021,

    /// <summary>
    /// PUFA 20:4c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 836, 14750.0)]
    [Display(Name = "PUFA 20:4c")]
    PUFA_20_4c_Grams = 2022,

    /// <summary>
    /// PUFA 20:5c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 837, 14950.0)]
    [Display(Name = "PUFA 20:5c")]
    PUFA_20_5c_Grams = 2023,

    /// <summary>
    /// PUFA 22:5 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 838, 15150.0)]
    [Display(Name = "PUFA 22:5 c")]
    PUFA_22_5_c_Grams = 2024,

    /// <summary>
    /// PUFA 22:6 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 839, 15250.0)]
    [Display(Name = "PUFA 22:6 c")]
    PUFA_22_6_c_Grams = 2025,

    /// <summary>
    /// PUFA 20:2 c
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 840, 14250.0)]
    [Display(Name = "PUFA 20:2 c")]
    PUFA_20_2_c_Grams = 2026,

    /// <summary>
    /// Proximate
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 200, 999999.0)]
    [Display(Name = "Proximate")]
    Proximate_Grams = 2027,

    /// <summary>
    /// trans-beta-Carotene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 321.2, 7444.0)]
    [Display(Name = "trans-beta-Carotene")]
    trans_beta_Carotene_Micrograms = 2028,

    /// <summary>
    /// trans-Lycopene
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 337.2, 7534.0)]
    [Display(Name = "trans-Lycopene")]
    trans_Lycopene_Micrograms = 2029,

    /// <summary>
    /// Cryptoxanthin, alpha
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 335, 7461.0)]
    [Display(Name = "Cryptoxanthin, alpha")]
    Cryptoxanthin_alpha_Micrograms = 2032,

    /// <summary>
    /// Total dietary fiber (AOAC 2011.25)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 293, 1300.0)]
    [Display(Name = "Total dietary fiber (AOAC 2011.25)")]
    Total_dietary_fiber_AOAC_2011_25_Grams = 2033,

    /// <summary>
    /// Insoluble dietary fiber (IDF)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 293.1, 1310.0)]
    [Display(Name = "Insoluble dietary fiber (IDF)")]
    Insoluble_dietary_fiber_IDF_Grams = 2034,

    /// <summary>
    /// Soluble dietary fiber (SDFP+SDFS)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 293.2, 1320.0)]
    [Display(Name = "Soluble dietary fiber (SDFP+SDFS)")]
    Soluble_dietary_fiber_SDFP_SDFS_Grams = 2035,

    /// <summary>
    /// Soluble dietary fiber (SDFP)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 954, 1324.0)]
    [Display(Name = "Soluble dietary fiber (SDFP)")]
    Soluble_dietary_fiber_SDFP_Grams = 2036,

    /// <summary>
    /// Soluble dietary fiber (SDFS)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 953, 1326.0)]
    [Display(Name = "Soluble dietary fiber (SDFS)")]
    Soluble_dietary_fiber_SDFS_Grams = 2037,

    /// <summary>
    /// High Molecular Weight Dietary Fiber (HMWDF)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 293.3, 1305)]
    [Display(Name = "High Molecular Weight Dietary Fiber (HMWDF)")]
    High_Molecular_Weight_Dietary_Fiber_HMWDF_Grams = 2038,

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
    /// Other carotenoids
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, 955, 7510.0)]
    [Display(Name = "Other carotenoids")]
    Other_carotenoids_Micrograms = 2040,

    /// <summary>
    /// Tocopherols and tocotrienols
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 323.99, 7900.0)]
    [Display(Name = "Tocopherols and tocotrienols")]
    Tocopherols_and_tocotrienols_Milligrams = 2041,

    /// <summary>
    /// Amino acids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 500, 16250.0)]
    [Display(Name = "Amino acids")]
    Amino_acids_Grams = 2042,

    /// <summary>
    /// Minerals
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 300, 5200.0)]
    [Display(Name = "Minerals")]
    Minerals_Milligrams = 2043,

    /// <summary>
    /// Lipids
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 950, 9600.0)]
    [Display(Name = "Lipids")]
    Lipids_Grams = 2044,

    /// <summary>
    /// Proximates
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 951, 50.0)]
    [Display(Name = "Proximates")]
    Proximates_Grams = 2045,

    /// <summary>
    /// Vitamins and Other Components
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 952, 6250.0)]
    [Display(Name = "Vitamins and Other Components")]
    Vitamins_and_Other_Components_Grams = 2046,

    /// <summary>
    /// Total Tocopherols
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 7901.0)]
    [Display(Name = "Total Tocopherols")]
    Total_Tocopherols_Milligrams = 2055,

    /// <summary>
    /// Total Tocotrienols
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 7902.0)]
    [Display(Name = "Total Tocotrienols")]
    Total_Tocotrienols_Milligrams = 2054,

    /// <summary>
    /// Stigmastadiene
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 15801.0)]
    [Display(Name = "Stigmastadiene")]
    Stigmastadiene_Milligrams = 2053,

    /// <summary>
    /// Delta-7-Stigmastenol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 16226.0)]
    [Display(Name = "Delta-7-Stigmastenol")]
    Delta_7_Stigmastenol_Milligrams = 2052,

    /// <summary>
    /// Daidzin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 717, 19310.0)]
    [Display(Name = "Daidzin")]
    Daidzin_Milligrams = 2049,

    /// <summary>
    /// Genistin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 718, 19320.0)]
    [Display(Name = "Genistin")]
    Genistin_Milligrams = 2050,

    /// <summary>
    /// Glycitin
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 719, 19330.0)]
    [Display(Name = "Glycitin")]
    Glycitin_Milligrams = 2051,

    /// <summary>
    /// Ergothioneine
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 18500)]
    [Display(Name = "Ergothioneine")]
    Ergothioneine_Milligrams = 2057,

    /// <summary>
    /// Beta-glucan
    /// </summary>
    [NutrientsMetadata(Measure.Grams, -1, 1327.0)]
    [Display(Name = "Beta-glucan")]
    Beta_glucan_Grams = 2058,

    /// <summary>
    /// Vitamin D4
    /// </summary>
    [NutrientsMetadata(Measure.Micrograms, -1, 8730.0)]
    [Display(Name = "Vitamin D4")]
    Vitamin_D4_Micrograms = 2059,

    /// <summary>
    /// Ergosta-7-enol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 16210.0)]
    [Display(Name = "Ergosta-7-enol")]
    Ergosta_7_enol_Milligrams = 2060,

    /// <summary>
    /// Ergosta-7,22-dienol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 16211.0)]
    [Display(Name = "Ergosta-7,22-dienol")]
    Ergosta_7_22_dienol_Milligrams = 2061,

    /// <summary>
    /// Ergosta-5,7-dienol
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, -1, 16211.0)]
    [Display(Name = "Ergosta-5,7-dienol")]
    Ergosta_5_7_dienol_Milligrams = 2062,

    /// <summary>
    /// Verbascose
    /// </summary>
    [NutrientsMetadata(Measure.Grams, -1, 2450.0)]
    [Display(Name = "Verbascose")]
    Verbascose_Grams = 2063,

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
    /// Low Molecular Weight Dietary Fiber (LMWDF)
    /// </summary>
    [NutrientsMetadata(Measure.Grams, 293.4, 1306)]
    [Display(Name = "Low Molecular Weight Dietary Fiber (LMWDF)")]
    Low_Molecular_Weight_Dietary_Fiber_LMWDF_Grams = 2065,

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

    /// <summary>
    /// Glutathione
    /// </summary>
    [NutrientsMetadata(Measure.Milligrams, 961, 9000)]
    [Display(Name = "Glutathione")]
    Glutathione_Milligrams = 2069,
}
