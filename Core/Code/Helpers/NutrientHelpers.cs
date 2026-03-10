using Core.Models.Nutrients;

namespace Core.Code.Helpers;

/// <summary>
/// These are not tracked:
/// 
/// Nutrients.Fiber_soluble,
/// Nutrients.Fiber_insoluble,
/// Nutrients.Oligosaccharides,
/// Nutrients.Oligosaccharides,
/// Nutrients.Carbohydrate_by_summation,
/// Nutrients.Carbohydrate_by_difference,
/// Nutrients.Carbohydrates,
/// Nutrients.PUFA_20_3_n_6,
/// Nutrients.PUFA_20_4_n_6,
/// Nutrients.PUFA_20_3_n_3,
/// Nutrients.PUFA_20_4_n_3,
/// Nutrients.Sulfur_S_Milligrams,
/// Nutrients.Fluoride_F,
/// Nutrients.Lithium_Li,
/// Nutrients.Vanadium_V,
/// Nutrients.Chromium_Cr,
/// Nutrients.Chlorine_Cl_Milligrams,
/// Nutrients.Flavonoids_total_Milligrams,
/// Nutrients.Polyphenols_total_Milligrams,
/// Nutrients.Carotene_MCG_RE,
/// Nutrients.Vitamin_A,
/// Nutrients.Biotin, // B7
/// Nutrients.Vitamin_D_D2__D3,
/// Nutrients.Vitamin_E,
/// Nutrients.Vitamin_E_MG_ATE,
/// 
/// These do not have dietary intake references:
/// Nutrients.Lycopene,
/// </summary>
public static class NutrientHelpers
{
    public static readonly Nutrients[] All =
    [
        ..Macronutrients(), ..AminoAcids(), ..Vitamins(), ..Minerals(), ..Extra()
    ];

    private static Nutrients[] Macronutrients() =>
    [
        Nutrients.Protein,
        Nutrients.Starch,
        Nutrients.Resistant_starch,
        Nutrients.Fiber_total_dietary,
        Nutrients.Total_Sugars,
        Nutrients.Sugars_Total,
        Nutrients.Total_lipid_fat,
        Nutrients.Fatty_acids_total_trans,
        Nutrients.Fatty_acids_total_saturated,
        Nutrients.Fatty_acids_total_monounsaturated,
        Nutrients.Fatty_acids_total_polyunsaturated,
        Nutrients.Omega_3_EPA_DHA,
        Nutrients.Omega_3_ALA,
        Nutrients.Omega_6,
    ];

    private static Nutrients[] AminoAcids() =>
    [
        Nutrients.Histidine,
        Nutrients.Isoleucine,
        Nutrients.Leucine,
        Nutrients.Lysine,
        Nutrients.Phenylalanine,
        Nutrients.Methionine,
        Nutrients.Threonine,
        Nutrients.Tryptophan,
        Nutrients.Valine,
        Nutrients.Arginine,
        Nutrients.Glycine,
    ];

    private static Nutrients[] Vitamins() =>
    [
        Nutrients.Vitamin_A,
        Nutrients.Carotene_Alpha,
        Nutrients.Carotene_Beta,
        Nutrients.Thiamin_B1,
        Nutrients.Riboflavin_B2,
        Nutrients.Niacin_B3,
        Nutrients.Pantothenic_Acid_B5,
        Nutrients.Vitamin_B_6,
        Nutrients.Folate_B9,
        Nutrients.Vitamin_B_12,
        Nutrients.Vitamin_C,
        Nutrients.Vitamin_E,
        Nutrients.Vitamin_K,
    ];

    private static Nutrients[] Minerals() =>
    [
        Nutrients.Sodium_Na,
        Nutrients.Calcium_Ca,
        Nutrients.Potassium_K,
        Nutrients.Magnesium_Mg,
        Nutrients.Phosphorus_P,
        Nutrients.Iron_Fe,
        Nutrients.Zinc_Zn,
        Nutrients.Copper_Cu,
        Nutrients.Manganese_Mn,
        Nutrients.Selenium_Se,
        Nutrients.Iodine_I,
        Nutrients.Molybdenum_Mo,
        Nutrients.Boron_B,
    ];

    private static Nutrients[] Extra() =>
    [
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
        Nutrients.Energy_KCalorie,
        Nutrients.Lutein_Zeaxanthin,
        Nutrients.Choline,
        Nutrients.Betaine,
    ];

