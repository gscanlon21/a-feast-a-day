using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class PreSymptoms
{
    [Key, Column(Order = 0)]
    [Required]
    public string Email { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }
}
