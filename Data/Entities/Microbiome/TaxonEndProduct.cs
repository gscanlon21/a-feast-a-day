using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class TaxonEndProduct
{
    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int EPID { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int CID { get; set; }

    [Required]
    public double Factor { get; set; }

    [Required]
    public string Logic { get; set; }
}