    public static readonly IReadOnlyDictionary<USDANutrients, Nutrients> USDAToNutrients =
        NutrientsToUSDA.SelectMany(x => x.Value.Select(v => (x.Key, Value: v))).ToDictionary(x => x.Value, x => x.Key);

    public static readonly IReadOnlyDictionary<CanadaNutrients, Nutrients> CanadaToNutrients =
        NutrientsToCanada.SelectMany(x => x.Value.Select(v => (x.Key, Value: v))).ToDictionary(x => x.Value, x => x.Key);

    public static IReadOnlyDictionary<Nutrients, List<USDANutrients>> NutrientsToUSDA => new Dictionary<Nutrients, List<USDANutrients>>
    {
        // Macronutrients
        { Nutrients.Protein, [USDANutrients.Protein_Grams] },
        { Nutrients.Starch, [USDANutrients.Starch_Grams] },
        { Nutrients.Resistant_starch, [USDANutrients.Resistant_starch_Grams] },
        { Nutrients.Fiber_total_dietary, [USDANutrients.Fiber_total_dietary_Grams] },
        { Nutrients.Total_Sugars, [USDANutrients.Total_Sugars_Grams] },
        { Nutrients.Sugars_Total, [USDANutrients.Sugars_Total_Grams] },
        { Nutrients.Total_lipid_fat, [USDANutrients.Total_lipid_fat_Grams] },
        { Nutrients.Fatty_acids_total_trans, [USDANutrients.Fatty_acids_total_trans_Grams] },
        { Nutrients.Fatty_acids_total_saturated, [USDANutrients.Fatty_acids_total_saturated_Grams] },
        { Nutrients.Fatty_acids_total_monounsaturated, [USDANutrients.Fatty_acids_total_monounsaturated_Grams] },
        { Nutrients.Fatty_acids_total_polyunsaturated, [USDANutrients.Fatty_acids_total_polyunsaturated_Grams] },
        { Nutrients.Omega_6, [USDANutrients.PUFA_20_3_n_6_Grams, USDANutrients.PUFA_20_4_n_6_Grams, USDANutrients.PUFA_20_2_n_6_c_c_Grams, USDANutrients.PUFA_18_3_n_6_c_c_c_Grams, USDANutrients.PUFA_18_2_n_6_c_c_Grams] },
        { Nutrients.Omega_3_EPA_DHA, [USDANutrients.PUFA_22_6_n_3_DHA_Grams, USDANutrients.PUFA_20_5_n_3_EPA_Grams] },
        { Nutrients.Omega_3_ALA, [USDANutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams] },

        // Amino acids
        { Nutrients.Histidine, [USDANutrients.Histidine_Grams] },
        { Nutrients.Isoleucine, [USDANutrients.Isoleucine_Grams] },
        { Nutrients.Leucine, [USDANutrients.Leucine_Grams] },
        { Nutrients.Lysine, [USDANutrients.Lysine_Grams] },
        { Nutrients.Phenylalanine, [USDANutrients.Phenylalanine_Grams] },
        { Nutrients.Methionine, [USDANutrients.Methionine_Grams] },
        { Nutrients.Threonine, [USDANutrients.Threonine_Grams] },
        { Nutrients.Tryptophan, [USDANutrients.Tryptophan_Grams] },
        { Nutrients.Valine, [USDANutrients.Valine_Grams] },
        { Nutrients.Arginine, [USDANutrients.Arginine_Grams] },
        { Nutrients.Glycine, [USDANutrients.Glycine_Grams] },

        // Vitamins
        { Nutrients.Vitamin_A, [USDANutrients.Vitamin_A_RAE_Micrograms] },
        { Nutrients.Carotene_Alpha, [USDANutrients.Carotene_alpha_Micrograms] },
        { Nutrients.Carotene_Beta, [USDANutrients.Carotene_beta_Micrograms] },
        { Nutrients.Thiamin_B1, [USDANutrients.Thiamin_Milligrams] },
        { Nutrients.Riboflavin_B2, [USDANutrients.Riboflavin_Milligrams] },
        { Nutrients.Niacin_B3, [USDANutrients.Niacin_Milligrams] },
        { Nutrients.Pantothenic_Acid_B5, [USDANutrients.Pantothenic_acid_Milligrams] },
        { Nutrients.Vitamin_B_6, [USDANutrients.Vitamin_B_6_Milligrams] },
        { Nutrients.Folate_B9, [USDANutrients.Folate_total_Micrograms] },
        { Nutrients.Vitamin_B_12, [USDANutrients.Vitamin_B_12_Micrograms] },
        { Nutrients.Vitamin_C, [USDANutrients.Vitamin_C_total_ascorbic_acid_Milligrams] },
        { Nutrients.Vitamin_E, [USDANutrients.Vitamin_E_alpha_tocopherol_Milligrams] },
        { Nutrients.Vitamin_K, [USDANutrients.Vitamin_K_phylloquinone_Micrograms] },
        { Nutrients.Biotin, [USDANutrients.Biotin_Micrograms] },

        // Minerals
        { Nutrients.Sodium_Na, [USDANutrients.Sodium_Na_Milligrams] },
        { Nutrients.Calcium_Ca, [USDANutrients.Calcium_Ca_Milligrams] },
        { Nutrients.Potassium_K, [USDANutrients.Potassium_K_Milligrams] },
        { Nutrients.Magnesium_Mg, [USDANutrients.Magnesium_Mg_Milligrams] },
        { Nutrients.Phosphorus_P, [USDANutrients.Phosphorus_P_Milligrams] },
        { Nutrients.Iron_Fe, [USDANutrients.Iron_Fe_Milligrams] },
        { Nutrients.Zinc_Zn, [USDANutrients.Zinc_Zn_Milligrams] },
        { Nutrients.Copper_Cu, [USDANutrients.Copper_Cu_Milligrams] },
        { Nutrients.Manganese_Mn, [USDANutrients.Manganese_Mn_Milligrams] },
        { Nutrients.Selenium_Se, [USDANutrients.Selenium_Se_Micrograms] },
        { Nutrients.Iodine_I, [USDANutrients.Iodine_I_Micrograms] },
        { Nutrients.Molybdenum_Mo, [USDANutrients.Molybdenum_Mo_Micrograms] },
        { Nutrients.Boron_B, [USDANutrients.Boron_B_Micrograms] },

        // Extra
        { Nutrients.Energy_KCalorie, [USDANutrients.Energy_Atwater_General_Factors_KCalorie] },
        { Nutrients.Betaine, [USDANutrients.Betaine_Milligrams] },
        { Nutrients.Choline, [USDANutrients.Choline_total_Milligrams] },
        { Nutrients.Lutein_Zeaxanthin, [USDANutrients.Lutein__zeaxanthin_Micrograms] },
    };

