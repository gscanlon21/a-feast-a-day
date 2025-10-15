using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("Bacteria2Bacteria")]
class Bacteria2Bacteria
{
    [Key, Column(Order = 0)]
    [Required]
    public int TaxonA { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int TaxonB { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public string Source { get; set; } = string.Empty;

    [Required]
    public double Slope { get; set; }

    [Required]
    public double Intecept { get; set; }  // Preserves the SQL spelling

    [Required]
    public double R2 { get; set; }

    [Required]
    public int Obs { get; set; }
}
