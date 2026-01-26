using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class DT_Percent100
{
    public string? Key { get; set; }
    public double? Value { get; set; }
    public double? Percent { get; set; }
}

