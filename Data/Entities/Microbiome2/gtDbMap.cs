using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class gtDbMap
{
    [Key, Required]
    public string NcbiName { get; set; } = string.Empty;

    public string? GtdbNames { get; set; }

    public int? Taxon { get; set; }

    public string? Rank { get; set; }
}
