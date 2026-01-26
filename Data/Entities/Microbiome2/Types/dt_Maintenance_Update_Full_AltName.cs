using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Maintenance_Update_Full_AltName
{
    public int? Taxon { get; set; }
    public string? TaxonName { get; set; }
}

