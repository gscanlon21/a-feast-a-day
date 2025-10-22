using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class Taxon_Signicant
{
    public string Source { get; set; }

    public int? Taxon { get; set; }

    public double? WithSymptoms { get; set; }

    public double? Below15 { get; set; }

    public double? Above85 { get; set; }

    [Required]
    public string Direction { get; set; }

    public double? Chi2 { get; set; }

}
