using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class DT_TaxonNames
{
    public int? Taxon { get; set; }
    public string? TaxonName { get; set; }
}
