using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class GenusSignicant_Gender
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Taxon { get; set; }

    [Required]
    public string Male { get; set; } = string.Empty;

    [Required]
    public string Female { get; set; } = string.Empty;

    public double? Male_Chi2 { get; set; }

    public double? FeMale_Chi2 { get; set; }
}
