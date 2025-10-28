using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Precision
{
    public int? Taxon { get; set; }
    public double? Percentage { get; set; }
    public double? Percentile { get; set; }
}
