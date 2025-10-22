using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("ncbi_taxidlineage_dmp")]
class taxidlineage_dmp
{
    [Key]
    [Required]
    public int D_Taxon { get; set; }

    public string D_Hierarchy { get; set; }
}
