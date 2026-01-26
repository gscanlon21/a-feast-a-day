using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("condition_symptom")]
[DebuggerDisplay("{Name,nq}")]
public class ConditionSymptom
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Key, Column(Order = 0)]
    public string ConditionCode { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int SymptomId { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
