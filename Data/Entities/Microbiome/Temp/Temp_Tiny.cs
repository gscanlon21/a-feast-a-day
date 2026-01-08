using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Temp;

public class Temp_Tiny
{
    [Required]
    [Key, Column(Order = 0)]
    public string Rank { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public double Amount { get; set; }
}

