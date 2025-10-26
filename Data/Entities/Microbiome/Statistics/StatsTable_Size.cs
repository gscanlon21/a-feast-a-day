using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Statistics;

public class StatsTable_Size
{
    [Key]
    [Required]
    public string Source { get; set; }

    public int? Population { get; set; }
}
