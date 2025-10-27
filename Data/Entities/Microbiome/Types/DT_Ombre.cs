using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class DT_Ombre
{
    public int? Taxon { get; set; }
    public double? Percentile { get; set; }
}

