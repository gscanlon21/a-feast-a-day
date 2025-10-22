using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("statistics_taxon")]
class statistics_Taxon
{
    [Key, Column(Order = 0)]
    [Required]
    public string Source { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public double? Mean { get; set; }

    public double? SD { get; set; }

    public double? BoxLow { get; set; }

    public double? BoxHigh { get; set; }

    public double? KMLow { get; set; }

    public double? KMHigh { get; set; }

    public double? Count { get; set; }

    public double? Median { get; set; }
}
