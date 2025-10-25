using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class Statistics
{
    [Key]
    [Required]
    public string StatsName { get; set; }

    [Required]
    public double Statistic { get; set; }
}
