using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("sample_enzyme")]
public class Sample_Enzyme
{
    [Required]
    [Key, Column(Order = 0)]
    public int SampleId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public string ECKey { get; set; } = null!;

    [Required]
    public int Cnt { get; set; }

    public double? Percentile { get; set; }
}

