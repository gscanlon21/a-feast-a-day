using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_ncbi_names_dmp
{
    public int? DTaxon { get; set; }
    public string? DTaxonName { get; set; }
}
