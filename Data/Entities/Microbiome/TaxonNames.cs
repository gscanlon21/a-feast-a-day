using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class TaxonNames
{
    [Key, Column(Order = 0)]
    [Required]
    public string TaxonName { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }
}
