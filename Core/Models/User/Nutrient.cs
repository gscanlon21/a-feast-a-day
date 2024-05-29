using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Nutrient : long
{
    None = 0,

    // Macronutrients
    [Display(Name = "Proteins", GroupName = "Proteins")]
    Proteins = 1 << 0, // 1

    [Display(Name = "Starch", GroupName = "Carbohydrates")]
    Starch = 1 << 1, // 2

    [Display(Name = "Soluble Fiber", GroupName = "Carbohydrates")]
    SolubleFiber = 1 << 2, // 4

    [Display(Name = "Insoluble Fiber", GroupName = "Carbohydrates")]
    InsolubleFiber = 1 << 3, // 8

    [Display(Name = "Fiber", GroupName = "Carbohydrates")]
    Fiber = SolubleFiber | InsolubleFiber, // 12

    [Display(Name = "Sugar", GroupName = "Carbohydrates")]
    Sugar = 1 << 4, // 16

    [Display(Name = "Oligosaccharides", GroupName = "Carbohydrates")]
    Oligosaccharides = 1 << 5, // 32

    [Display(Name = "Carbohydrates", GroupName = "Carbohydrates")]
    Carbohydrates = Starch | Fiber | Sugar | Oligosaccharides, // 62

    [Display(Name = "Monounsaturated Fats", GroupName = "Fats")]
    MonounsaturatedFats = 1 << 6, // 64

    [Display(Name = "Polyunsaturated Fats", GroupName = "Fats")]
    PolyunsaturatedFats = 1 << 7, // 128

    [Display(Name = "Unsaturated Fats", GroupName = "Fats")]
    UnsaturatedFats = MonounsaturatedFats | PolyunsaturatedFats, // 192

    [Display(Name = "Saturated Fats", GroupName = "Fats")]
    SaturatedFats = 1 << 8, // 256

    [Display(Name = "Trans Fats", GroupName = "Fats")]
    TransFats = 1 << 9, // 512

    [Display(Name = "Fats", GroupName = "Fats")]
    Fats = UnsaturatedFats | SaturatedFats | TransFats, // 960

    /// <summary>
    /// Good Cholesterol.
    /// </summary>
    [Display(Name = "HDL Cholesterol", GroupName = "Cholesterol")]
    HDLCholesterol = 1 << 10, // 1024

    /// <summary>
    /// Bad Cholesterol.
    /// </summary>
    [Display(Name = "LDL Cholesterol", GroupName = "Cholesterol")]
    LDLCholesterol = 1 << 11, // 2048

    [Display(Name = "Cholesterol", GroupName = "Cholesterol")]
    Cholesterol = HDLCholesterol | LDLCholesterol, // 3072

    // Vitamins
    [Display(Name = "Vitamin A (Retinoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminARetinoids = 1 << 15, // 32768

    [Display(Name = "Vitamin A (Carotenoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminACartenoids = 1 << 16, // 65536

    [Display(ShortName = "Vitamin A", Name = "Vitamin A (Retinoids and Carotenoids)", GroupName = "Vitamin A", Description = "beef, liver, eggs, shrimp, fish, fortified milk, sweet potatoes, carrots, pumpkins, spinach, mangoes")]
    VitaminA = VitaminARetinoids | VitaminACartenoids, // 98304

    [Display(ShortName = "B1", Name = "B1 (Thiamine)", GroupName = "Vitamin B", Description = "ham, soymilk, watermelon, acorn squash")]
    B1 = 1 << 17, // 131072

    [Display(ShortName = "B2", Name = "B2 (Riboflavin)", GroupName = "Vitamin B", Description = "milk, yogurt, cheese, whole and enriched grains and cereals.")]
    B2 = 1 << 18, // 262144

    [Display(ShortName = "B3", Name = "B3 (Niacin)", GroupName = "Vitamin B", Description = "meat, poultry, fish, fortified and whole grains, mushrooms, potatoes")]
    B3 = 1 << 19, // 524288

    [Display(ShortName = "B5", Name = "B5 (Pantothenic Acid)", GroupName = "Vitamin B", Description = "chicken, whole grains, broccoli, avocados, mushrooms")]
    B5 = 1 << 20, // 1048576

    [Display(ShortName = "B6", Name = "B6 (Pyridoxine)", GroupName = "Vitamin B", Description = "meat, fish, poultry, legumes, tofu and other soy products, bananas")]
    B6 = 1 << 21, // 2097152

    [Display(ShortName = "B7", Name = "B7 (Biotin)", GroupName = "Vitamin B", Description = "Whole grains, eggs, soybeans, fish")]
    B7 = 1 << 22, // 4194304

    /// <summary>
    /// NOT folic acid: we are not tracking the artificial version of folate 
    /// because it is not well utilized by the body. It can even contribute 
    /// to folate deficiency and other adverse side effects!
    /// https://education.seekinghealth.com/folic-acid-side-effects/
    /// </summary>
    [Display(ShortName = "B9", Name = "B9 (Folinic Acid)", GroupName = "Vitamin B", Description = "Fortified grains and cereals, asparagus, spinach, broccoli, legumes (black-eyed peas and chickpeas), orange juice")]
    B9 = 1 << 23, // 8388608

    [Display(ShortName = "B12", Name = "B12 (Cobalamin)", GroupName = "Vitamin B", Description = "Meat, poultry, fish, milk, cheese, fortified soymilk and cereals")]
    B12 = 1 << 24, // 16777216

    [Display(ShortName = "Vitamin C", Name = "Vitamin C (Ascorbic Acid)", GroupName = "Vitamin C", Description = "Citrus fruit, potatoes, broccoli, bell peppers, spinach, strawberries, tomatoes, Brussels sprouts")]
    VitaminC = 1 << 25, // 33554432

    [Display(ShortName = "Vitamin D", Name = "Vitamin D (Calciferol)", GroupName = "Vitamin D", Description = "Fortified milk and cereals, fatty fish")]
    VitaminD = 1 << 26, // 67108864

    [Display(ShortName = "Vitamin E", Name = "Vitamin E (Alpha-Tocopherol)", GroupName = "Vitamin E", Description = "vegetables oils, leafy green vegetables, whole grains, nuts")]
    VitaminE = 1 << 27, // 134217728

    [Display(ShortName = "Vitamin K", Name = "Vitamin K (Phylloquinone, Menadione)", GroupName = "Vitamin K", Description = "Cabbage, eggs, milk, spinach, broccoli, kale")]
    VitaminK = 1 << 28, // 268435456,

    // Major Minerals
    [Display(Name = "Calcium", GroupName = "Fruits and Vegatables", Description = "yogurt, cheese, milk, salmon, leafy green vegetables")]
    Calcium = 1 << 30, // 1073741824

    [Display(Name = "Chloride", GroupName = "Fruits and Vegetables", Description = "salt")]
    Chloride = 1 << 31, // 2147483648

    [Display(Name = "Magnesium", GroupName = "Unsaturated Fats and Cholesterol", Description = "Spinach, broccoli, legumes, seeds, whole-wheat bread")]
    Magnesium = 1 << 32, // 4294967296

    [Display(Name = "Potassium", GroupName = "Unsaturated Fats and Cholesterol", Description = "meat, milk, fruits, vegetables, grains, legumes")]
    Potassium = 1 << 33, // 8589934592

    [Display(Name = "Sodium", GroupName = "Dairy", Description = "salt, soy sauce, vegetables")]
    Sodium = 1 << 34, // 17179869184

    // Trace Minerals
    [Display(Name = "Chromium", GroupName = "Whole Grains", Description = "meat, poultry, fish, nuts, cheese")]
    Chromium = 1 << 35, // 34359738368

    [Display(Name = "Copper", GroupName = "Fish, Poultry, and Eggs", Description = "shellfish, nuts, seeds, whole-grain products, beans, prunes")]
    Copper = 1 << 36, // 68719476736

    [Display(Name = "Fluoride", GroupName = "Fish, Poultry, and Eggs", Description = "fish, teas")]
    Fluoride = 1L << 37, // 137438953472

    [Display(Name = "Iodine", GroupName = "Fish, Poultry, and Eggs", Description = "Iodized salt, seafood")]
    Iodine = 1L << 38, // 274877906944

    [Display(Name = "Iron", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "red meat, poultry, eggs, fruits, green vegetables, fortified bread")]
    Iron = 1L << 39, // 549755813888

    [Display(Name = "Manganese", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "nuts, legumes, whole grains, tea")]
    Manganese = 1L << 40, // 1099511627776

    [Display(Name = "Selenium", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "Organ meat, seafood, walnuts")]
    Selenium = 1L << 41, // 2199023255552

    [Display(Name = "Zinc", GroupName = "Nuts, Seeds, Beans, and Tofu", Description = "meat, shellfish, legumes, whole grains")]
    Zinc = 1L << 42, // 4398046511104,

    [Display(Name = "Molybdenum", GroupName = "", Description = "")]
    Molybdenum = 1L << 43, // 8796093022208,

    [Display(Name = "Phosphorus", GroupName = "", Description = "")]
    Phosphorus = 1L << 44, // 17592186044416,

    [Display(Name = "Sulfur", GroupName = "", Description = "")]
    Sulfur = 1L << 45, // 35184372088832,

    [Display(Name = "Boron", GroupName = "", Description = "")]
    Boron = 1L << 46, // 70368744177664,

    [Display(Name = "Vanadium", GroupName = "", Description = "")]
    Vanadium = 1L << 47, // 140737488355328,

    // Other Essential Nutrients
    [Display(Name = "Lithium", GroupName = "Lithium", Description = "Lithium")]
    Lithium = 1L << 50, // 1125899906842624,

    [Display(Name = "Choline", GroupName = "Choline", Description = "Choline")]
    Choline = 1L << 51, // 2251799813685248,

    All = Proteins | Starch | SolubleFiber | InsolubleFiber | Sugar | Oligosaccharides
        | MonounsaturatedFats | PolyunsaturatedFats | SaturatedFats | TransFats
        | HDLCholesterol | LDLCholesterol
        | VitaminARetinoids | VitaminACartenoids
        | B1 | B2 | B3 | B5 | B6 | B7 | B9 | B12
        | VitaminC | VitaminD | VitaminE | VitaminK
        | Calcium | Chloride | Magnesium | Potassium | Sodium
        | Chromium | Copper | Fluoride | Iodine | Iron | Manganese | Selenium | Zinc | Molybdenum | Phosphorus | Sulfur
        | Lithium | Choline
}
