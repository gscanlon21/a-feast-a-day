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

    /// <summary>
    /// US Legal Cup. 240 ml/grams of water.
    /// </summary>
    [Display(Name = "Cups", ShortName = "c.")]
    Cups = 6,

    /// <summary>
    /// Metric tablespoon. 15 ml/grams of water.
    /// </summary>
    [Display(Name = "Tablespoons", ShortName = "tbsp.")]
    Tablespoons = 7,

    /// <summary>
    /// 5 ml/grams of water.
    /// </summary>
    [Display(Name = "Teaspoons", ShortName = "tsp.")]
    Teaspoons = 8,

    [Display(Name = "Fluid Ounces", ShortName = "fl oz.")]
    FluidOunces = 9,

    [Display(Name = "Milliliters", ShortName = "ml")]
    Milliliters = 10,

    [Display(Name = "Liters", ShortName = "l")]
    Liters = 11,

    [Display(Name = "Gallons", ShortName = "gal")]
    Gallons = 12,

    [Display(Name = "Pints", ShortName = "pt")]
    Pints = 13,

    // This changes depending on the substance.
    //[Display(Name = "IU")]
    //IU = 99,

    [Display(Name = "Percent", ShortName = "%")]
    Percent = 100,
}

public static class MeasureConsts
{
    /// <summary>
    /// Nutrient measures.
    /// </summary>
    public static Measure[] StandardMeasures => [Measure.Grams, Measure.Milligrams, Measure.Micrograms, Measure.Percent/*, Measure.IU*/];

    /// <summary>
    /// Measures used to measure dry ingredients.
    /// </summary>
    public static Measure[] DryMeasures => [Measure.Grams, Measure.Milligrams, Measure.Micrograms, Measure.Ounces, Measure.Pounds];

    /// <summary>
    /// Measures used to measure liquids.
    /// </summary>
    public static Measure[] LiquidMeasures => [Measure.Cups, Measure.Tablespoons, Measure.Teaspoons, Measure.FluidOunces, Measure.Milliliters, Measure.Liters, Measure.Gallons, Measure.Pints];
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