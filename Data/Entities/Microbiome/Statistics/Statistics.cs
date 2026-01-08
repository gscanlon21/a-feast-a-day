using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Statistics;

public class Statistics
{
    [Key]
    [Required]
    public string StatsName { get; set; } = null!;

    [Required]
    public double Statistic { get; set; }
}
