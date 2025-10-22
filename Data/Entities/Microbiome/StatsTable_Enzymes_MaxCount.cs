using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class StatsTable_Enzymes_MaxCount
{
    [Key]
    [Required]
    public string Source { get; set; }

    public double? MaxCount { get; set; }
}
