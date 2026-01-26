using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_blog_analysis")]
public class dt_BlogAnalysis
{
    public int? Taxon { get; set; }

    public int? SymptomId { get; set; }

    public int? P05 { get; set; }

    public int? P01 { get; set; }

    public int? Direction { get; set; }

    public double? Threshold { get; set; }

    public double? Ratio { get; set; }

    public double? Prevalence { get; set; }
}
