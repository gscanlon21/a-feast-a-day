using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

[Table("statistics_substrate")]
public class statistics_Substrate
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int Substrate { get; set; }

    public double? Mean { get; set; }

    public double? SD { get; set; }

    public double? BoxLow { get; set; }

    public double? BoxHigh { get; set; }

    public double? KMLow { get; set; }

    public double? KMHigh { get; set; }

    public double? Count { get; set; }

    public double? Median { get; set; }
}

