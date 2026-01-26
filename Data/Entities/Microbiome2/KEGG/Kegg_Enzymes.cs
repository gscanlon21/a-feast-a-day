using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.KEGG;

[Table("Kegg_Enzymes")]
public class KeggEnzyme
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EcId { get; set; }

    [Key]
    [Required]
    public string EcKey { get; set; } = string.Empty;

    public string? OtherName { get; set; }

    public string? EnzymeName { get; set; }

    [Required]
    public double Density { get; set; }

    // ('https://www.kegg.jp/entry/'+[ecKey]) PERSISTED NOT NULL,
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Required]
    public string Url { get; private set; } = string.Empty;

    public double? LowEdge { get; set; }

    public double? HighEdge { get; set; }

    // ('/Library/Bacteria?ecid='+CONVERT([varchar](11),[ecid])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? BacteriaUrl { get; private set; }

    // ('/Library/Statistics?ecid='+CONVERT([varchar](11),[ecid])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? StatisticsUrl { get; private set; }

    public double? NormalLow { get; set; }

    public double? NormalHigh { get; set; }

    public int? Species { get; set; }

    public string? Supplement { get; set; }

    public int? TaxonCount { get; set; }

    public string? HealthName { get; set; }

    public string? Description { get; set; }

    public string? Reaction { get; set; }

    public string? Comment { get; set; }
}
