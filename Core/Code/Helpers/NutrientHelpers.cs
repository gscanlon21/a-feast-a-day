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
/// Nutrients.Sugars_Added,
/// Nutrients.Boron_B,
/// 
/// These do not have dietary intake references:
/// Nutrients.Total_Sugars,
/// Nutrients.Lycopene,
/// Nutrients.Betaine,
/// </summary>
public static class NutrientHelpers
{
    /// <summary>
    /// Get the user's source-specified tracked nutrients.
    /// </summary>
    public static Nutrients[] Selected(DataSource dataSource)
    {
        return dataSource switch
        {
            DataSource.USDA => NutrientsToUSDA.Keys.ToArray(),
            DataSource.Canada => NutrientsToCanada.Keys.ToArray(),
            _ => All,
        };
    }

    /// <summary>
    /// Nutrients that we want to track.
    /// </summary>
    public static readonly Nutrients[] All =
    [
        // Macronutrients
        Nutrients.Protein,
        Nutrients.Starch,
        Nutrients.Resistant_Starch,
        Nutrients.Fiber_Total_Dietary,
        Nutrients.Total_Lipid_Fat,
        Nutrients.Fatty_Acids_Total_Trans,
        Nutrients.Fatty_Acids_Total_Saturated,
        Nutrients.Fatty_Acids_Total_Monounsaturated,
        Nutrients.Fatty_Acids_Total_Polyunsaturated,
        Nutrients.Omega_3_EPA_DHA,
        Nutrients.Omega_3_ALA,
        Nutrients.Omega_6,

        // Amino Acids
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

        // Vitamins
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
        Nutrients.Vitamin_K,

        // Minerals
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

        // Extra
        Nutrients.Choline,
        Nutrients.Energy_KCalorie,
        Nutrients.Lutein_Zeaxanthin,
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
    ];

    /// <summary>
    /// Maps a Nutrients to one or many USDANutrients.
    /// Anything in All that is missing from this list will show as disabled to the user.
    /// </summary>
    public static IReadOnlyDictionary<Nutrients, List<USDANutrients>> NutrientsToUSDA => new Dictionary<Nutrients, List<USDANutrients>>
    {
        // Macronutrients
        { Nutrients.Protein, [USDANutrients.Protein_Grams] },
        { Nutrients.Starch, [USDANutrients.Starch_Grams] },
        { Nutrients.Resistant_Starch, [USDANutrients.Resistant_starch_Grams] },
        { Nutrients.Fiber_Total_Dietary, [USDANutrients.Fiber_total_dietary_Grams] },
        { Nutrients.Total_Lipid_Fat, [USDANutrients.Total_lipid_fat_Grams] },
        { Nutrients.Fatty_Acids_Total_Trans, [USDANutrients.Fatty_acids_total_trans_Grams] },
        { Nutrients.Fatty_Acids_Total_Saturated, [USDANutrients.Fatty_acids_total_saturated_Grams] },
        { Nutrients.Fatty_Acids_Total_Monounsaturated, [USDANutrients.Fatty_acids_total_monounsaturated_Grams] },
        { Nutrients.Fatty_Acids_Total_Polyunsaturated, [USDANutrients.Fatty_acids_total_polyunsaturated_Grams] },
        { Nutrients.Omega_6, [USDANutrients.PUFA_20_3_n_6_Grams, USDANutrients.PUFA_20_4_n_6_Grams, USDANutrients.PUFA_20_2_n_6_c_c_Grams, USDANutrients.PUFA_18_3_n_6_c_c_c_Grams, USDANutrients.PUFA_18_2_n_6_c_c_Grams] },
        { Nutrients.Omega_3_EPA_DHA, [USDANutrients.PUFA_22_6_n_3_DHA_Grams, USDANutrients.PUFA_20_5_n_3_EPA_Grams] },
        { Nutrients.Omega_3_ALA, [USDANutrients.PUFA_18_3_n_3_c_c_c_ALA_Grams] },

        // Amino Acids
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

        // Extra
        { Nutrients.Choline, [USDANutrients.Choline_total_Milligrams] },
        { Nutrients.Lutein_Zeaxanthin, [USDANutrients.Lutein__zeaxanthin_Micrograms] },
        { Nutrients.Energy_KCalorie, [USDANutrients.Energy_KCalorie, USDANutrients.Energy_Atwater_General_Factors_KCalorie] },
        // SELECT "IngredientId", "Nutrients" FROM usda_nutrient WHERE "Nutrients" IN (1008, 2047) GROUP BY "IngredientId", "Nutrients" HAVING COUNT(*) > 1
        // Energy_KCalorie seems to be for legacy ingredients, while Atwater_..._Factors seems to be for the foundation foods.
    };

