using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class Sample_IndexRatios
{
    [Required]
    [Key, Column(Order = 0)]
    public int SequenceId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public string IndexName { get; set; } = null!;

    public double? AValue { get; set; }

    public decimal? Percentile { get; set; }
}

