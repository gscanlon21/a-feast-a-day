using System.ComponentModel.DataAnnotations;

namespace Core.Models.Ingredients;

[Flags]
public enum Category
{
    [Display(Name = "None", Order = 0)]
    None = 0,

    [Display(Name = "Produce", Order = 1)]
    Produce = 1,

    [Display(Name = "Bakery", Order = 2)]
    Bakery = 2,

    [Display(Name = "Deli", Order = 3)]
    Deli = 3,

    [Display(Name = "Pantry", Order = 4)]
    Pantry = 4,

    [Display(Name = "Baking", Order = 5)]
    Baking = 5,

    [Display(Name = "Snacks", Order = 6)]
    Snacks = 6,

    [Display(Name = "Beverages", Order = 7)]
    Beverages = 7,

    [Display(Name = "Dairy", Order = 8)]
    Dairy = 8,

    [Display(Name = "Meat", Order = 9)]
    Meat = 9,

    [Display(Name = "Seafood", Order = 10)]
    Seafood = 10,

    [Display(Name = "Frozen", Order = 11)]
    Frozen = 11,

    [Display(Name = "International", Order = 12)]
    International = 12,

    [Display(Name = "Household", Order = 13)]
    Household = 13,
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
