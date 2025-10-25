using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class ConditionProbioticPubMed
{
    [Key, Column(Order = 0)]
    [Required]
    public int CondId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Psid { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Cid { get; set; }
}
