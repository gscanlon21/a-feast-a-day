using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class JasonH
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    public double LowValue { get; set; }

    [Required]
    public double HighValue { get; set; }

    public double? LowPCile { get; set; }

    public double? HighPCile { get; set; }
}
