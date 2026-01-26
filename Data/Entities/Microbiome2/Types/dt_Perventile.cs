using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Perventile
{
    public double? Value { get; set; }
    public double? Percentile { get; set; }
    public string? Scope { get; set; }
}
