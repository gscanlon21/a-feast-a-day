using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_PartnerSample
{
    public int? Taxon { get; set; }
    public double? CountNorm { get; set; }
}

