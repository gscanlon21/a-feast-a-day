using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Condition_Modifier
{
    [Key, Column(Order = 0)]
    [Required]
    public int CondId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Mid2 { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Cid { get; set; }

    [Required]
    public int Impact { get; set; }
}

