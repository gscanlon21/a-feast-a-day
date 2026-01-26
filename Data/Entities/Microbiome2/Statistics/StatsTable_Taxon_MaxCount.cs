using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Statistics;

public class StatsTable_Taxon_MaxCount
{
    [Key]
    [Required]
    public string Source { get; set; } = null!;

    public double? MaxCount { get; set; }
}
