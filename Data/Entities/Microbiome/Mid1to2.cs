using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Mid1to2
{
    [Key, Column(Order = 0)]
    [Required]
    public int Mid1 { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Mid2 { get; set; }

    public double? Direction { get; set; }
}

