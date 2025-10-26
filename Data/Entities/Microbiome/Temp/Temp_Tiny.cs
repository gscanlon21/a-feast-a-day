using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Temp;

class Temp_Tiny
{
    [Key, Column(Order = 0)]
    [Required]
    public string Rank { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public double Amount { get; set; }
}

