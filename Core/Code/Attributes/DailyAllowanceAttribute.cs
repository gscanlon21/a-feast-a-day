using Core.Models.User;

namespace Core.Code.Attributes;

/// <summary>
/// Recommended Daily Allowance.
/// 
/// Dietary Reference Intakes: A Brief Overview
/// The most recent recommendations from the Food and Nutrition Board are the Dietary Reference Intakes(DRIs). The DRIs include 5 categories of values for micronutrients:
/// 
/// Estimated Average Requirement(EAR): 
///     Expected to satisfy the needs of 50% of the people in that age group based on a review of the scientific literature.
/// Recommended Dietary Allowance(RDA): 
///     Average daily level of intake sufficient to meet the nutrient requirements of nearly all(97%-98%) healthy people.
/// Adequate Intake (AI): 
///     Established when evidence is insufficient to develop an RDA and is set at a level assumed to ensure nutritional adequacy.
/// Tolerable Upper Intake Level (UL): 
///     Maximum daily intake unlikely to cause adverse health effects.
/// Chronic Disease Risk Reduction Intake (CDRR): 
///     Level above which intake reduction is expected to reduce chronic disease risk within an apparently healthy population.
///     The DRIs are not minimum or maximum nutritional requirements and are not intended to fit everybody. They are to be used as guides only for the majority of the healthy population. 
///     DRIs do not apply to people with diseases or those suffering from nutrient deficiencies. The Food and Nutrition Board of the Institute of Medicine, 
///     National Academy of Sciences issues updated reports on DRIs when scientific evidence warrants an update. For example, the DRIs for sodium and potassium were updated in 2019.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
public class DailyAllowanceAttribute(double rda, double tul, Measure measure, Multiplier multiplier)
    : Attribute
{
    public Person For { get; set; } = Person.All;
    public Multiplier Multiplier { get; set; } = multiplier;
    public Measure Measure { get; set; } = measure;
    public double InternalRDA { private get; set; } = rda;
    public double InternalTUL { private get; set; } = tul;
    public double? RDA => InternalRDA >= 0 ? InternalRDA : null;
    public double? TUL => InternalTUL >= 0 ? InternalTUL : null;
}
