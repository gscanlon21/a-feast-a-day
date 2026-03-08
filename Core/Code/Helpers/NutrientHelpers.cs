using Core.Models.Nutrients;

namespace Core.Code.Helpers;

public static class NutrientHelpers
{
    public static readonly Nutrients[] All =
    [
        ..Macronutrients(), ..AminoAcids(), ..Vitamins(), ..Minerals(), ..Extra()
    ];

    private static Nutrients[] Macronutrients() =>
    [
        Nutrients.Protein_Grams,
        Nutrients.Starch_Grams,
        Nutrients.Resistant_starch_Grams,
        Nutrients.Fiber_total_dietary_Grams,
        Nutrients.Total_Sugars_Grams,
        Nutrients.Sugars_Total_Grams,
        Nutrients.Total_lipid_fat_Grams,
        Nutrients.Fatty_acids_total_trans_Grams,
        Nutrients.Fatty_acids_total_saturated_Grams,
        Nutrients.Fatty_acids_total_monounsaturated_Grams,
        Nutrients.Fatty_acids_total_polyunsaturated_Grams,
        // Omega-3
        Nutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams,
        // Omega-3
        Nutrients.PUFA_20_5_n_3_EPA_Grams,
        // Omega-3
        Nutrients.PUFA_22_6_n_3_DHA_Grams,
        // Omega-6
        Nutrients.PUFA_18_2_n_6_c_c_Grams,
    
        // These are not tracked:
        //Nutrients.Fiber_soluble_Grams,
        //Nutrients.Fiber_insoluble_Grams,
        //Nutrients.Oligosaccharides_Grams,
        //Nutrients.Oligosaccharides_Milligrams,
        //Nutrients.Carbohydrate_by_summation_Grams,
        //Nutrients.Carbohydrate_by_difference_Grams,
        //Nutrients.Carbohydrates_Grams,
        //Nutrients.PUFA_20_3_n_6_Grams,
        //Nutrients.PUFA_20_4_n_6_Grams,
        //Nutrients.PUFA_20_3_n_3_Grams,
        //Nutrients.PUFA_20_4_n_3_Grams,
    ];

    private static Nutrients[] AminoAcids() =>
    [
        Nutrients.Histidine_Grams,
        Nutrients.Isoleucine_Grams,
        Nutrients.Leucine_Grams,
        Nutrients.Lysine_Grams,
        Nutrients.Phenylalanine_Grams,
        Nutrients.Methionine_Grams,
        Nutrients.Threonine_Grams,
        Nutrients.Tryptophan_Grams,
        Nutrients.Valine_Grams,
        Nutrients.Arginine_Grams,
        Nutrients.Glycine_Grams,
    ];

    private static Nutrients[] Vitamins() =>
    [
        Nutrients.Vitamin_A_RAE_Micrograms,
        Nutrients.Carotene_alpha_Micrograms,
        Nutrients.Carotene_beta_Micrograms,
        Nutrients.Thiamin_Milligrams, // B1
        Nutrients.Riboflavin_Milligrams, // B2
        Nutrients.Niacin_Milligrams, // B3
        Nutrients.Pantothenic_acid_Milligrams, // B5
        Nutrients.Vitamin_B_6_Milligrams,
        Nutrients.Folate_total_Micrograms, // B9
        Nutrients.Vitamin_B_12_Micrograms,
        Nutrients.Vitamin_C_total_ascorbic_acid_Milligrams,
        Nutrients.Vitamin_E_alpha_tocopherol_Milligrams,
        Nutrients.Vitamin_K_phylloquinone_Micrograms,

        // These do not have dietary intake references:
        //Nutrients.Lycopene_Micrograms,

        // These are not tracked:
        //Nutrients.Carotene_MCG_RE,
        //Nutrients.Vitamin_A_Micrograms,
        //Nutrients.Biotin_Micrograms, // B7
        //Nutrients.Vitamin_D_D2__D3_Micrograms,
        //Nutrients.Vitamin_E_Milligrams,
        //Nutrients.Vitamin_E_MG_ATE,
    ];

