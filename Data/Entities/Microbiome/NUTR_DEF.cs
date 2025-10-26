using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("nutr_def")]
[DebuggerDisplay("{Name,nq}")]
public class NUTR_DEF
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Required]
    public string NutrNo { get; set; } = null!;

    public string? NutrientName { get; set; }

    public string? FlavClass { get; set; }

    public string? Tagname { get; set; }

    public string? Unit { get; set; }

    public bool? MastCellStabilizer { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

