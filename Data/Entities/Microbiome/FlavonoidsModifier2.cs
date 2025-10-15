using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("FlavonoidsModifier2")]
public class FlavonoidsModifier2
{
    [Key, Column(Order = 0)]
    [Required]
    public string FId { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int Mid2 { get; set; }
}
