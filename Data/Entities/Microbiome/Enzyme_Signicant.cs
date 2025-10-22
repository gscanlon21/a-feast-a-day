using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

class Enzyme_Signicant
{
    public string? Source { get; set; }

    public string? ECKey { get; set; }

    public double? WithSymptoms { get; set; }

    public double? Below15 { get; set; }

    public double? Above85 { get; set; }

    [Required]
    public string Direction { get; set; } = string.Empty;

    public double? Chi2 { get; set; }
}
