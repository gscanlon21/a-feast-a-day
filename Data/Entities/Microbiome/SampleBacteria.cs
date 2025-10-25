using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SampleBacteria
{
    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public DateTime AsOf { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Taxon { get; set; }

    public double? SHift { get; set; }
}

