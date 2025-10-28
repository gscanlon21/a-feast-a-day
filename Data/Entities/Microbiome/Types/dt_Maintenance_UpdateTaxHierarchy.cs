using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Maintenance_UpdateTaxHierarchy
{
    [Key]
    public int Taxon { get; set; }
    public int? Parent { get; set; }
    public string? TaxRank { get; set; }
}

