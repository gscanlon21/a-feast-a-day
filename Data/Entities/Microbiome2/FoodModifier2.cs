using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("FoodModifier2")]
public class FoodModifier2
{
    [Key, Column(Order = 0)]
    [Required]
    public string NDB_No { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int Mid2 { get; set; }
}

