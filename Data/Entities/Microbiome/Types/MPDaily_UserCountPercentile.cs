using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class MPDaily_UserCountPercentile
{
    public int Taxon { get; set; }
    public int CountNorm { get; set; }
    public double? Percentile { get; set; }
}
