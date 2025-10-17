using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("SpecialCitation")]
public class SpecialCitation
{
    [Key, Column(Order = 0)]
    [Required]
    public int SpecialId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }
}

