using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("salicylate")]
[DebuggerDisplay("{Name,nq}")]
public class Salicylate
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Display(Name = "Food")]
    public string Food { get; set; } = null!;

    public float? FreeSa { get; set; }
    public decimal? BoundSa { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
