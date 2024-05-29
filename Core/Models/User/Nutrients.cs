using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Nutrients : long
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
    [Display(Name = "Vitamin A (Retinoids)", GroupName = "Vitamins")]
    VitaminARetinoids = 1 << 15, // 32768

    [Display(Name = "Vitamin A (Carotenoids)", GroupName = "Vitamins")]
    VitaminACartenoids = 1 << 16, // 65536

    [Display(ShortName = "Vitamin A", Name = "Vitamin A (Retinoids and Carotenoids)", GroupName = "Vitamins")]
    VitaminA = VitaminARetinoids | VitaminACartenoids, // 98304

    [Display(ShortName = "Vitamin B1", Name = "Vitamin B1 (Thiamine)", GroupName = "Vitamins")]
    VitaminB1 = 1 << 17, // 131072

    [Display(ShortName = "Vitamin B2", Name = "Vitamin B2 (Riboflavin)", GroupName = "Vitamins")]
    VitaminB2 = 1 << 18, // 262144

    [Display(ShortName = "Vitamin B3", Name = "Vitamin B3 (Niacin)", GroupName = "Vitamins")]
    VitaminB3 = 1 << 19, // 524288

    [Display(ShortName = "Vitamin B5", Name = "Vitamin B5 (Pantothenic Acid)", GroupName = "Vitamins")]
    VitaminB5 = 1 << 20, // 1048576

    [Display(ShortName = "Vitamin B6", Name = "Vitamin B6 (Pyridoxine)", GroupName = "Vitamins")]
    VitaminB6 = 1 << 21, // 2097152

    [Display(ShortName = "Vitamin B7", Name = "Vitamin B7 (Biotin)", GroupName = "Vitamins")]
    VitaminB7 = 1 << 22, // 4194304

    /// <summary>
    /// NOT folic acid: we are not tracking the artificial version of folate 
    /// because it is not well utilized by the body. It can even contribute 
    /// to folate deficiency and other adverse side effects!
    /// https://education.seekinghealth.com/folic-acid-side-effects/
    /// </summary>
    [Display(ShortName = "Vitamin B9", Name = "Vitamin B9 (Folinic Acid)", GroupName = "Vitamins")]
    VitaminB9 = 1 << 23, // 8388608

    [Display(ShortName = "Vitamin B12", Name = "Vitamin B12 (Cobalamin)", GroupName = "Vitamins")]
    VitaminB12 = 1 << 24, // 16777216

    [Display(ShortName = "Vitamin C", Name = "Vitamin C (Ascorbic Acid)", GroupName = "Vitamins")]
    VitaminC = 1 << 25, // 33554432

    [Display(ShortName = "Vitamin D", Name = "Vitamin D (Calciferol)", GroupName = "Vitamins")]
    VitaminD = 1 << 26, // 67108864

    [Display(ShortName = "Vitamin E", Name = "Vitamin E (Alpha-Tocopherol)", GroupName = "Vitamins")]
    VitaminE = 1 << 27, // 134217728

    [Display(ShortName = "Vitamin K", Name = "Vitamin K (Phylloquinone, Menadione)", GroupName = "Vitamins")]
    VitaminK = 1 << 28, // 268435456,

    // Major Minerals
    [Display(Name = "Calcium", GroupName = "Minerals")]
    Calcium = 1L << 30, // 1073741824

    [Display(Name = "Chloride", GroupName = "Minerals")]
    Chloride = 1L << 31, // 2147483648

    [Display(Name = "Magnesium", GroupName = "Minerals")]
    Magnesium = 1L << 32, // 4294967296

    [Display(Name = "Potassium", GroupName = "Minerals")]
    Potassium = 1L << 33, // 8589934592

    [Display(Name = "Sodium", GroupName = "Minerals")]
    Sodium = 1L << 34, // 17179869184

    // Trace Minerals
    [Display(Name = "Chromium", GroupName = "Minerals")]
    Chromium = 1L << 35, // 34359738368

    [Display(Name = "Copper", GroupName = "Minerals")]
    Copper = 1L << 36, // 68719476736

    [Display(Name = "Fluoride", GroupName = "Minerals")]
    Fluoride = 1L << 37, // 137438953472

    [Display(Name = "Iodine", GroupName = "Minerals")]
    Iodine = 1L << 38, // 274877906944

    [Display(Name = "Iron", GroupName = "Minerals")]
    Iron = 1L << 39, // 549755813888

    [Display(Name = "Manganese", GroupName = "Minerals")]
    Manganese = 1L << 40, // 1099511627776

    [Display(Name = "Selenium", GroupName = "Minerals")]
    Selenium = 1L << 41, // 2199023255552

    [Display(Name = "Zinc", GroupName = "Minerals")]
    Zinc = 1L << 42, // 4398046511104,

    [Display(Name = "Molybdenum", GroupName = "Minerals")]
    Molybdenum = 1L << 43, // 8796093022208,

    [Display(Name = "Phosphorus", GroupName = "Minerals")]
    Phosphorus = 1L << 44, // 17592186044416,

    [Display(Name = "Sulfur", GroupName = "Minerals")]
    Sulfur = 1L << 45, // 35184372088832,

    [Display(Name = "Boron", GroupName = "Minerals")]
    Boron = 1L << 46, // 70368744177664,

    [Display(Name = "Vanadium", GroupName = "Minerals")]
    Vanadium = 1L << 47, // 140737488355328,

    // Other Essential Nutrients
    [Display(Name = "Lithium", GroupName = "Micronutrients")]
    Lithium = 1L << 50, // 1125899906842624,

    [Display(Name = "Choline", GroupName = "Micronutrients")]
    Choline = 1L << 51, // 2251799813685248,

    All = Proteins | Starch | SolubleFiber | InsolubleFiber | Sugar | Oligosaccharides
        | MonounsaturatedFats | PolyunsaturatedFats | SaturatedFats | TransFats
        | HDLCholesterol | LDLCholesterol
        | VitaminARetinoids | VitaminACartenoids
        | VitaminB1 | VitaminB2 | VitaminB3 | VitaminB5 | VitaminB6 | VitaminB7 | VitaminB9 | VitaminB12
        | VitaminC | VitaminD | VitaminE | VitaminK
        | Calcium | Chloride | Magnesium | Potassium | Sodium
        | Chromium | Copper | Fluoride | Iodine | Iron | Manganese | Selenium | Zinc | Molybdenum | Phosphorus | Sulfur | Boron | Vanadium
        | Lithium | Choline
}
