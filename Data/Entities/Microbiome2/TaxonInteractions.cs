using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TaxonInteractions
{
    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int ImpactTaxon { get; set; }

    [Key, Column(Order = 2)]
    public int Direction { get; set; }
}

