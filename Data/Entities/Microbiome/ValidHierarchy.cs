using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class ValidHierarchy
{
    [Required]
    [StringLength(100)]
    public string TaxRank { get; set; }

    [Required]
    [StringLength(100)]
    public string ParentRank { get; set; }

    public int? Cnt { get; set; }
}

