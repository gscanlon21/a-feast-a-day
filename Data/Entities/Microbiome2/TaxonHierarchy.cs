using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class _TaxonHierarchy_
{
    [Key]
    [Required]
    public int Taxon { get; set; }

    [Required]
    public int ParentTaxon { get; set; }

    [Required]
    public string Rank { get; set; } = null!;

    public string Hierarchy { get; set; } = null!;

    public string TaxonName { get; set; } = null!;

    public int? ImageNo { get; set; }
}