    private static Nutrients[] Minerals() =>
    [
        Nutrients.Sodium_Na_Milligrams,
        Nutrients.Calcium_Ca_Milligrams,
        Nutrients.Potassium_K_Milligrams,
        Nutrients.Magnesium_Mg_Milligrams,
        Nutrients.Phosphorus_P_Milligrams,
        Nutrients.Iron_Fe_Milligrams,
        Nutrients.Zinc_Zn_Milligrams,
        Nutrients.Copper_Cu_Milligrams,
        Nutrients.Manganese_Mn_Milligrams,
        Nutrients.Selenium_Se_Micrograms,
        Nutrients.Iodine_I_Micrograms,
        Nutrients.Molybdenum_Mo_Micrograms,
        Nutrients.Boron_B_Micrograms,

        // These are not tracked:
        //Nutrients.Sulfur_S_Milligrams,
        //Nutrients.Fluoride_F_Micrograms,
        //Nutrients.Lithium_Li_Micrograms,
        //Nutrients.Vanadium_V_Micrograms,
        //Nutrients.Chromium_Cr_Micrograms,
        //Nutrients.Chlorine_Cl_Milligrams,
    ];

    private static Nutrients[] Extra() =>
    [
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
        Nutrients.Energy_Atwater_General_Factors_KCalorie,

        Nutrients.Betaine_Milligrams,
        Nutrients.Choline_total_Milligrams,
        Nutrients.Lutein__zeaxanthin_Micrograms,

        // These are not tracked:
        //Nutrients.Flavonoids_total_Milligrams,
        //Nutrients.Polyphenols_total_Milligrams,
    ];
}



public static class NutrientHelpersUs
{
    public static readonly USDANutrients[] All =
    [
        ..Macronutrients(), ..AminoAcids(), ..Vitamins(), ..Minerals(), ..Extra()
    ];

    private static USDANutrients[] Macronutrients() =>
    [
        USDANutrients.Protein_Grams,
        USDANutrients.Starch_Grams,
        USDANutrients.Resistant_starch_Grams,
        USDANutrients.Fiber_total_dietary_Grams,
        USDANutrients.Total_Sugars_Grams,
        USDANutrients.Sugars_Total_Grams,
        USDANutrients.Total_lipid_fat_Grams,
        USDANutrients.Fatty_acids_total_trans_Grams,
        USDANutrients.Fatty_acids_total_saturated_Grams,
        USDANutrients.Fatty_acids_total_monounsaturated_Grams,
        USDANutrients.Fatty_acids_total_polyunsaturated_Grams,
        // Omega-3
        USDANutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams,
        // Omega-3
        USDANutrients.PUFA_20_5_n_3_EPA_Grams,
        // Omega-3
        USDANutrients.PUFA_22_6_n_3_DHA_Grams,
        // Omega-6
        USDANutrients.PUFA_18_2_n_6_c_c_Grams,
    
        // These are not tracked:
        //Nutrients.Fiber_soluble_Grams,
        //Nutrients.Fiber_insoluble_Grams,
        //Nutrients.Oligosaccharides_Grams,
        //Nutrients.Oligosaccharides_Milligrams,
        //Nutrients.Carbohydrate_by_summation_Grams,
        //Nutrients.Carbohydrate_by_difference_Grams,
        //Nutrients.Carbohydrates_Grams,
        //Nutrients.PUFA_20_3_n_6_Grams,
        //Nutrients.PUFA_20_4_n_6_Grams,
        //Nutrients.PUFA_20_3_n_3_Grams,
        //Nutrients.PUFA_20_4_n_3_Grams,
    ];

    private static USDANutrients[] AminoAcids() =>
    [
        USDANutrients.Histidine_Grams,
        USDANutrients.Isoleucine_Grams,
        USDANutrients.Leucine_Grams,
        USDANutrients.Lysine_Grams,
        USDANutrients.Phenylalanine_Grams,
        USDANutrients.Methionine_Grams,
        USDANutrients.Threonine_Grams,
        USDANutrients.Tryptophan_Grams,
        USDANutrients.Valine_Grams,
        USDANutrients.Arginine_Grams,
        USDANutrients.Glycine_Grams,
    ];

