using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("probiotic_mixture")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticMixture
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public int ProId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int ProSpeciesId { get; set; }

    public int? UserId { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

