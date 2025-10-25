using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Mid2CytCitation
{
    [Key, Column(Order = 0)]
    [Required]
    public int Mid2 { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cyid { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Cid { get; set; }

    [Required]
    public int Change { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int RuleId { get; set; }
}