    private static USDANutrients[] Vitamins() =>
    [
        USDANutrients.Vitamin_A_RAE_Micrograms,
        USDANutrients.Carotene_alpha_Micrograms,
        USDANutrients.Carotene_beta_Micrograms,
        USDANutrients.Thiamin_Milligrams, // B1
        USDANutrients.Riboflavin_Milligrams, // B2
        USDANutrients.Niacin_Milligrams, // B3
        USDANutrients.Pantothenic_acid_Milligrams, // B5
        USDANutrients.Vitamin_B_6_Milligrams,
        USDANutrients.Folate_total_Micrograms, // B9
        USDANutrients.Vitamin_B_12_Micrograms,
        USDANutrients.Vitamin_C_total_ascorbic_acid_Milligrams,
        USDANutrients.Vitamin_E_alpha_tocopherol_Milligrams,
        USDANutrients.Vitamin_K_phylloquinone_Micrograms,

        // These do not have dietary intake references:
        //Nutrients.Lycopene_Micrograms,

        // These are not tracked:
        //Nutrients.Carotene_MCG_RE,
        //Nutrients.Vitamin_A_Micrograms,
        //Nutrients.Biotin_Micrograms, // B7
        //Nutrients.Vitamin_D_D2__D3_Micrograms,
        //Nutrients.Vitamin_E_Milligrams,
        //Nutrients.Vitamin_E_MG_ATE,
    ];

    private static USDANutrients[] Minerals() =>
    [
        USDANutrients.Sodium_Na_Milligrams,
        USDANutrients.Calcium_Ca_Milligrams,
        USDANutrients.Potassium_K_Milligrams,
        USDANutrients.Magnesium_Mg_Milligrams,
        USDANutrients.Phosphorus_P_Milligrams,
        USDANutrients.Iron_Fe_Milligrams,
        USDANutrients.Zinc_Zn_Milligrams,
        USDANutrients.Copper_Cu_Milligrams,
        USDANutrients.Manganese_Mn_Milligrams,
        USDANutrients.Selenium_Se_Micrograms,
        USDANutrients.Iodine_I_Micrograms,
        USDANutrients.Molybdenum_Mo_Micrograms,
        USDANutrients.Boron_B_Micrograms,

        // These are not tracked:
        //Nutrients.Sulfur_S_Milligrams,
        //Nutrients.Fluoride_F_Micrograms,
        //Nutrients.Lithium_Li_Micrograms,
        //Nutrients.Vanadium_V_Micrograms,
        //Nutrients.Chromium_Cr_Micrograms,
        //Nutrients.Chlorine_Cl_Milligrams,
    ];

    private static USDANutrients[] Extra() =>
    [
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
        USDANutrients.Energy_Atwater_General_Factors_KCalorie,

        USDANutrients.Betaine_Milligrams,
        USDANutrients.Choline_total_Milligrams,
        USDANutrients.Lutein__zeaxanthin_Micrograms,

        // These are not tracked:
        //Nutrients.Flavonoids_total_Milligrams,
        //Nutrients.Polyphenols_total_Milligrams,
    ];
}



public static class NutrientHelpersCa
{
    public static readonly CanadaNutrients[] All =
    [
        ..Macronutrients(), ..AminoAcids(), ..Vitamins(), ..Minerals(), ..Extra()
    ];

    private static CanadaNutrients[] Macronutrients() =>
    [
        CanadaNutrients.PROTEIN_Grams,
        CanadaNutrients.STARCH_Grams,
        CanadaNutrients.FIBRE_TOTAL_DIETARY_Grams,
        CanadaNutrients.SUGARS_TOTAL_Grams,
        CanadaNutrients.FAT_TOTAL_LIPIDS_Grams,
        CanadaNutrients.FATTY_ACIDS_TRANS_TOTAL_Grams,
        CanadaNutrients.FATTY_ACIDS_SATURATED_TOTAL_Grams,
        CanadaNutrients.FATTY_ACIDS_MONOUNSATURATED_TOTAL_Grams,
        CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_Grams,
        // Omega-3
        CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA_N_3_Grams,
        // Omega-3
        CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_20_5_n_3_EICOSAPENTAENOIC_EPA_Grams,
        // Omega-3
        CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_22_6_n_3_DOCOSAHEXAENOIC_DHA_Grams,
        // Omega-6
        CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA__N_6_Grams,
    
        // These are not tracked:
        //Nutrients.Fiber_soluble_Grams,
        //Nutrients.Fiber_insoluble_Grams,
        //Nutrients.Oligosaccharides_Grams,
        //Nutrients.Oligosaccharides_Milligrams,
        //Nutrients.Carbohydrate_by_summation_Grams,
        //Nutrients.Carbohydrate_by_difference_Grams,
        //Nutrients.Carbohydrates_Grams,
        //Nutrients.PUFA_20_3_n_6_Grams,
        //Nutrients.PUFA_20_4_n_6_Grams,
        //Nutrients.PUFA_20_3_n_3_Grams,
        //Nutrients.PUFA_20_4_n_3_Grams,
    ];

