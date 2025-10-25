using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class StatsTable_Taxon_MaxCount
{
    [Key]
    [Required]
    public string Source { get; set; }

    public double? MaxCount { get; set; }
}
