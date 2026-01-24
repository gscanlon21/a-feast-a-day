using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SymptomEquivalent
{
    [Required]
    [Key, Column(Order = 0)]
    public int SId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Sid2 { get; set; }
}

