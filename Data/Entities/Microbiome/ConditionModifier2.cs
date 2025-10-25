using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class ConditionModifier2
{
    [Key, Column(Order = 0)]
    [Required]
    public string ConditionCode { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Mid2 { get; set; }

    [Required]
    public string Impact { get; set; } = string.Empty;

    [Required]
    public string Comment { get; set; } = string.Empty;
}
