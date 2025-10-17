using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("special_purpose")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialPurpose
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SPid { get; set; }

    [Required]
    [StringLength(50)]
    public string Purpose { get; set; } = string.Empty;

    public string? MoreInfo { get; set; }

    public string? CfsLink { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}