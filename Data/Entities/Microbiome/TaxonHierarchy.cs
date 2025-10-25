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
    public string Rank { get; set; }

    public string Hierarchy { get; set; }

    public string TaxonName { get; set; }

    public int? ImageNo { get; set; }
}
