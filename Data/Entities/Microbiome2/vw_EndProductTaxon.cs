using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class vw_EndProductTaxon
{
    [Required]
    public int Epid { get; set; }

    [Required]
    public int Taxon { get; set; }

    public double? Factor { get; set; }
}
