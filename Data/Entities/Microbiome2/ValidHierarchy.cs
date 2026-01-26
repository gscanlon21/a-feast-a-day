using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("valid_hierarchy")]
public class ValidHierarchy
{
    [Required]
    public string TaxRank { get; set; } = null!;

    [Required]
    public string ParentRank { get; set; } = null!;

    public int? Cnt { get; set; }
}

