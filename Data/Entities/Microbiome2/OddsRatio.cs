using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class OddsRatio
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; } = null!;

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 3)]
    [Required]
    public string Direction { get; set; } = null!;

    [Required]
    public double Percentile { get; set; }
}

