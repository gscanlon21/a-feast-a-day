using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Research_SymptomsChi
{
    [Required]
    [Key, Column(Order = 0)]
    public int SymptomId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    public double? Weight { get; set; }

    public double? SympMean { get; set; }
}