    private static CanadaNutrients[] AminoAcids() =>
    [
        CanadaNutrients.HISTIDINE_Grams,
        CanadaNutrients.ISOLEUCINE_Grams,
        CanadaNutrients.LEUCINE_Grams,
        CanadaNutrients.LYSINE_Grams,
        CanadaNutrients.PHENYLALANINE_Grams,
        CanadaNutrients.METHIONINE_Grams,
        CanadaNutrients.THREONINE_Grams,
        CanadaNutrients.TRYPTOPHAN_Grams,
        CanadaNutrients.VALINE_Grams,
        CanadaNutrients.ARGININE_Grams,
        CanadaNutrients.GLYCINE_Grams,
    ];

    private static CanadaNutrients[] Vitamins() =>
    [
        CanadaNutrients.RETINOL_ACTIVITY_EQUIVALENTS_None,
        CanadaNutrients.ALPHA_CAROTENE_None,
        CanadaNutrients.BETA_CAROTENE_None,
        CanadaNutrients.THIAMIN_Milligrams, // B1
        CanadaNutrients.RIBOFLAVIN_Milligrams, // B2
        CanadaNutrients.TOTAL_NIACIN_EQUIVALENT_None, // B3
        CanadaNutrients.PANTOTHENIC_ACID_Milligrams, // B5
        CanadaNutrients.VITAMIN_B_6_Milligrams,
        CanadaNutrients.DIETARY_FOLATE_EQUIVALENTS_None, // B9
        CanadaNutrients.VITAMIN_B_12_None,
        CanadaNutrients.VITAMIN_C_Milligrams,
        CanadaNutrients.VITAMIN_K_None,

        // These do not have dietary intake references:
        //Nutrients.Lycopene_Micrograms,

        // These are not tracked:
        //Nutrients.Carotene_MCG_RE,
        //Nutrients.Vitamin_A_Micrograms,
        //Nutrients.Biotin_Micrograms, // B7
        //Nutrients.Vitamin_D_D2__D3_Micrograms,
        //Nutrients.Vitamin_E_Milligrams,
        //Nutrients.Vitamin_E_MG_ATE,
    ];

    private static CanadaNutrients[] Minerals() =>
    [
        CanadaNutrients.SODIUM_Milligrams,
        CanadaNutrients.CALCIUM_Milligrams,
        CanadaNutrients.POTASSIUM_Milligrams,
        CanadaNutrients.MAGNESIUM_Milligrams,
        CanadaNutrients.PHOSPHORUS_Milligrams,
        CanadaNutrients.IRON_Milligrams,
        CanadaNutrients.ZINC_Milligrams,
        CanadaNutrients.COPPER_Milligrams,
        CanadaNutrients.MANGANESE_Milligrams,
        CanadaNutrients.SELENIUM_None,

        // These are not tracked:
        //Nutrients.Sulfur_S_Milligrams,
        //Nutrients.Fluoride_F_Micrograms,
        //Nutrients.Lithium_Li_Micrograms,
        //Nutrients.Vanadium_V_Micrograms,
        //Nutrients.Chromium_Cr_Micrograms,
        //Nutrients.Chlorine_Cl_Milligrams,
    ];

    private static CanadaNutrients[] Extra() =>
    [
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
        CanadaNutrients.ENERGY_KILOCALORIES_KCalorie,

        CanadaNutrients.BETAINE_Milligrams,
        CanadaNutrients.CHOLINE_TOTAL_Milligrams,
        CanadaNutrients.LUTEIN_AND_ZEAXANTHIN_None,

        // These are not tracked:
        //Nutrients.Flavonoids_total_Milligrams,
        //Nutrients.Polyphenols_total_Milligrams,
    ];
}


public static class NutrientMaps
{
    public static readonly IReadOnlyDictionary<Nutrients, USDANutrients> NutrientsToUSDA =
        USDAToNutrients.ToDictionary(x => x.Value, x => x.Key);

