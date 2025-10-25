using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Health_Conditions
{
    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public string Direction { get; set; } = string.Empty;
}
