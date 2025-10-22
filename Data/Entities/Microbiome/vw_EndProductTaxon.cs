using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class vw_EndProductTaxon
{
    [Required]
    public int Epid { get; set; }

    [Required]
    public int Taxon { get; set; }

    public double? Factor { get; set; }
}
