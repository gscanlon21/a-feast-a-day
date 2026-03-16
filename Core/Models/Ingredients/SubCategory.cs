using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum SubCategory
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Fruit", Order = 1)]
    Fruit = 1,

    [Display(Name = "Vegetable", Order = 2)]
    Vegetable = 2,

    [Display(Name = "Herb", Order = 3)]
    Herb = 3,

    [Display(Name = "Grain", Order = 4)]
    Grain = 4,

    [Display(Name = "Pasta", Order = 5)]
    Pasta = 5,

    [Display(Name = "Legume", Order = 6)]
    Legume = 6,

    [Display(Name = "Meat", Order = 7)]
    Meat = 7,

    [Display(Name = "Seafood", Order = 8)]
    Seafood = 8,

    [Display(Name = "Dairy", Order = 9)]
    Dairy = 9,

    [Display(Name = "Egg", Order = 10)]
    Egg = 10,

    [Display(Name = "Oil", Order = 11)]
    Oil = 11,

    [Display(Name = "Spice", Order = 12)]
    Spice = 12,

    [Display(Name = "Condiment", Order = 13)]
    Condiment = 13,

    [Display(Name = "Sauce", Order = 14)]
    Sauce = 14,

    [Display(Name = "Flour", Order = 15)]
    Flour = 15,

    [Display(Name = "Sweetener", Order = 16)]
    Sweetener = 16,

    [Display(Name = "Chocolate", Order = 17)]
    Chocolate = 17,

    [Display(Name = "Nut", Order = 18)]
    Nut = 18,

    [Display(Name = "Seed", Order = 19)]
    Seed = 19,

    [Display(Name = "Beverage", Order = 20)]
    Beverage = 20,
}

/* Swap two measures.
do $$
declare 
	BeginMeasure integer = 99;
 	EndMeasure integer = 99;
 	TempMeasure integer = 999;
begin
	update ingredient set "DefaultMeasure" = TempMeasure where "DefaultMeasure" = EndMeasure;
	update nutrient set "Measure" = TempMeasure where "Measure" = EndMeasure;
	update recipe_ingredient set "Measure" = TempMeasure where "Measure" = EndMeasure;

	update ingredient set "DefaultMeasure" = EndMeasure where "DefaultMeasure" = BeginMeasure;
	update nutrient set "Measure" = EndMeasure where "Measure" = BeginMeasure;
	update recipe_ingredient set "Measure" = EndMeasure where "Measure" = BeginMeasure;

	update ingredient set "DefaultMeasure" = BeginMeasure where "DefaultMeasure" = TempMeasure;
	update nutrient set "Measure" = BeginMeasure where "Measure" = TempMeasure;
	update recipe_ingredient set "Measure" = BeginMeasure where "Measure" = TempMeasure;
end; $$;
*/
