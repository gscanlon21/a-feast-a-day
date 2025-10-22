using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class TaxonBiofilm
{
    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }
}


