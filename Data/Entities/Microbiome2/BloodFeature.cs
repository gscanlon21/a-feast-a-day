using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("blood_feature")]
[DebuggerDisplay("{Name,nq}")]
public class BloodFeature
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BloodId { get; set; }

    [Required]
    public string ClinicalFeature { get; set; } = string.Empty;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