    public static IReadOnlyDictionary<Nutrients, List<CanadaNutrients>> NutrientsToCanada => new Dictionary<Nutrients, List<CanadaNutrients>>
    {
        // Macronutrients
        { Nutrients.Protein, [CanadaNutrients.PROTEIN_Grams] },
        { Nutrients.Starch, [CanadaNutrients.STARCH_Grams] },
        { Nutrients.Fiber_total_dietary, [CanadaNutrients.FIBRE_TOTAL_DIETARY_Grams] },
        { Nutrients.Sugars_Total, [CanadaNutrients.SUGARS_TOTAL_Grams] },
        { Nutrients.Total_lipid_fat, [CanadaNutrients.FAT_TOTAL_LIPIDS_Grams] },
        { Nutrients.Fatty_acids_total_trans, [CanadaNutrients.FATTY_ACIDS_TRANS_TOTAL_Grams] },
        { Nutrients.Fatty_acids_total_saturated, [CanadaNutrients.FATTY_ACIDS_SATURATED_TOTAL_Grams] },
        { Nutrients.Fatty_acids_total_monounsaturated, [CanadaNutrients.FATTY_ACIDS_MONOUNSATURATED_TOTAL_Grams] },
        { Nutrients.Fatty_acids_total_polyunsaturated, [CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_Grams] },
        { Nutrients.Omega_3_EPA_DHA, [CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_20_5_n_3_EICOSAPENTAENOIC_EPA_Grams, CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_22_6_n_3_DOCOSAHEXAENOIC_DHA_Grams] },
        { Nutrients.Omega_3_ALA, [CanadaNutrients.FATTY_ACIDS_MONOUNSATURATED_12_1_LAUROLEIC_Grams] },
        { Nutrients.Omega_6, [CanadaNutrients.FATTY_ACIDS_POLYUNSATURATED_TOTAL_OMEGA__N_6_Grams] },

        // Amino acids
        { Nutrients.Histidine, [CanadaNutrients.HISTIDINE_Grams] },
        { Nutrients.Isoleucine, [CanadaNutrients.ISOLEUCINE_Grams] },
        { Nutrients.Leucine, [CanadaNutrients.LEUCINE_Grams] },
        { Nutrients.Lysine, [CanadaNutrients.LYSINE_Grams] },
        { Nutrients.Phenylalanine, [CanadaNutrients.PHENYLALANINE_Grams] },
        { Nutrients.Methionine, [CanadaNutrients.METHIONINE_Grams] },
        { Nutrients.Threonine, [CanadaNutrients.THREONINE_Grams] },
        { Nutrients.Tryptophan, [CanadaNutrients.TRYPTOPHAN_Grams] },
        { Nutrients.Valine, [CanadaNutrients.VALINE_Grams] },
        { Nutrients.Arginine, [CanadaNutrients.ARGININE_Grams] },
        { Nutrients.Glycine, [CanadaNutrients.GLYCINE_Grams] },

        // Vitamins
        { Nutrients.Vitamin_A, [CanadaNutrients.RETINOL_ACTIVITY_EQUIVALENTS_Micrograms] },
        { Nutrients.Carotene_Alpha, [CanadaNutrients.ALPHA_CAROTENE_Micrograms] },
        { Nutrients.Carotene_Beta, [CanadaNutrients.BETA_CAROTENE_Micrograms] },
        { Nutrients.Thiamin_B1, [CanadaNutrients.THIAMIN_Milligrams] },
        { Nutrients.Riboflavin_B2, [CanadaNutrients.RIBOFLAVIN_Milligrams] },
        { Nutrients.Niacin_B3, [CanadaNutrients.TOTAL_NIACIN_EQUIVALENT_MG_NE] },
        { Nutrients.Pantothenic_Acid_B5, [CanadaNutrients.PANTOTHENIC_ACID_Milligrams] },
        { Nutrients.Vitamin_B_6, [CanadaNutrients.VITAMIN_B_6_Milligrams] },
        { Nutrients.Folate_B9, [CanadaNutrients.DIETARY_FOLATE_EQUIVALENTS_Micrograms] },
        { Nutrients.Vitamin_B_12, [CanadaNutrients.VITAMIN_B_12_Micrograms] },
        { Nutrients.Vitamin_C, [CanadaNutrients.VITAMIN_C_Milligrams] },
        { Nutrients.Vitamin_K, [CanadaNutrients.VITAMIN_K_Micrograms] },
        { Nutrients.Biotin, [CanadaNutrients.BIOTIN_Micrograms] },

        // Minerals
        { Nutrients.Sodium_Na, [CanadaNutrients.SODIUM_Milligrams] },
        { Nutrients.Calcium_Ca, [CanadaNutrients.CALCIUM_Milligrams] },
        { Nutrients.Potassium_K, [CanadaNutrients.POTASSIUM_Milligrams] },
        { Nutrients.Magnesium_Mg, [CanadaNutrients.MAGNESIUM_Milligrams] },
        { Nutrients.Phosphorus_P, [CanadaNutrients.PHOSPHORUS_Milligrams] },
        { Nutrients.Iron_Fe, [CanadaNutrients.IRON_Milligrams] },
        { Nutrients.Zinc_Zn, [CanadaNutrients.ZINC_Milligrams] },
        { Nutrients.Copper_Cu, [CanadaNutrients.COPPER_Milligrams] },
        { Nutrients.Manganese_Mn, [CanadaNutrients.MANGANESE_Milligrams] },
        { Nutrients.Selenium_Se, [CanadaNutrients.SELENIUM_Micrograms] },

        // Extra
        { Nutrients.Energy_KCalorie, [CanadaNutrients.ENERGY_KILOCALORIES_KCalorie] },
        { Nutrients.Betaine, [CanadaNutrients.BETAINE_Milligrams] },
        { Nutrients.Choline, [CanadaNutrients.CHOLINE_TOTAL_Milligrams] },
        { Nutrients.Lutein_Zeaxanthin, [CanadaNutrients.LUTEIN_AND_ZEAXANTHIN_Micrograms] },
    };
}
