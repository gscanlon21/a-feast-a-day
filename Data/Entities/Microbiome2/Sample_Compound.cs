using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Sample_Compound
{
    [Required]
    [Key, Column(Order = 0)]
    public int CPID { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Sampleid { get; set; }

    public double? Cnt { get; set; }
}
