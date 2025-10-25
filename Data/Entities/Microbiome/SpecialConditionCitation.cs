using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SpecialConditionCitation
{
    [Key, Column(Order = 0)]
    [Required]
    public int SCId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Mid2 { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int CID { get; set; }

    [Required]
    public bool Improves { get; set; }

    public string? Comment { get; set; }
}