    public static readonly IReadOnlyDictionary<Nutrients, CanadaNutrients> NutrientsToCanada =
        CanadaToNutrients.ToDictionary(x => x.Value, x => x.Key);

    public static IReadOnlyDictionary<USDANutrients, Nutrients> USDAToNutrients =>
        new Dictionary<USDANutrients, Nutrients>
    {
        // Macronutrients
        { USDANutrients.Protein_Grams, Nutrients.Protein_Grams },
        { USDANutrients.Starch_Grams, Nutrients.Starch_Grams },
        { USDANutrients.Resistant_starch_Grams, Nutrients.Resistant_starch_Grams },
        { USDANutrients.Fiber_total_dietary_Grams, Nutrients.Fiber_total_dietary_Grams },
        { USDANutrients.Total_Sugars_Grams, Nutrients.Total_Sugars_Grams },
        { USDANutrients.Sugars_Total_Grams, Nutrients.Sugars_Total_Grams },
        { USDANutrients.Total_lipid_fat_Grams, Nutrients.Total_lipid_fat_Grams },
        { USDANutrients.Fatty_acids_total_trans_Grams, Nutrients.Fatty_acids_total_trans_Grams },
        { USDANutrients.Fatty_acids_total_saturated_Grams, Nutrients.Fatty_acids_total_saturated_Grams },
        { USDANutrients.Fatty_acids_total_monounsaturated_Grams, Nutrients.Fatty_acids_total_monounsaturated_Grams },
        { USDANutrients.Fatty_acids_total_polyunsaturated_Grams, Nutrients.Fatty_acids_total_polyunsaturated_Grams },
        { USDANutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams, Nutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams },
        { USDANutrients.PUFA_20_5_n_3_EPA_Grams, Nutrients.PUFA_20_5_n_3_EPA_Grams },
        { USDANutrients.PUFA_22_6_n_3_DHA_Grams, Nutrients.PUFA_22_6_n_3_DHA_Grams },
        { USDANutrients.PUFA_18_2_n_6_c_c_Grams, Nutrients.PUFA_18_2_n_6_c_c_Grams },

        // Amino acids
        { USDANutrients.Histidine_Grams, Nutrients.Histidine_Grams },
        { USDANutrients.Isoleucine_Grams, Nutrients.Isoleucine_Grams },
        { USDANutrients.Leucine_Grams, Nutrients.Leucine_Grams },
        { USDANutrients.Lysine_Grams, Nutrients.Lysine_Grams },
        { USDANutrients.Phenylalanine_Grams, Nutrients.Phenylalanine_Grams },
        { USDANutrients.Methionine_Grams, Nutrients.Methionine_Grams },
        { USDANutrients.Threonine_Grams, Nutrients.Threonine_Grams },
        { USDANutrients.Tryptophan_Grams, Nutrients.Tryptophan_Grams },
        { USDANutrients.Valine_Grams, Nutrients.Valine_Grams },
        { USDANutrients.Arginine_Grams, Nutrients.Arginine_Grams },
        { USDANutrients.Glycine_Grams, Nutrients.Glycine_Grams },

        // Vitamins
        { USDANutrients.Vitamin_A_RAE_Micrograms, Nutrients.Vitamin_A_RAE_Micrograms },
        { USDANutrients.Carotene_alpha_Micrograms, Nutrients.Carotene_alpha_Micrograms },
        { USDANutrients.Carotene_beta_Micrograms, Nutrients.Carotene_beta_Micrograms },
        { USDANutrients.Thiamin_Milligrams, Nutrients.Thiamin_Milligrams },
        { USDANutrients.Riboflavin_Milligrams, Nutrients.Riboflavin_Milligrams },
        { USDANutrients.Niacin_Milligrams, Nutrients.Niacin_Milligrams },
        { USDANutrients.Pantothenic_acid_Milligrams, Nutrients.Pantothenic_acid_Milligrams },
        { USDANutrients.Vitamin_B_6_Milligrams, Nutrients.Vitamin_B_6_Milligrams },
        { USDANutrients.Folate_total_Micrograms, Nutrients.Folate_total_Micrograms },
        { USDANutrients.Vitamin_B_12_Micrograms, Nutrients.Vitamin_B_12_Micrograms },
        { USDANutrients.Vitamin_C_total_ascorbic_acid_Milligrams, Nutrients.Vitamin_C_total_ascorbic_acid_Milligrams },
        { USDANutrients.Vitamin_E_alpha_tocopherol_Milligrams, Nutrients.Vitamin_E_alpha_tocopherol_Milligrams },
        { USDANutrients.Vitamin_K_phylloquinone_Micrograms, Nutrients.Vitamin_K_phylloquinone_Micrograms },

        // Minerals
        { USDANutrients.Sodium_Na_Milligrams, Nutrients.Sodium_Na_Milligrams },
        { USDANutrients.Calcium_Ca_Milligrams, Nutrients.Calcium_Ca_Milligrams },
        { USDANutrients.Potassium_K_Milligrams, Nutrients.Potassium_K_Milligrams },
        { USDANutrients.Magnesium_Mg_Milligrams, Nutrients.Magnesium_Mg_Milligrams },
        { USDANutrients.Phosphorus_P_Milligrams, Nutrients.Phosphorus_P_Milligrams },
        { USDANutrients.Iron_Fe_Milligrams, Nutrients.Iron_Fe_Milligrams },
        { USDANutrients.Zinc_Zn_Milligrams, Nutrients.Zinc_Zn_Milligrams },
        { USDANutrients.Copper_Cu_Milligrams, Nutrients.Copper_Cu_Milligrams },
        { USDANutrients.Manganese_Mn_Milligrams, Nutrients.Manganese_Mn_Milligrams },
        { USDANutrients.Selenium_Se_Micrograms, Nutrients.Selenium_Se_Micrograms },
        { USDANutrients.Iodine_I_Micrograms, Nutrients.Iodine_I_Micrograms },
        { USDANutrients.Molybdenum_Mo_Micrograms, Nutrients.Molybdenum_Mo_Micrograms },
        { USDANutrients.Boron_B_Micrograms, Nutrients.Boron_B_Micrograms },

        // Extra
        { USDANutrients.Energy_Atwater_General_Factors_KCalorie, Nutrients.Energy_Atwater_General_Factors_KCalorie },
        { USDANutrients.Betaine_Milligrams, Nutrients.Betaine_Milligrams },
        { USDANutrients.Choline_total_Milligrams, Nutrients.Choline_total_Milligrams },
        { USDANutrients.Lutein__zeaxanthin_Micrograms, Nutrients.Lutein__zeaxanthin_Micrograms },
    };


