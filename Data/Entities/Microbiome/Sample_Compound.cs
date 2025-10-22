using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Sample_Compound
{
    [Key, Column(Order = 0)]
    [Required]
    public int CPID { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Sampleid { get; set; }

    public double? Cnt { get; set; }
}
