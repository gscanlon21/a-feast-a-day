using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("probiotics")]
[DebuggerDisplay("{Name,nq}")]
public class Probiotics
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int ProId { get; set; }

    [Required]
    public string ProbioticName { get; set; } = null!;

    // AS ('/Library/ProbioticDetails?ProId='+CONVERT([varchar](11),[ProId])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; set; }

    public double? SpeciesCount { get; set; }

    [Required]
    public bool Canada { get; set; }

    [Required]
    public bool USA { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
