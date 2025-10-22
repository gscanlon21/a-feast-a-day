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
    public string NutrNo { get; set; }

    [StringLength(255)]
    public string? NutrientName { get; set; }

    [StringLength(250)]
    public string? FlavClass { get; set; }

    [StringLength(20)]
    public string? Tagname { get; set; }

    [StringLength(255)]
    public string? Unit { get; set; }

    public bool? MastCellStabilizer { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

