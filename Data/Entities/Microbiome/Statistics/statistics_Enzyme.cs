using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Statistics;

[Table("statistics_enzyme")]
public class statistics_Enzyme
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public string ECKey { get; set; } = null!;

    public double? Mean { get; set; }

    public double? SD { get; set; }

    public double? BoxLow { get; set; }

    public double? BoxHigh { get; set; }

    public double? KMLow { get; set; }

    public double? KMHigh { get; set; }

    public double? Count { get; set; }

    public double? Median { get; set; }
}
