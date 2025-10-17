using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class Temp_TFull
{
    [Key]
    [Required]
    public string Domain { get; set; } = string.Empty;

    public string? Kingdom { get; set; }

    public string? Phylum { get; set; }

    public string? Class { get; set; }

    public string? Order { get; set; }

    public string? Family { get; set; }

    public string? Genus { get; set; }

    public string? Species { get; set; }

    public string? Serogroup { get; set; }

    public string? Serotype { get; set; }

    public string? Subspecies { get; set; }

    public string? Strain { get; set; }

    public string? Isolate { get; set; }

    public double? Abundance { get; set; }

    public double? P20 { get; set; }

    public double? P80 { get; set; }

    public double? Percentile { get; set; }

    public int? Taxon { get; set; }
}
