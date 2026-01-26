using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class GenusSignicant
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 3)]
    [Required]
    public string Direction { get; set; } = string.Empty;

    public decimal? HighValue { get; set; }

    public decimal? LowValue { get; set; }

    public double? Prevalence { get; set; }

    public double? Chi2 { get; set; }
}
