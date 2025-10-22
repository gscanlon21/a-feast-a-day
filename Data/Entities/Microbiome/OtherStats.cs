using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class OtherStats
{
    [Key, Required]
    public string StatsName { get; set; }

    [Required]
    public double Count { get; set; }
}

