using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

// [EU].[Probiotics]
[Table("Probiotics", Schema = "EU")]
public class EU_Probiotic
{
    [Required]
    public string TaxName { get; set; } = string.Empty;

    public string? Strain { get; set; }

    [Required]
    public bool Veterinary { get; set; }

    public int? ProSpeciesId { get; set; }

    [Required]
    public bool Research { get; set; }

    public int? Mid2 { get; set; }
}
