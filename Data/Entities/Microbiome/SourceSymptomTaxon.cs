using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SourceSymptomTaxon
{
    [Required]
    [Key, Column(Order = 0)]
    public string Source { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int SymptomId { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public int Taxon { get; set; }

    public double? Chi2 { get; set; }

    public string Direction { get; set; } = null!;
}

