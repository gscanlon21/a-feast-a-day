using Core.Models.User;

namespace Core.Code.Helpers;

public static class NutrientHelpers
{
    public static readonly List<Nutrients> All2 = [
        // Macronutrients
        Nutrients.Carbohydrates_Grams,
        Nutrients.Fiber_total_dietary_Grams,
        Nutrients.Fiber_soluble_Grams,
        Nutrients.Fiber_insoluble_Grams,
        Nutrients.Total_Sugars_Grams,
        Nutrients.Sugars_Total_Grams,

        // Vitamins
        Nutrients.Vitamin_A_Micrograms,
        Nutrients.Vitamin_B_6_Milligrams,
        Nutrients.Vitamin_B_12_Micrograms,
        Nutrients.Vitamin_C_total_ascorbic_acid_Milligrams,
        Nutrients.Vitamin_D_D2__D3_Micrograms,
        //Nutrients.Carotene_MCG_RE,

        // Fatty Acids
        //Nutrients.Fatty_acids_total_saturated_Grams,
        //Nutrients.Fatty_acids_total_trans_Grams,

        // Minerals
        Nutrients.Cholesterol_Milligrams,
        Nutrients.Sodium_Na_Milligrams,
        Nutrients.Calcium_Ca_Milligrams,
        Nutrients.Potassium_K_Milligrams,
        Nutrients.Choline_total_Milligrams,
        Nutrients.Folate_total_Micrograms,
        Nutrients.Pantothenic_acid_Milligrams,
        Nutrients.Magnesium_Mg_Milligrams,
        Nutrients.Manganese_Mn_Milligrams,
        Nutrients.Selenium_Se_Micrograms,
        Nutrients.Iron_Fe_Milligrams,
        Nutrients.Zinc_Zn_Milligrams,
        Nutrients.Copper_Cu_Milligrams,
    ];
}
