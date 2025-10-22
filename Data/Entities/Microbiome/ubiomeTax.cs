using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class ubiomeTax
{
    [Key, Required]
    public int Taxon { get; set; }

    public int? Parent { get; set; }

    [StringLength(200)]
    public string? TaxName { get; set; }

    [StringLength(20)]
    public string? TaxRank { get; set; }

    //  AS (('https://www.datapunk.net/substrata/display.pl?'+CONVERT([varchar](11),[taxon]))+'+S'),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? DatapunkUri { get; set; }

    // AS ('https://www.ncbi.nlm.nih.gov/genomes/GenomesGroup.cgi?taxid='+CONVERT([varchar](11),[taxon])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? GenomeUri { get; set; }

    public double? Significance { get; set; }
    public double? GutFrequency { get; set; }

    public string? AltName { get; set; }

    public double? MeanCount { get; set; }

    // AS ('/library/details?taxon='+CONVERT([varchar](11),[taxon])) PERSISTED,
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; set; }

    // AS ('/library/details?taxon='+CONVERT([varchar](11),[taxon])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? BacteriaUrl { get; set; }

    // AS ('/Library/Statistics?taxon='+CONVERT([varchar](11),[taxon])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? StatisticsUrl { get; set; }

    public double? KMLow { get; set; }
    public double? KMHigh { get; set; }

    [StringLength(50)]
    public string? Gram { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? NormalLow { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? NormalHigh { get; set; }

    public double? LabLow { get; set; }
    public double? LabHigh { get; set; }
    public double? BoxPlotLow { get; set; }
    public double? BoxPlotHigh { get; set; }
    public int? SampleCount { get; set; }
    public string? Description { get; set; }

    [Required]
    public bool OralBacteria { get; set; }

    public int? HighAssociationCnt { get; set; }
    public int? LowAssociationCnt { get; set; }
    public int? ImageNo { get; set; }

    //  AS ('http://www.ncbi.nlm.nih.gov/Taxonomy/taxi/images/'+CONVERT([varchar],[ImageNo])) PERSISTED,
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? ImageUrl { get; set; }

    public double? Persistent { get; set; }
    public string? RefChart { get; set; }
}

