using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class vwRankName
{
    [Required]
    public string Rank { get; set; } = null!;

    [Required]
    public string TaxonName { get; set; } = null!;

    [Required]
    public int Taxon { get; set; }
}


