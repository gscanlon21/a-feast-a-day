using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("special_conditions")]
[DebuggerDisplay("{Id}")]
public class SpecialConditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [NotMapped]
    public int SCId => Id;

    [Required]
    public string SpecialCondition { get; set; } = null!;

    public string? ConditionCode { get; set; }

    public int? SymptomId { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
