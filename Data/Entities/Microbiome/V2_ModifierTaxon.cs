using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class V2_ModifierTaxon
{
    [Required]
    public int Mid2 { get; set; }

    [Required]
    public int Taxon { get; set; }

    public double? TaxonImpact { get; set; }

    public double? Median { get; set; }
}

