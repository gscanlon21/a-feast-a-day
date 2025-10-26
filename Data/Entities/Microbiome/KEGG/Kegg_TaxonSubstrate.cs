using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.KEGG;

class Kegg_TaxonSubstrate
{
    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Substrate { get; set; }

    [Required]
    public double Cnt { get; set; }
}
