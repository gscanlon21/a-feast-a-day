using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_Thorne")]
public class dt_Thorne
{
    public string? TKey { get; set; }
    public double? Abundance { get; set; }
    public double? Percentile { get; set; }
    public double? Per20 { get; set; }
    public double? Per80 { get; set; }
}
