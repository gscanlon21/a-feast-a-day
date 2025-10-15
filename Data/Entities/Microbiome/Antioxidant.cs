using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("antioxidant")]
[DebuggerDisplay("{Name,nq}")]
public class Antioxidant
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [Required]
    public string Food { get; set; } = string.Empty;

    [Required]
    public double MmolPer100g { get; set; }

    public int? Mid2 { get; set; }

    public int? Cid { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Aid { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
