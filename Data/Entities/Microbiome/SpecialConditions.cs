using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("special_conditions")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialConditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SCId { get; set; }

    [Required]
    [StringLength(100)]
    public string SpecialCondition { get; set; } = string.Empty;

    [StringLength(2)]
    public string? ConditionCode { get; set; }

    public int? SymptomId { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
