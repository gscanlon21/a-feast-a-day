using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class DT_Percentile
{
    public int? Id { get; set; }
    public string? Dist { get; set; }
    public double? NormalLow { get; set; }
    public double? NormalHigh { get; set; }
}

