using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_ncbi_taxidlineage_dmp")]
public class dt_ncbi_taxidlineage_dmp
{
    public int? D_Taxon { get; set; }
    public string? D_Hierarchy { get; set; }
}
