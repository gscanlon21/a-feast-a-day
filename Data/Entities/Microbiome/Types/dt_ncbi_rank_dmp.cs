using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_ncbi_rank_dmp")]
public class dt_ncbi_rank_dmp
{
    public int? D_Taxon { get; set; }
    public int? D_ParentTaxon { get; set; }
    public string? D_Rank { get; set; }
}
