using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class PreSymptoms
{
    [Key, Column(Order = 0)]
    [Required]
    public string Email { get; set; } = null!;

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }
}
