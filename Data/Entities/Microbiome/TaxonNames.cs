using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TaxonNames
{
    [Required]
    [Key, Column(Order = 0)]
    public string TaxonName { get; set; } = null!;

    [Key, Column(Order = 1)]
    public int Taxon { get; set; }
}
