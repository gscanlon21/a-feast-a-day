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
        Nutrients.Carbohydrates_Grams,
        Nutrients.Total_lipid_fat_Grams,
        Nutrients.Starch_Grams,
        Nutrients.Resistant_starch_Grams,
        Nutrients.Oligosaccharides_Grams,
        Nutrients.Oligosaccharides_Milligrams,
        Nutrients.Fiber_total_dietary_Grams,
        Nutrients.Fiber_soluble_Grams,
        Nutrients.Fiber_insoluble_Grams,
        Nutrients.Total_Sugars_Grams,
        Nutrients.Sugars_Total_Grams,
        Nutrients.Fatty_acids_total_saturated_Grams,
        Nutrients.Fatty_acids_total_monounsaturated_Grams,
        Nutrients.Fatty_acids_total_polyunsaturated_Grams,
        Nutrients.Fatty_acids_total_trans_Grams,
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
        Nutrients.Vitamin_A_Micrograms,
        Nutrients.Thiamin_Milligrams, // B1
        Nutrients.Riboflavin_Milligrams, // B2
        Nutrients.Niacin_Milligrams, // B3
        Nutrients.Pantothenic_acid_Milligrams, // B5
        Nutrients.Vitamin_B_6_Milligrams,
        Nutrients.Biotin_Micrograms, // B7
        Nutrients.Folate_total_Micrograms, // B9
        Nutrients.Vitamin_B_12_Micrograms,
        Nutrients.Vitamin_C_total_ascorbic_acid_Milligrams,
        Nutrients.Vitamin_D_D2__D3_Micrograms,
        Nutrients.Vitamin_E_Milligrams,
        Nutrients.Vitamin_K_phylloquinone_Micrograms,
        Nutrients.Retinol_Micrograms,
        Nutrients.Carotene_MCG_RE,
    ];

    private static Nutrients[] Minerals() =>
    [
        Nutrients.Sodium_Na_Milligrams,
        Nutrients.Calcium_Ca_Milligrams,
        Nutrients.Potassium_K_Milligrams,
        Nutrients.Magnesium_Mg_Milligrams,
        Nutrients.Phosphorus_P_Milligrams,
        Nutrients.Sulfur_S_Milligrams,
        Nutrients.Chlorine_Cl_Milligrams,
        Nutrients.Iron_Fe_Milligrams,
        Nutrients.Zinc_Zn_Milligrams,
        Nutrients.Copper_Cu_Milligrams,
        Nutrients.Manganese_Mn_Milligrams,
        Nutrients.Selenium_Se_Micrograms,
        Nutrients.Iodine_I_Micrograms,
        Nutrients.Molybdenum_Mo_Micrograms,
        Nutrients.Chromium_Cr_Micrograms,
        Nutrients.Fluoride_F_Micrograms,
        Nutrients.Boron_B_Micrograms,
        Nutrients.Vanadium_V_Micrograms,
        Nutrients.Lithium_Li_Micrograms,
    ];

    private static Nutrients[] Extra() => 
    [
        // TODO/FIXME: Macronutrient to calorie conversion values are not static.
        // See food_calorie_conversion_factor.csv for true values.
        //Nutrients.Energy_Atwater_Specific_Factors_KCalorie,
        Nutrients.Energy_Atwater_General_Factors_KCalorie,
        
        Nutrients.Betaine_Milligrams,
        Nutrients.Choline_total_Milligrams,
        Nutrients.Flavonoids_total_Milligrams,
        Nutrients.Polyphenols_total_Milligrams,
    ];
}
