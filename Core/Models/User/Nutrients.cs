using Core.Code.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Nutrients : long
{
    None = 0,

    // Macronutrients

    [DailyAllowance(75, 225, Measure.Grams)]
    [Display(Name = "Proteins", GroupName = "Proteins")]
    Proteins = 1 << 0, // 1

    [Display(Name = "Starch", GroupName = "Carbohydrates")]
    Starch = 1 << 1, // 2

    [Display(Name = "Soluble Fiber", GroupName = "Carbohydrates / Fiber")]
    SolubleFiber = 1 << 2, // 4

    [Display(Name = "Insoluble Fiber", GroupName = "Carbohydrates / Fiber")]
    InsolubleFiber = 1 << 3, // 8

    [Display(Name = "Dietary Fiber", GroupName = "Carbohydrates / Fiber")]
    DietaryFiber = SolubleFiber | InsolubleFiber, // 12

    [Display(Name = "Sugar", GroupName = "Carbohydrates")]
    Sugar = 1 << 4, // 16

    [Display(Name = "Oligosaccharides", GroupName = "Carbohydrates")]
    Oligosaccharides = 1 << 5, // 32

    [DailyAllowance(150, 0, Measure.Grams)]
    [Display(ShortName = "Carbs", Name = "Carbohydrates", GroupName = "Carbohydrates")]
    Carbohydrates = Starch | DietaryFiber | Sugar | Oligosaccharides, // 62

    [Display(Name = "Monounsaturated Fats", GroupName = "Fats / Unsaturated")]
    MonounsaturatedFats = 1 << 6, // 64

    [Display(Name = "Polyunsaturated Fats", GroupName = "Fats / Unsaturated")]
    PolyunsaturatedFats = 1 << 7, // 128

    [Display(Name = "Unsaturated Fats", GroupName = "Fats / Unsaturated")]
    UnsaturatedFats = MonounsaturatedFats | PolyunsaturatedFats, // 192

    [Display(Name = "Saturated Fats", GroupName = "Fats")]
    SaturatedFats = 1 << 8, // 256

    [Display(Name = "Trans Fats", GroupName = "Fats")]
    TransFats = 1 << 9, // 512

    [Display(Name = "Fats", GroupName = "Fats")]
    Fats = UnsaturatedFats | SaturatedFats | TransFats, // 960

    /// <summary>
    /// The guideline changes are due to research showing that dietary cholesterol itself isn’t harmful and doesn’t contribute to increases in your body’s blood cholesterol levels. 
    /// Cholesterol is a natural substance that’s produced in your body and is found in animal-based foods. It’s a waxy, fatty substance that travels through your bloodstream.
    /// But problems arise when you eat too many saturated and trans fats. These cause your liver to produce too much LDL (“bad”) cholesterol, which winds up in artery-clogging deposits. 
    /// For this reason, experts generally recommend avoiding trans fats altogether and limiting saturated fats to 10 percent or lessTrusted Source of your total calorie intake.
    /// 
    /// Dietary cholesterol is different from blood (HDL—good or LDL—bad) cholesterol.
    /// </summary>
    [DailyAllowance(0, 250, Measure.Milligrams)]
    [Display(Name = "Dietary Cholesterol", GroupName = "Cholesterol")]
    DietaryCholesterol = 1 << 10, // 1024

    // Vitamins

    [Display(Name = "Vitamin A (Retinoids)", GroupName = "Vitamins")]
    VitaminARetinoids = 1 << 15, // 32768

    /// <summary>
    /// Alpha carotene or Beta carotene.
    /// </summary>
    [Display(Name = "Vitamin A (Carotenoids)", GroupName = "Vitamins")]
    VitaminACartenoids = 1 << 16, // 65536

    [Display(ShortName = "Vitamin A", Name = "Vitamin A (Retinoids and Carotenoids)", GroupName = "Vitamins")]
    VitaminA = VitaminARetinoids | VitaminACartenoids, // 98304

    /// <summary>
    /// Histamine liberator? Increases histamine blood levels by liberating histamine from mast cells.
    /// </summary>
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

    [DailyAllowance(2.5, 10, Measure.Milligrams)]
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

    [DailyAllowance(1, 20, Measure.Grams)]
    [Display(Name = "Sulfur", GroupName = "Minerals")]
    Sulfur = 1L << 45, // 35184372088832,

    [DailyAllowance(2, 20, Measure.Milligrams)]
    [Display(Name = "Boron", GroupName = "Minerals")]
    Boron = 1L << 46, // 70368744177664,

    [DailyAllowance(20, 1000, Measure.Micrograms)]
    [Display(Name = "Vanadium", GroupName = "Minerals")]
    Vanadium = 1L << 47, // 140737488355328,

    // Other Essential Nutrients

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [DailyAllowance(500, 3500, Measure.Milligrams)]
    [Display(Name = "Choline", GroupName = "Micronutrients")]
    Choline = 1L << 48, // 281474976710656,

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [Display(Name = "Betaine", GroupName = "Micronutrients")]
    Betaine = 1L << 49, // 562949953421312, ,

    [DailyAllowance(1, 25, Measure.Grams)]
    [Display(Name = "Lithium", GroupName = "Micronutrients")]
    Lithium = 1L << 50, // 1125899906842624,



    

    // Essential Amino Acids
    [Display(Name = "Histidine", GroupName = "Amino Acids / Essential")]
    Histidine = 1L << 51, // 2251799813685248,

    [Display(Name = "Isoleucine", GroupName = "Amino Acids / Essential")]
    Isoleucine = 1L << 52, // 4503599627370496,

    [Display(Name = "Leucine", GroupName = "Amino Acids / Essential")]
    Leucine = 1L << 53, // 9007199254740992,

    [Display(Name = "Lysine", GroupName = "Amino Acids / Essential")]
    Lysine = 1L << 54, // 18014398509481984,

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [Display(Name = "Methionine", GroupName = "Amino Acids / Essential")]
    Methionine = 1L << 55, // 36028797018963968,

    [Display(Name = "Phenylalanine", GroupName = "Amino Acids / Essential")]
    Phenylalanine = 1L << 56, // 72057594037927936,

    [Display(Name = "Threonine", GroupName = "Amino Acids / Essential")]
    Threonine = 1L << 57, // 144115188075855872,

    [Display(Name = "Tryptophan", GroupName = "Amino Acids / Essential")]
    Tryptophan = 1L << 58, // 288230376151711744,

    [Display(Name = "Valine", GroupName = "Amino Acids / Essential")]
    Valine = 1L << 59, // 576460752303423488,

    // Semi-essential Amino Acids

    [Display(Name = "Arginine", GroupName = "Amino Acids / Semiessential")]
    Arginine = 1L << 60, // 1152921504606846976,

    // Non-essential Amino Acids

    [Display(Name = "Glycine", GroupName = "Amino Acids / Nonessential")]
    Glycine = 1L << 61, // 2305843009213693952,

    [Display(Name = "Creatine", GroupName = "Amino Acids / Nonessential")]
    Creatine = 1L << 62, // 4611686018427387904,

    //[Display(Name = "Alanine", GroupName = "Micronutrients")]
    //Alanine = 1L << 12, // 2251799813685248,

    //[Display(Name = "Aspartic acid", GroupName = "Micronutrients")]
    //AsparticAcid = 1L << 14, // 2251799813685248,

    //[Display(Name = "Cystine", GroupName = "Micronutrients")]
    //Cystine = 1L << 29, // 2251799813685248,

    //[Display(Name = "Glutamic acid", GroupName = "Micronutrients")]
    //GlutamicAcid = 1L << 48, // 2251799813685248,

    //[Display(Name = "Hydroxyproline", GroupName = "Micronutrients")]
    //Hydroxyproline = 1L << 53, // 2251799813685248,

    //[Display(Name = "Proline", GroupName = "Micronutrients")]
    //Proline = 1L << 59, // 2251799813685248,

    //[Display(Name = "Serine", GroupName = "Micronutrients")]
    //Serine = 1L << 60, // 2251799813685248,

    //[Display(Name = "Tyrosine", GroupName = "Micronutrients")]
    //Tyrosine = 1L << 63, // 2251799813685248,


    All = Proteins | Starch | SolubleFiber | InsolubleFiber | Sugar | Oligosaccharides
        | MonounsaturatedFats | PolyunsaturatedFats | SaturatedFats | TransFats
        | DietaryCholesterol
        | VitaminARetinoids | VitaminACartenoids
        | VitaminB1 | VitaminB2 | VitaminB3 | VitaminB5 | VitaminB6 | VitaminB7 | VitaminB9 | VitaminB12
        | VitaminC | VitaminD | VitaminE | VitaminK
        | Calcium | Chloride | Magnesium | Potassium | Sodium
        | Chromium | Copper | Fluoride | Iodine | Iron | Manganese | Selenium | Zinc | Molybdenum | Phosphorus | Sulfur | Boron | Vanadium
        | Choline | Betaine | Lithium
        | Histidine | Isoleucine | Leucine | Lysine | Methionine | Phenylalanine | Threonine | Tryptophan | Valine
        | Arginine | Glycine | Creatine
}
