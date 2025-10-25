using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Research_SymptomsChi
{
    [Key, Column(Order = 0)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public double? Weight { get; set; }

    public double? SympMean { get; set; }
}
