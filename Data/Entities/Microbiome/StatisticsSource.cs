using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("statistics_source")]
class StatisticsSource
{
    public string Source { get; set; } = string.Empty;
    public double? Total { get; set; }
}
