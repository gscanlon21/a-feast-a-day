using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.KEGG;

public class Kegg_Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Pid { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public int Enzymes { get; set; }

    public int? Species { get; set; }

    public string? Comment { get; set; }

    public double? NormalLow { get; set; }

    public double? NormalHigh { get; set; }

    // AS (('/Library/Bacteria?pid='+CONVERT([varchar](11),[pid]))+'&SampleId='),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? BacteriaUrl { get; set; }

    // AS ('/Library/Statistics?pid='+CONVERT([varchar](11),[Pid])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? StatisticsUrl { get; set; }

    // AS ('https://www.kegg.jp/dbget-bin/www_bfind_sub?mode=bfind&max_hit=1000&dbkey=kegg&keywords='+[ProductName]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; set; }

    // AS ([ProductName]+isnull([Comment],'')),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Product { get; set; }

    public string? Supplement { get; set; }
}