    /// <summary>
    /// Maps a Nutrients to one or many CanadaNutrients.
    /// Anything in All that is missing from this list will show as disabled to the user.
    /// </summary>
    public static IReadOnlyDictionary<Nutrients, List<CanadaNutrients>> NutrientsToCanada => new Dictionary<Nutrients, List<CanadaNutrients>>
    {
        // Macronutrients
        { Nutrients.Protein, [CanadaNutrients.Protein_Grams] },
        { Nutrients.Fiber_Total_Dietary, [CanadaNutrients.Fibre_total_dietary_Grams] },
        { Nutrients.Total_Lipid_Fat, [CanadaNutrients.Fat_total_lipids_Grams] },
        { Nutrients.Fatty_Acids_Total_Trans, [CanadaNutrients.Fatty_acids_trans_total_Grams] },
        { Nutrients.Fatty_Acids_Total_Saturated, [CanadaNutrients.Fatty_acids_saturated_total_Grams] },
        { Nutrients.Fatty_Acids_Total_Monounsaturated, [CanadaNutrients.Fatty_acids_monounsaturated_total_Grams] },
        { Nutrients.Fatty_Acids_Total_Polyunsaturated, [CanadaNutrients.Fatty_acids_polyunsaturated_total_Grams] },
        { Nutrients.Omega_3_EPA_DHA, [CanadaNutrients.Fatty_acids_polyunsaturated_20_5_n_3_eicosapentaenoic_EPA_Grams, CanadaNutrients.Fatty_acids_polyunsaturated_22_6_n_3_docosahexaenoic_DHA_Grams] },
        { Nutrients.Omega_3_ALA, [CanadaNutrients.Fatty_acids_monounsaturated_12_1_lauroleic_Grams] },
        { Nutrients.Omega_6, [CanadaNutrients.Fatty_acids_polyunsaturated_22_5n_6_Grams] },

        // Amino Acids
        { Nutrients.Histidine, [CanadaNutrients.Histidine_Grams] },
        { Nutrients.Isoleucine, [CanadaNutrients.Isoleucine_Grams] },
        { Nutrients.Leucine, [CanadaNutrients.Leucine_Grams] },
        { Nutrients.Lysine, [CanadaNutrients.Lysine_Grams] },
        { Nutrients.Phenylalanine, [CanadaNutrients.Phenylalanine_Grams] },
        { Nutrients.Methionine, [CanadaNutrients.Methionine_Grams] },
        { Nutrients.Threonine, [CanadaNutrients.Threonine_Grams] },
        { Nutrients.Tryptophan, [CanadaNutrients.Tryptophan_Grams] },
        { Nutrients.Valine, [CanadaNutrients.Valine_Grams] },
        { Nutrients.Arginine, [CanadaNutrients.Arginine_Grams] },
        { Nutrients.Glycine, [CanadaNutrients.Glycine_Grams] },

        // Vitamins
        { Nutrients.Vitamin_A, [CanadaNutrients.Retinol_activity_equivalents_Micrograms] },
        { Nutrients.Carotene_Alpha, [CanadaNutrients.Alpha_carotene_Micrograms] },
        { Nutrients.Carotene_Beta, [CanadaNutrients.Beta_carotene_Micrograms] },
        { Nutrients.Thiamin_B1, [CanadaNutrients.Thiamine_Milligrams] },
        { Nutrients.Riboflavin_B2, [CanadaNutrients.Riboflavin_Milligrams] },
        // NOTE: Equivalency conversions are only necessary if the value list
        // contains Tryptophan and Niacin, not the already calculated equvalency.
        { Nutrients.Niacin_B3, [CanadaNutrients.Total_niacin_equivalent_MG_NE] },
        { Nutrients.Pantothenic_Acid_B5, [CanadaNutrients.Pantothenic_acid_Milligrams] },
        { Nutrients.Vitamin_B_6, [CanadaNutrients.Vitamin_B_6_Milligrams] },
        { Nutrients.Folate_B9, [CanadaNutrients.Dietary_folate_equivalents_Micrograms] },
        { Nutrients.Vitamin_B_12, [CanadaNutrients.Vitamin_B_12_Micrograms] },
        { Nutrients.Vitamin_C, [CanadaNutrients.Vitamin_C_Milligrams] },
        { Nutrients.Vitamin_K, [CanadaNutrients.Vitamin_K_dihydrophylloquinone_Micrograms, CanadaNutrients.Vitamin_K_menaquinone_4_Micrograms, CanadaNutrients.Vitamin_K_phylloquinone_Micrograms] },
        { Nutrients.Biotin, [CanadaNutrients.Biotin_Micrograms] },

        // Minerals
        { Nutrients.Sodium_Na, [CanadaNutrients.Sodium_Milligrams] },
        { Nutrients.Calcium_Ca, [CanadaNutrients.Calcium_Milligrams] },
        { Nutrients.Potassium_K, [CanadaNutrients.Potassium_Milligrams] },
        { Nutrients.Magnesium_Mg, [CanadaNutrients.Magnesium_Milligrams] },
        { Nutrients.Phosphorus_P, [CanadaNutrients.Phosphorus_Milligrams] },
        { Nutrients.Iron_Fe, [CanadaNutrients.Iron_Milligrams] },
        { Nutrients.Zinc_Zn, [CanadaNutrients.Zinc_Milligrams] },
        { Nutrients.Copper_Cu, [CanadaNutrients.Copper_Milligrams] },
        { Nutrients.Manganese_Mn, [CanadaNutrients.Manganese_Milligrams] },
        { Nutrients.Selenium_Se, [CanadaNutrients.Selenium_Micrograms] },

        // Extra
        { Nutrients.Energy_KCalorie, [CanadaNutrients.Energy_kilocalories_KCalorie] },
        { Nutrients.Lutein_Zeaxanthin, [CanadaNutrients.Lutein_and_zeaxanthin_Micrograms] },
        { Nutrients.Choline, [CanadaNutrients.Choline_total_Milligrams] },
    };

    /// <summary>
    /// Maps a USDANutrients back to Nutrients.
    /// </summary>
    public static readonly IReadOnlyDictionary<USDANutrients, Nutrients> USDAToNutrients =
        NutrientsToUSDA.SelectMany(x => x.Value.Select(v => (x.Key, Value: v))).ToDictionary(x => x.Value, x => x.Key);

    /// <summary>
    /// Maps a CanadaNutrients back to Nutrients.
    /// </summary>
    public static readonly IReadOnlyDictionary<CanadaNutrients, Nutrients> CanadaToNutrients =
        NutrientsToCanada.SelectMany(x => x.Value.Select(v => (x.Key, Value: v))).ToDictionary(x => x.Value, x => x.Key);
}
