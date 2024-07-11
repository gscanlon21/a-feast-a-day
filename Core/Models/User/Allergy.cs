using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Allergy : long
{
    None = 0,

    /// <summary>
    /// Lactose intolerance. Milk protein.
    /// </summary>
    [Display(Name = "Lactose", GroupName = "Dairy")]
    Lactose = 1 << 0, // 1

    /// <summary>
    /// Casein intolerance. Milk protein.
    /// </summary>
    [Display(Name = "Casein", GroupName = "Dairy")]
    Casein = 1 << 1, // 2

    /// <summary>
    /// Dairy intolerance. Milk proteins.
    /// </summary>
    [Display(Name = "Dairy", GroupName = "Dairy")]
    Dairy = Lactose | Casein, // 3

    /// <summary>
    ///  Gluten allergy.
    /// </summary>
    [Display(Name = "Gluten")]
    Gluten = 1 << 2, // 4

    /// <summary>
    /// Egg allergy. Also high in choline which can provoke histamine intolerance.
    /// </summary>
    [Display(Name = "Eggs")]
    Eggs = 1 << 3, // 8

    /// <summary>
    /// Tree nut allergy.
    /// </summary>
    [Display(Name = "Tree Nuts")]
    TreeNuts = 1 << 4, // 16

    /// <summary>
    /// Peanut allergy (grown in soil on vines).
    /// </summary>
    [Display(Name = "Peanuts")]
    Peanuts = 1 << 5, // 32

    /// <summary>
    /// Sesame seed allergy.
    /// </summary>
    [Display(Name = "Sesame")]
    Sesame = 1 << 6, // 64

    /// <summary>
    /// Soy allergy.
    /// </summary>
    [Display(Name = "Soy")]
    Soy = 1 << 7, // 128

    /// <summary>
    /// Shellfish allergy.
    /// </summary>
    [Display(Name = "Shellfish")]
    Shellfish = 1 << 8, // 256

    /// <summary>
    /// Fish allergy.
    /// </summary>
    [Display(Name = "Fish")]
    Fish = 1 << 9, // 512

    /// <summary>
    /// Histamine intolerance. Or amine intolerance. 
    /// From fermented foods.
    /// </summary>
    [Display(Name = "Histamine")]
    Histamine = 1 << 10, // 1024

    /// <summary>
    /// Nightshade allergy.
    /// </summary>
    [Display(Name = "Nightshades")]
    Nightshades = 1 << 11, // 2048

    /// <summary>
    /// Oat allergy (rare).
    /// </summary>
    [Display(Name = "Oats")]
    Oats = 1 << 12, // 4096

    /// <summary>
    /// Corn allergy (rare).
    /// </summary>
    [Display(Name = "Corn")]
    Corn = 1 << 13, // 8192

    /// <summary>
    /// Alpha-gal syndrome. 
    /// </summary>
    [Display(Name = "Red Meat")]
    RedMeat = 1 << 14, // 16384

    /// <summary>
    /// Artificial sweeteners/sugars. Xylitol.
    /// </summary>
    [Display(Name = "Sugar Alcohols")]
    SugarAlcohols = 1 << 15, // 32768

    /// <summary>
    /// An artificial sweetener. Not a sugar alcohol.
    /// </summary>
    [Display(Name = "Aspartame")]
    Aspartame = 1 << 16, // 65536

    /// <summary>
    /// Artificial sweeteners.
    /// </summary>
    [Display(Name = "Artificial Sweeteners")]
    ArtificialSweeteners = SugarAlcohols | Aspartame, // 98304

    /// <summary>
    /// Simple sugars.
    /// </summary>
    [Display(Name = "Simple Sugars", Description = "Glucose, Fructose, Galactose")]
    SimpleSugars = 1 << 17, // 131072

    /// <summary>
    /// Carbohydrate Intolerance
    /// </summary>
    [Display(Name = "Carbohydrates")]
    Carbohydrates = Lactose | Casein | SimpleSugars, // 131075

    /// <summary>
    /// Sugar and sugar alternatives.
    /// </summary>
    [Display(Name = "Sugars")]
    Sugars = SugarAlcohols | Aspartame | SimpleSugars, // 229376

    /// <summary>
    /// Artificial colors or flavors. Emulsifiers, Preservatives, Thickener
    /// </summary>
    [Display(Name = "Food Additives")]
    FoodAdditives = 1 << 18, // 262144

    /// <summary>
    /// Yeast allergy.
    /// </summary>
    [Display(Name = "Yeast")]
    Yeast = 1 << 19, // 524288

    /// <summary>
    /// Fermentable Oligosaccharides, Disaccharides, Monosaccharides and Polyols.
    /// </summary>
    [Display(Name = "FODMAP")]
    FODMAP = 1 << 20, // 1048576

    /// <summary>
    /// Caffeine intolerance.
    /// </summary>
    [Display(Name = "Caffeine")]
    Caffeine = 1 << 21, // 2097152

    /// <summary>
    /// Sulfites are chemical compounds that contain a sulfur ion.
    /// </summary>
    [Display(Name = "Sulfites")]
    Sulfites = 1 << 22, // 4194304

    /// <summary>
    /// Salicylates sensitivity. A salt.
    /// </summary>
    [Display(Name = "Salicylates")]
    Salicylates = 1 << 23, // 8388608

    [Display(Name = "Banana")]
    Banana = 1 << 24, // 16777216

    [Display(Name = "Citrus Fruit")]
    CitrusFruit = 1 << 25, // 33554432

    [Display(Name = "Alcohol")]
    Alcohol = 1 << 26, // 67108864

    [Display(Name = "Chocolate")]
    Chocolate = 1 << 27, // 134217728
}
