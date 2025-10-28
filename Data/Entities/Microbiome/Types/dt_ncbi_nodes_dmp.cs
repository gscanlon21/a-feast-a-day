using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_ncbi_nodes_dmp
{
    public int? DTaxon { get; set; }
    public int? DParentTaxon { get; set; }
    public string? DRank { get; set; }
}

