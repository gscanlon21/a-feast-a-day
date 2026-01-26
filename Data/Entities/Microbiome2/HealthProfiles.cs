using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class HealthProfiles
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = string.Empty;

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    public double LowValue { get; set; }

    [Required]
    public double HighValue { get; set; }
}
