using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SymptomEquivalent
{
    [Key, Column(Order = 0)]
    [Required]
    public int SId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Sid2 { get; set; }
}

