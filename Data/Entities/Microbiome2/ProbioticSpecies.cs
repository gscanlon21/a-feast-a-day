using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("probiotic_species")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticSpecies
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProSpeciesId { get; set; }

    [Required]
    public string SpeciesName { get; set; } = string.Empty;

    [Required]
    public int Mid2 { get; set; }

    [Required]
    public bool Persists { get; set; }

    [Required]
    public bool NotHistamineProducer { get; set; }

    [Required]
    public bool HistamineProducer { get; set; }

    public bool? LacticAcidProducer { get; set; }

    public bool? DLacticAcid { get; set; }

    public bool? LLacticAcid { get; set; }

    public bool? BalancedLacticAcid { get; set; }

    public bool? Bacteremia { get; set; }

    public int? Taxon { get; set; }

    public bool? GABA { get; set; }

    public string? Features { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
