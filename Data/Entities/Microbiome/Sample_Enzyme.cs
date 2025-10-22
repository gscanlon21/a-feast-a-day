using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class Sample_Enzyme
{
    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    [StringLength(20)]
    public string ECKey { get; set; }

    [Required]
    public int Cnt { get; set; }

    public double? Percentile { get; set; }
}

