using Core.Code.Attributes;
using Core.Models.Nutrients.SubNutrients;
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Nutrients : long
{
    None = 0,

    // Macronutrients

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(75, 225, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Order = 100, Name = "Proteins", GroupName = "Proteins")]
    Proteins = 1L << 0, // 1

    /// <summary>
    /// Does not include sugar alcohols.
    /// </summary>
    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(6, 12, Measure.Percent, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Order = 80, Name = "Sugar", GroupName = "Carbohydrates / Sugar", Description = "Monosaccharides: Glucose, Fructose; Disaccharides: Sucrose, Maltose, Lactose.")]
    Sugar = 1L << 1, // 2

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(1, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Name = "Oligosaccharides", GroupName = "Carbohydrates")]
    Oligosaccharides = 1L << 2, // 4

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(130, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Name = "Starch", GroupName = "Carbohydrates", Description = "Complex Sugars: Starch, Glycogen, Cellulose.")]
    Starch = 1L << 3, // 8

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(10, -1, Measure.Grams, Multiplier.Kilocalorie, CaloriesPerGram = 4)]
    [Display(Name = "Soluble Fiber", GroupName = "Carbohydrates / Fiber")]
    SolubleFiber = 1L << 4, // 16

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(15, -1, Measure.Grams, Multiplier.Kilocalorie, CaloriesPerGram = 4)]
    [Display(Name = "Insoluble Fiber", GroupName = "Carbohydrates / Fiber")]
    InsolubleFiber = 1L << 5, // 32

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(25, -1, Measure.Grams, Multiplier.Kilocalorie, CaloriesPerGram = 4)]
    [Display(Order = 90, Name = "Dietary Fiber", GroupName = "Carbohydrates / Fiber")]
    DietaryFiber = SolubleFiber | InsolubleFiber, // 48

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(300, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Order = 70, ShortName = "Carbs", Name = "Carbohydrates", GroupName = "Carbohydrates")]
    Carbohydrates = Sugar | Starch | DietaryFiber | InsolubleFiber | Oligosaccharides, // 62

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(250, -1, Measure.Grams, Multiplier.Person, CaloriesPerGram = 4)]
    [Display(Order = 70, ShortName = "Net Carbs", Name = "Net Carbohydrates", GroupName = "Carbohydrates")]
    NetCarbohydrates = Sugar | Starch | Oligosaccharides, // 14

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 1, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 44, Name = "Trans Fats", GroupName = "Fats")]
    TransFats = 1L << 6, // 64

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 20, Name = "Saturated Fats", GroupName = "Fats")]
    SaturatedFats = 1L << 7, // 128

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 30, Name = "Monounsaturated Fats", GroupName = "Fats / Unsaturated")]
    MonounsaturatedFats = 1L << 8, // 256

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Name = "Omega 3", GroupName = "Fats / Unsaturated / Polyunsaturated")]
    Omega3 = 1L << 9, // 512

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Name = "Omega 6", GroupName = "Fats / Unsaturated / Polyunsaturated")]
    Omega6 = 1L << 10, // 1024

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 10, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 40, Name = "Polyunsaturated Fats", GroupName = "Fats / Unsaturated / Polyunsaturated")]
    PolyunsaturatedFats = Omega3 | Omega6, // 1536

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(-1, 20, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 25, Name = "Unsaturated Fats", GroupName = "Fats / Unsaturated")]
    UnsaturatedFats = MonounsaturatedFats | PolyunsaturatedFats, // 1792

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(25, 35, Measure.Percent, Multiplier.Person, CaloriesPerGram = 9)]
    [Display(Order = 10, Name = "Fats", GroupName = "Fats")]
    Fats = UnsaturatedFats | SaturatedFats | TransFats, // 1920

    /// <summary>
    /// On the new nutrition facts label, the number of calories from fat has been removed entirely. 
    /// This is because research generally shows that the type of fat consumed may be more important than the amount. 
    /// The total amount of fat, as well as the grams of trans and saturated fats, are still listed on the updated label.
    /// </summary>
    [DefaultMeasure(Measure.None)]
    [DailyAllowance(1000, 1500, Measure.None, Multiplier.Kilocalorie)]
    [Display(Order = 0, Name = "Calories", GroupName = "Calories")]
    Calories = Proteins
        | Sugar | Oligosaccharides | Starch | SolubleFiber | InsolubleFiber
        | TransFats | SaturatedFats | MonounsaturatedFats | Omega3 | Omega6, // 2047

    /// <summary>
    /// The guideline changes are due to research showing that dietary cholesterol itself isn’t harmful and doesn't contribute to increases in your body’s blood cholesterol levels. 
    /// Cholesterol is a natural substance that’s produced in your body and is found in animal-based foods. It’s a waxy, fatty substance that travels through your bloodstream.
    /// But problems arise when you eat too many saturated and trans fats. These cause your liver to produce too much LDL (“bad”) cholesterol, which winds up in artery-clogging deposits. 
    /// For this reason, experts generally recommend avoiding trans fats altogether and limiting saturated fats to 10 percent or lessTrusted Source of your total calorie intake.
    /// 
    /// Dietary cholesterol is different from blood (HDL—good or LDL—bad) cholesterol.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(-1, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Order = 46, Name = "Dietary Cholesterol", GroupName = "Cholesterol")]
    DietaryCholesterol = 1L << 11, // 2048

    // Antioxidants

    /// <summary>
    /// Anti-oxidant plant compounds.
    /// Accounts for 60% of Polyphenols.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Flavanoids", GroupName = "Anti-oxidants")]
    Flavanoids = 1L << 12, // 4096

    /// <summary>
    /// Anti-oxidant plant compounds.
    /// Accounts for 30% of Polyphenols.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Phenolic Acids", GroupName = "Anti-oxidants")]
    NonFlavanoids = 1L << 13, // 8192

    /// <summary>
    /// Anti-oxidant plant compounds.
    /// https://www.researchgate.net/figure/Polyphenols-classification_fig1_360419454
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1, 10, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Polyphenols", GroupName = "Anti-oxidants", Description = "Flavonoids, Phenolic acids, Polyphenolic amides, Stilbenoids (Resveratrol).")]
    Polyphenols = Flavanoids | NonFlavanoids, // 12288

    /// <summary>
    /// Does not get converted into vitamin A.
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(10, 100, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Non-provitamin A Carotenoids", GroupName = "Anti-oxidants", Description = "Lycopene.")]
    NonProvitaminACarotenoids = 1L << 14, // 16384

    // Vitamins

    /// <summary>
    /// Precursors to vitamin A.
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(10, 100, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Alpha Carotene", GroupName = "Vitamins", Description = "24 mcg of alpha-carotene is 1 mcg of vitamin A.")]
    AlphaCarotene = 1L << 15, // 32768

    /// <summary>
    /// Precursors to vitamin A.
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(10, 100, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Beta Carotene", GroupName = "Vitamins", Description = "12 mcg of beta-carotene is 1 mcg of vitamin A.")]
    BetaCarotene = 1L << 16, // 65536

    /// <summary>
    /// Precursors to vitamin A.
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(10, 100, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Provitamin A Carotenoids", GroupName = "Vitamins", Description = "Alpha-carotene and beta-carotene.")]
    ProvitaminACarotenoids = AlphaCarotene | BetaCarotene, // 98304

    [SubNutrients<Carotenoids>]
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(10, 100, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Carotenoids", GroupName = "Vitamins")]
    Carotenoids = NonProvitaminACarotenoids | ProvitaminACarotenoids, // 114688

    /// <summary>
    /// Retinoids.
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(750, 3000, Measure.Micrograms, Multiplier.Person)]
    [Display(Name = "Retinol", GroupName = "Vitamins", Description = "1 mcg of retinol is 1 mcg of vitamin A.")]
    Retinol = 1L << 17, // 131072

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(750, 3000, Measure.Micrograms, Multiplier.Person)]
    [Display(Name = "Vitamin A", GroupName = "Vitamins")]
    VitaminA = Retinol | ProvitaminACarotenoids, // 229376

    /// <summary>
    /// Histamine liberator? Increases histamine blood levels by liberating histamine from mast cells.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1.2, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(1.4, -1, Measure.Milligrams, Multiplier.Person, For = Person.PregnantOrBreastfeedingWomen)]
    [Display(ShortName = "Vitamin B1", Name = "Vitamin B1 (Thiamine)", GroupName = "Vitamins")]
    VitaminB1 = 1L << 18, // 262144

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(1.1, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(1.4, -1, Measure.Milligrams, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(1.6, -1, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin B2", Name = "Vitamin B2 (Riboflavin)", GroupName = "Vitamins")]
    VitaminB2 = 1L << 19, // 524288

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(16, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(14, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(17, -1, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin B3", Name = "Vitamin B3 (Niacin)", GroupName = "Vitamins")]
    VitaminB3 = 1L << 20, // 1048576

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(6, -1, Measure.Milligrams, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(7, -1, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin B5", Name = "Vitamin B5 (Pantothenic Acid)", GroupName = "Vitamins")]
    VitaminB5 = 1L << 21, // 2097152

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1.3, -1, Measure.Milligrams, Multiplier.Person, For = Person.YoungAdult)]
    [DailyAllowance(1.5, -1, Measure.Milligrams, Multiplier.Person, For = Person.ElderlyWomen)]
    [DailyAllowance(1.7, -1, Measure.Milligrams, Multiplier.Person, For = Person.ElderlyMen)]
    [Display(ShortName = "Vitamin B6", Name = "Vitamin B6 (Pyridoxine)", GroupName = "Vitamins")]
    VitaminB6 = 1L << 22, // 4194304

    /// <summary>
    /// Using AI instead of RDA. RDA has not been established.
    /// 
    /// https://ods.od.nih.gov/factsheets/Biotin-HealthProfessional/
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(30, -1, Measure.Micrograms, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin B7", Name = "Vitamin B7 (Biotin)", GroupName = "Vitamins")]
    VitaminB7 = 1L << 23, // 8388608

    /// <summary>
    /// Folinic acid is the natural form.
    /// 
    /// The synthetic, folic, acid, can contribute 
    /// to folate deficiency and other adverse side effects!
    /// https://education.seekinghealth.com/folic-acid-side-effects/
    /// </summary>
    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(400, -1, Measure.Micrograms, Multiplier.Person, For = Person.YoungAdult)]
    [DailyAllowance(600, -1, Measure.Micrograms, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(500, -1, Measure.Micrograms, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin B9", Name = "Vitamin B9 (Folate)", GroupName = "Vitamins", Description = "Use the DFE (dietary folate equivalent) value.")]
    VitaminB9 = 1L << 24, // 16777216

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(2.4, -1, Measure.Micrograms, Multiplier.Person, For = Person.YoungAdult)]
    [Display(ShortName = "Vitamin B12", Name = "Vitamin B12 (Cobalamin)", GroupName = "Vitamins")]
    VitaminB12 = 1L << 25, // 33554432

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(90, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(75, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [Display(ShortName = "Vitamin C", Name = "Vitamin C (Ascorbic Acid)", GroupName = "Vitamins")]
    VitaminC = 1L << 26, // 67108864

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, For = Person.YoungAdult)]
    [DailyAllowance(25, 100, Measure.Micrograms, Multiplier.Person, For = Person.Elderly)]
    [Display(ShortName = "Vitamin D2", Name = "Vitamin D2 (Ergocalciferol)", GroupName = "Vitamins")]
    VitaminD2 = 1L << 27, // 134217728

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, For = Person.YoungAdult)]
    [DailyAllowance(25, 100, Measure.Micrograms, Multiplier.Person, For = Person.Elderly)]
    [Display(ShortName = "Vitamin D3", Name = "Vitamin D3 (Cholecalciferol)", GroupName = "Vitamins")]
    VitaminD3 = 1L << 28, // 268435456

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(20, 100, Measure.Micrograms, Multiplier.Person, For = Person.YoungAdult)]
    [DailyAllowance(25, 100, Measure.Micrograms, Multiplier.Person, For = Person.Elderly)]
    [Display(ShortName = "Vitamin D", Name = "Vitamin D (Calciferol)", GroupName = "Vitamins")]
    VitaminD = VitaminD2 | VitaminD3, // 402653184

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.Person, For = Person.Adult | Person.PregnantWomen)]
    [DailyAllowance(19, -1, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(ShortName = "Vitamin E", Name = "Vitamin E (Alpha-Tocopherol)", GroupName = "Vitamins")]
    VitaminE = 1L << 29, // 536870912

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, For = Person.Men)]
    [Display(ShortName = "Vitamin K1", Name = "Vitamin K1 (Phylloquinone)", GroupName = "Vitamins")]
    VitaminK1 = 1L << 30, // 1073741824

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, For = Person.Men)]
    [Display(ShortName = "Vitamin K2", Name = "Vitamin K2 (Menadione)", GroupName = "Vitamins")]
    VitaminK2 = 1L << 31, // 2147483648

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(90, -1, Measure.Micrograms, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(120, -1, Measure.Micrograms, Multiplier.Person, For = Person.Men)]
    [Display(ShortName = "Vitamin K", Name = "Vitamin K (Phylloquinone, Menadione)", GroupName = "Vitamins")]
    VitaminK = VitaminK1 | VitaminK2, // 3221225472

    // Major Minerals

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(750, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Calcium", GroupName = "Minerals")]
    Calcium = 1L << 32, // 4294967296

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(800, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Chloride", GroupName = "Minerals")]
    Chloride = 1L << 33, // 8589934592

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(400, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(350, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [Display(Name = "Magnesium", GroupName = "Minerals")]
    Magnesium = 1L << 34, // 17179869184

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(3500, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Order = 60, Name = "Potassium", GroupName = "Minerals")]
    Potassium = 1L << 35, //  34359738368

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(1500, 2300, Measure.Milligrams, Multiplier.Person)]
    [Display(Order = 50, Name = "Sodium", GroupName = "Minerals")]
    Sodium = 1L << 36, // 68719476736

    // Trace Minerals

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(35, -1, Measure.Micrograms, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(25, -1, Measure.Micrograms, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(40, -1, Measure.Micrograms, Multiplier.Person, For = Person.PregnantOrBreastfeedingWomen)]
    [Display(Name = "Chromium", GroupName = "Minerals")]
    Chromium = 1L << 37, // 137438953472

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(900, -1, Measure.Micrograms, Multiplier.Person)]
    [Display(Name = "Copper", GroupName = "Minerals")]
    Copper = 1L << 38, // 274877906944

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(2.5, 10, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Fluoride", GroupName = "Minerals")]
    Fluoride = 1L << 39, // 549755813888

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(150, -1, Measure.Micrograms, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(220, -1, Measure.Micrograms, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(290, -1, Measure.Micrograms, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(Name = "Iodine", GroupName = "Minerals")]
    Iodine = 1L << 40, // 1099511627776

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(18, 45, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(27, 45, Measure.Milligrams, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(9, 45, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [DailyAllowance(8, 45, Measure.Milligrams, Multiplier.Person, For = Person.ElderlyWomen)]
    [Display(Name = "Iron", GroupName = "Minerals")]
    Iron = 1L << 41, // 2199023255552

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(2.3, -1, Measure.Milligrams, Multiplier.Person, For = Person.Men)]
    [DailyAllowance(1.8, -1, Measure.Milligrams, Multiplier.Person, For = Person.Women)]
    [DailyAllowance(2.0, -1, Measure.Milligrams, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(2.6, -1, Measure.Milligrams, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(Name = "Manganese", GroupName = "Minerals")]
    Manganese = 1L << 42, // 4398046511104

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(55, 400, Measure.Micrograms, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(60, 400, Measure.Micrograms, Multiplier.Person, For = Person.PregnantWomen)]
    [DailyAllowance(70, 400, Measure.Micrograms, Multiplier.Person, For = Person.BreastfeedingWomen)]
    [Display(Name = "Selenium", GroupName = "Minerals")]
    Selenium = 1L << 43, // 8796093022208

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(12, -1, Measure.Milligrams, Multiplier.Person, For = Person.PregnantOrBreastfeedingWomen)]
    [Display(Name = "Zinc", GroupName = "Minerals")]
    Zinc = 1L << 44, // 17592186044416

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(45, -1, Measure.Micrograms, Multiplier.Person, For = Person.Adult)]
    [DailyAllowance(50, -1, Measure.Micrograms, Multiplier.Person, For = Person.PregnantOrBreastfeedingWomen)]
    [Display(Name = "Molybdenum", GroupName = "Minerals")]
    Molybdenum = 1L << 45, // 35184372088832

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(700, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Phosphorus", GroupName = "Minerals")]
    Phosphorus = 1L << 46, // 70368744177664

    /// <summary>
    /// Using AI instead of RDA. RDA has not been established.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(850, -1, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Sulfur", GroupName = "Minerals")]
    Sulfur = 1L << 47, // 140737488355328

    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(2, 20, Measure.Milligrams, Multiplier.Person)]
    [Display(Name = "Boron", GroupName = "Minerals")]
    Boron = 1L << 48, // 281474976710656

    [DefaultMeasure(Measure.Micrograms)]
    [DailyAllowance(20, 1000, Measure.Micrograms, Multiplier.Person)]
    [Display(Name = "Vanadium", GroupName = "Minerals")]
    Vanadium = 1L << 49, // 562949953421312

    // Other Essential Nutrients

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(1, 25, Measure.Grams, Multiplier.Person)]
    [Display(Order = 500, Name = "Lithium", GroupName = "Micronutrients")]
    Lithium = 1L << 50, // 1125899906842624 

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person)]
    [Display(Order = 510, Name = "Choline", GroupName = "Micronutrients")]
    Choline = 1L << 51, // 2251799813685248

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [DefaultMeasure(Measure.Milligrams)]
    [DailyAllowance(500, 3500, Measure.Milligrams, Multiplier.Person)]
    [Display(Order = 520, Name = "Betaine", GroupName = "Micronutrients")]
    Betaine = 1L << 52, // 4503599627370496  

    // Essential Amino Acids

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(11, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Teens)]
    [DailyAllowance(10, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Adult)]
    [Display(Name = "Histidine", GroupName = "Amino Acids / Essential")]
    Histidine = 1L << 53, // 9007199254740992

    /// <summary>
    /// Branched-chain amino-acid.
    /// </summary>
    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(19, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight)]
    [Display(Name = "Isoleucine", GroupName = "Amino Acids / Essential")]
    Isoleucine = 1L << 54, // 18014398509481984

    /// <summary>
    /// Branched-chain amino-acid.
    /// </summary>
    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(80, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Teens)]
    [DailyAllowance(120, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Adult)]
    [Display(Name = "Leucine", GroupName = "Amino Acids / Essential")]
    Leucine = 1L << 55, // 36028797018963968

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(38, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight)]
    [Display(Name = "Lysine", GroupName = "Amino Acids / Essential")]
    Lysine = 1L << 56, // 72057594037927936

    /// <summary>
    /// Methyl donor.
    /// </summary>
    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(14, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight)]
    [Display(Name = "Methionine", GroupName = "Amino Acids / Essential")]
    Methionine = 1L << 57, // 144115188075855872

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(33, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Adult)]
    [DailyAllowance(35, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.PregnantOrBreastfeedingWomen)]
    [Display(Name = "Phenylalanine", GroupName = "Amino Acids / Essential")]
    Phenylalanine = 1L << 58, // 288230376151711744

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(73, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight)]
    [Display(Name = "Threonine", GroupName = "Amino Acids / Essential")]
    Threonine = 1L << 59, // 576460752303423488

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(4, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Adult)]
    [DailyAllowance(5, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.PregnantWomen)]
    [DailyAllowance(7, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.BreastfeedingWomen)]
    [Display(Name = "Tryptophan", GroupName = "Amino Acids / Essential")]
    Tryptophan = 1L << 60, // 1152921504606846976

    /// <summary>
    /// Branched-chain amino-acid.
    /// </summary>
    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(15, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Adult)]
    [DailyAllowance(25, -1, Measure.Milligrams, Multiplier.KilogramOfBodyweight, For = Person.Teens)]
    [Display(Name = "Valine", GroupName = "Amino Acids / Essential")]
    Valine = 1L << 61, // 2305843009213693952

    // Semi-essential Amino Acids

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(6, 30, Measure.Grams, Multiplier.Person)]
    [Display(Name = "Arginine", GroupName = "Amino Acids / Semi-essential")]
    Arginine = 1L << 62, // 4611686018427387904

    [DefaultMeasure(Measure.Grams)]
    [DailyAllowance(.8, -1, Measure.Grams, Multiplier.KilogramOfBodyweight)]
    [Display(Name = "Glycine", GroupName = "Amino Acids / Nonessential")]
    Glycine = 1L << 63, // 9223372036854775808

    // Non-essential Amino Acids

    //[DefaultMeasure(Measure.Grams)]
    //[DailyAllowance(3, 5, Measure.Grams, Multiplier.Person)]
    //[Display(Name = "Creatine", GroupName = "Amino Acids / Nonessential")]
    //Creatine = 1L << 62, // 4611686018427387904,

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
        | MonounsaturatedFats | Omega3 | Omega6 | SaturatedFats | TransFats
        | DietaryCholesterol
        | Flavanoids | NonFlavanoids | NonProvitaminACarotenoids
        | AlphaCarotene | BetaCarotene | Retinol
        | VitaminB1 | VitaminB2 | VitaminB3 | VitaminB5 | VitaminB6 | VitaminB7 | VitaminB9 | VitaminB12
        | VitaminC | VitaminD2 | VitaminD3 | VitaminE | VitaminK1 | VitaminK2
        | Calcium | Chloride | Magnesium | Potassium | Sodium
        | Chromium | Copper | Fluoride | Iodine | Iron | Manganese | Selenium | Zinc | Molybdenum | Phosphorus | Sulfur | Boron | Vanadium
        | Choline | Betaine | Lithium
        | Histidine | Isoleucine | Leucine | Lysine | Methionine | Phenylalanine | Threonine | Tryptophan | Valine
        | Arginine | Glycine
}
