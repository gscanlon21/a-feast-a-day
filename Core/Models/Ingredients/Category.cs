using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

/// <summary>
/// Grocery store areas.
/// </summary>
[Flags]
public enum Category : long
{
    [Display(Order = 0, Name = "None")]
    None = 0,

    #region Produce

    [Display(Order = 1, Name = "Produce")]
    Produce = Produce_Fruits | Produce_Vegetables | Produce_Herbs,

    [Display(Order = 1, Name = "Fruits")]
    Produce_Fruits = 1L << 0,

    [Display(Order = 2, Name = "Vegetables")]
    Produce_Vegetables = 1L << 1,

    [Display(Order = 3, Name = "Herbs")]
    Produce_Herbs = 1L << 2,

    #endregion
    #region Bakery

    [Display(Order = 2, Name = "Bakery")]
    Bakery = Grains | Pastries,

    [Display(Order = 1, Name = "Grains")]
    Grains = 1L << 5,

    [Display(Order = 2, Name = "Pastries")]
    Pastries = 1L << 6,

    #endregion
    #region Deli

    [Display(Order = 3, Name = "Deli")]
    Deli = Deli_Meat | Deli_Cheese | Deli_Prepared,

    [Display(Order = 1, Name = "Meats")]
    Deli_Meat = 1L << 10,

    [Display(Order = 2, Name = "Cheese")]
    Deli_Cheese = 1L << 11,

    [Display(Order = 3, Name = "Prepared Meals")]
    Deli_Prepared = 1L << 12,

    #endregion
    #region Pantry

    [Display(Order = 4, Name = "Pantry")]
    Pantry = Pantry_Condiments | Pantry_Legumes | Pantry_Pasta | Pantry_Sauces | Pantry_Oils | Pantry_Spices
        | Pantry_Sweeteners | Pantry_Chocolate | Pantry_Candy | Pantry_Nuts | Pantry_Seeds | Pantry_Snacks | Pantry_Beverages,

    [Display(Order = 1, Name = "Condiments")]
    Pantry_Condiments = 1L << 15,

    [Display(Order = 2, Name = "Grains")]
    Pantry_Grains = 1L << 16,

    [Display(Order = 3, Name = "Legumes")]
    Pantry_Legumes = 1L << 17,

    [Display(Order = 4, Name = "Pasta")]
    Pantry_Pasta = 1L << 18,

    [Display(Order = 5, Name = "Sauces")]
    Pantry_Sauces = 1L << 19,

    [Display(Order = 6, Name = "Oils")]
    Pantry_Oils = 1L << 20,

    [Display(Order = 7, Name = "Spices")]
    Pantry_Spices = 1L << 21,

    [Display(Order = 8, Name = "Sweeteners")]
    Pantry_Sweeteners = 1L << 22,

    [Display(Order = 9, Name = "Chocolate")]
    Pantry_Chocolate = 1L << 23,

    [Display(Order = 10, Name = "Candy")]
    Pantry_Candy = 1L << 24,

    [Display(Order = 11, Name = "Nuts")]
    Pantry_Nuts = 1L << 25,

    [Display(Order = 12, Name = "Seeds")]
    Pantry_Seeds = 1L << 26,

    [Display(Order = 13, Name = "Snacks")]
    Pantry_Snacks = 1L << 27,

    [Display(Order = 14, Name = "Beverages")]
    Pantry_Beverages = 1L << 28,

    #endregion
    #region Protein

    [Display(Order = 5, Name = "Protein")]
    Protein = Protein_Meat | Protein_Seafood,

    [Display(Order = 1, Name = "Meat")]
    Protein_Meat = 1L << 35,

    [Display(Order = 2, Name = "Seafood")]
    Protein_Seafood = 1L << 36,

    #endregion
    #region Frozen

    [Display(Order = 6, Name = "Frozen")]
    Frozen = Frozen_Fruit | Frozen_Vegetables | Frozen_Meals | Frozen_Pizza | Frozen_IceCream,

    [Display(Order = 1, Name = "Frozen Fruit")]
    Frozen_Fruit = 1L << 40,

    [Display(Order = 2, Name = "Frozen Vegetables")]
    Frozen_Vegetables = 1L << 41,

    [Display(Order = 3, Name = "Frozen Meals")]
    Frozen_Meals = 1L << 42,

    [Display(Order = 4, Name = "Frozen Pizza")]
    Frozen_Pizza = 1L << 43,

    [Display(Order = 4, Name = "Ice Cream")]
    Frozen_IceCream = 1L << 44,

    #endregion
    #region Dairy

    [Display(Order = 7, Name = "Dairy")]
    Dairy = Dairy_Milk | Dairy_Cheese | Dairy_Eggs,

    [Display(Order = 1, Name = "Milk")]
    Dairy_Milk = 1L << 50,

    [Display(Order = 2, Name = "Cheese")]
    Dairy_Cheese = 1L << 51,

    [Display(Order = 3, Name = "Eggs")]
    Dairy_Eggs = 1L << 52,

    #endregion
    #region Other

    [Display(Order = 8, Name = "Other")]
    Other = Other_Supplements | Other_Household,

    [Display(Order = 1, Name = "Supplements")]
    Other_Supplements = 1L << 55,

    [Display(Order = 2, Name = "Household")]
    Other_Household = 1L << 56,

    #endregion
}

/* Swap two categories.
do $$
declare 
	BeginCategory integer = 99;
 	EndCategory integer = 99;
 	TempCategory integer = 999;
begin
	update ingredient set "Category" = TempCategory where "Category" = EndCategory;
	update ingredient set "Category" = EndCategory where "Category" = BeginCategory;
	update ingredient set "Category" = BeginCategory where "Category" = TempCategory;
end; $$;
*/