    public static IReadOnlyDictionary<CanadaNutrients, Nutrients> CanadaToNutrients =>
        new Dictionary<CanadaNutrients, Nutrients>
    {
        // Macronutrients
        { CanadaNutrients.PROTEIN_Grams, Nutrients.Protein_Grams },
        { CanadaNutrients.STARCH_Grams, Nutrients.Starch_Grams },
        { CanadaNutrients.FIBRE_TOTAL_DIETARY_Grams, Nutrients.Fiber_total_dietary_Grams },
        { CanadaNutrients.SUGARS_TOTAL_Grams, Nutrients.Sugars_Total_Grams },
        { CanadaNutrients.FAT_TOTAL_LIPIDS_Grams, Nutrients.Total_lipid_fat_Grams },
        { CanadaNutrients.FATTY_ACIDS_TRANS_TOTAL_Grams, Nutrients.Fatty_acids_total_trans_Grams },
        { CanadaNutrients.FATTY_ACIDS_SATURATED_TOTAL_Grams, Nutrients.Fatty_acids_total_saturated_Grams },
        { CanadaNutrients.FATTY_ACIDS_MONOUNSATURATED_TOTAL_Grams, Nutrients.Fatty_acids_total_monounsaturated_Grams },
        { CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_Grams, Nutrients.Fatty_acids_total_polyunsaturated_Grams },
        { CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA_N_3_Grams, Nutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams },
        { CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_20_5_n_3_EICOSAPENTAENOIC_EPA_Grams, Nutrients.PUFA_20_5_n_3_EPA_Grams },
        { CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_22_6_n_3_DOCOSAHEXAENOIC_DHA_Grams, Nutrients.PUFA_22_6_n_3_DHA_Grams },
        { CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA__N_6_Grams, Nutrients.PUFA_18_2_n_6_c_c_Grams },

        // Amino acids
        { CanadaNutrients.HISTIDINE_Grams, Nutrients.Histidine_Grams },
        { CanadaNutrients.ISOLEUCINE_Grams, Nutrients.Isoleucine_Grams },
        { CanadaNutrients.LEUCINE_Grams, Nutrients.Leucine_Grams },
        { CanadaNutrients.LYSINE_Grams, Nutrients.Lysine_Grams },
        { CanadaNutrients.PHENYLALANINE_Grams, Nutrients.Phenylalanine_Grams },
        { CanadaNutrients.METHIONINE_Grams, Nutrients.Methionine_Grams },
        { CanadaNutrients.THREONINE_Grams, Nutrients.Threonine_Grams },
        { CanadaNutrients.TRYPTOPHAN_Grams, Nutrients.Tryptophan_Grams },
        { CanadaNutrients.VALINE_Grams, Nutrients.Valine_Grams },
        { CanadaNutrients.ARGININE_Grams, Nutrients.Arginine_Grams },
        { CanadaNutrients.GLYCINE_Grams, Nutrients.Glycine_Grams },

        // Vitamins
        { CanadaNutrients.RETINOL_ACTIVITY_EQUIVALENTS_None, Nutrients.Vitamin_A_RAE_Micrograms },
        { CanadaNutrients.ALPHA_CAROTENE_None, Nutrients.Carotene_alpha_Micrograms },
        { CanadaNutrients.BETA_CAROTENE_None, Nutrients.Carotene_beta_Micrograms },
        { CanadaNutrients.THIAMIN_Milligrams, Nutrients.Thiamin_Milligrams },
        { CanadaNutrients.RIBOFLAVIN_Milligrams, Nutrients.Riboflavin_Milligrams },
        { CanadaNutrients.TOTAL_NIACIN_EQUIVALENT_None, Nutrients.Niacin_Milligrams },
        { CanadaNutrients.PANTOTHENIC_ACID_Milligrams, Nutrients.Pantothenic_acid_Milligrams },
        { CanadaNutrients.VITAMIN_B_6_Milligrams, Nutrients.Vitamin_B_6_Milligrams },
        { CanadaNutrients.DIETARY_FOLATE_EQUIVALENTS_None, Nutrients.Folate_total_Micrograms },
        { CanadaNutrients.VITAMIN_B_12_None, Nutrients.Vitamin_B_12_Micrograms },
        { CanadaNutrients.VITAMIN_C_Milligrams, Nutrients.Vitamin_C_total_ascorbic_acid_Milligrams },
        { CanadaNutrients.VITAMIN_K_None, Nutrients.Vitamin_K_phylloquinone_Micrograms },

        // Minerals
        { CanadaNutrients.SODIUM_Milligrams, Nutrients.Sodium_Na_Milligrams },
        { CanadaNutrients.CALCIUM_Milligrams, Nutrients.Calcium_Ca_Milligrams },
        { CanadaNutrients.POTASSIUM_Milligrams, Nutrients.Potassium_K_Milligrams },
        { CanadaNutrients.MAGNESIUM_Milligrams, Nutrients.Magnesium_Mg_Milligrams },
        { CanadaNutrients.PHOSPHORUS_Milligrams, Nutrients.Phosphorus_P_Milligrams },
        { CanadaNutrients.IRON_Milligrams, Nutrients.Iron_Fe_Milligrams },
        { CanadaNutrients.ZINC_Milligrams, Nutrients.Zinc_Zn_Milligrams },
        { CanadaNutrients.COPPER_Milligrams, Nutrients.Copper_Cu_Milligrams },
        { CanadaNutrients.MANGANESE_Milligrams, Nutrients.Manganese_Mn_Milligrams },
        { CanadaNutrients.SELENIUM_None, Nutrients.Selenium_Se_Micrograms },

        // Extra
        { CanadaNutrients.ENERGY_KILOCALORIES_KCalorie, Nutrients.Energy_Atwater_General_Factors_KCalorie },
        { CanadaNutrients.BETAINE_Milligrams, Nutrients.Betaine_Milligrams },
        { CanadaNutrients.CHOLINE_TOTAL_Milligrams, Nutrients.Choline_total_Milligrams },
        { CanadaNutrients.LUTEIN_AND_ZEAXANTHIN_None, Nutrients.Lutein__zeaxanthin_Micrograms },
    };
}