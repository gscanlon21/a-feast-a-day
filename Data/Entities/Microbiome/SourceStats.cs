using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class SourceStats
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    [Required]
    public double Frequency { get; set; }

    [Required]
    public double Average { get; set; }
}
