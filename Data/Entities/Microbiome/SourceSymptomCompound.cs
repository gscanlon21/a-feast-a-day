using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SourceSymptomCompound
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int CPID { get; set; }

    public double? Chi2 { get; set; }

    public string Direction { get; set; }
}

