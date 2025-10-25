using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TaxonInteractions
{
    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int ImpactTaxon { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Direction { get; set; }
}

