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

    [Display(Name = "Ounces", ShortName = "oz.")]
    Ounces = 4,

    [Display(Name = "Pounds", ShortName = "lb.")]
    Pounds = 5,

    [Display(Name = "Cups", ShortName = "cups")]
    Cups = 6,

    [Display(Name = "Tablespoons", ShortName = "tbsp.")]
    Tablespoons = 7,

    [Display(Name = "Teaspoons", ShortName = "tsp.")]
    Teaspoons = 8,

    [Display(Name = "Fluid Ounces", ShortName = "fl oz.")]
    FluidOunces = 9,

    [Display(Name = "Percent", ShortName = "%")]
    Percent = 10,

    [Display(Name = "IU")]
    IU = 11,
}

public static class MeasureConsts
{
    public static Measure[] DryMeasures => [Measure.Grams, Measure.Milligrams, Measure.Micrograms, Measure.Ounces, Measure.Pounds];
    public static Measure[] LiquidMeasures => [Measure.Cups, Measure.Tablespoons, Measure.Teaspoons, Measure.FluidOunces];
    public static Measure[] StandardMeasures => [Measure.Grams, Measure.Milligrams, Measure.Micrograms, Measure.Percent, Measure.IU];
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