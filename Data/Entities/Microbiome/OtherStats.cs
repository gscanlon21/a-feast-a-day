using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class OtherStats
{
    [Key, Required]
    public string StatsName { get; set; }

    [Required]
    public double Count { get; set; }
}

