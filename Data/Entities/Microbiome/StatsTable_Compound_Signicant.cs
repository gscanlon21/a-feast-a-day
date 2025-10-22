using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class StatsTable_Compound_Signicant
{
    [Key, Column(Order = 0)]
    [Required]
    public int CPID { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public string Source { get; set; }

    public double? Below15 { get; set; }

    public double? Above15 { get; set; }

    public double? WithSymptoms { get; set; }

    public double? BelowChi2 { get; set; }

    public double? AboveChi2 { get; set; }
}
