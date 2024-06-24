using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

public enum Measure
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Micrograms", ShortName = "mcg")]
    Micrograms = 1,

    [Display(Name = "Milligrams", ShortName = "mg")]
    Milligrams = 2,

    [Display(Name = "Grams", ShortName = "g")]
    Grams = 3,

    [Display(Name = "Ounces")]
    Ounces = 4,

    [Display(Name = "Pounds", ShortName = "lb.")]
    Pound = 5,

    [Display(Name = "Cups")]
    Cup = 6,

    [Display(Name = "Tablespoons", ShortName = "Tbsp.")]
    Tablespoons = 7,

    [Display(Name = "Teaspoons", ShortName = "tsp.")]
    Teaspoons = 8,

    [Display(Name = "IU")]
    IU = 9,

    [Display(Name = "Percent", ShortName = "%")]
    Percent = 10,

    [Display(Name = "Bottle")]
    Bottle = 11,

    [Display(Name = "Package")]
    Package = 12,

    [Display(Name = "Head")]
    Head = 13,

    [Display(Name = "Splash")]
    Splash = 14,

    [Display(Name = "Jar")]
    Jar = 15,

    [Display(Name = "Slices")]
    Slices = 16,

    [Display(Name = "Handful")]
    Handful = 17,

    [Display(Name = "Pinch")]
    Pinch = 18,

    [Display(Name = "Can")]
    Can = 19,

    [Display(Name = "Cloves")]
    Cloves = 20,

    [Display(Name = "Leaves")]
    Leaves = 21,

    [Display(Name = "Stick")]
    Sticks = 22,
}

public static class MeasureConsts
{
    public static Measure[] StandardMeasures => [Measure.Grams, Measure.Milligrams, Measure.Micrograms, Measure.IU, Measure.Percent];
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