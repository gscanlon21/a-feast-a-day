using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("bacteria_2_bacteria")]
public class Bacteria2Bacteria
{
    [Required]
    [Key, Column(Order = 0)]
    public int TaxonA { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int TaxonB { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public string Source { get; set; } = string.Empty;

    [Required]
    public double Slope { get; set; }

    [Required]
    public double Intecept { get; set; }

    [Required]
    public double R2 { get; set; }

    [Required]
    public int Obs { get; set; }
}
