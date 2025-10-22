using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class vwRankName
{
    [Required]
    public string Rank { get; set; }

    [Required]
    public string TaxonName { get; set; }

    [Required]
    public int Taxon { get; set; }
}


