using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("special_purpose")]
[DebuggerDisplay("{Id}: {Purpose}")]
public class SpecialPurpose
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [NotMapped]
    public int SPid => Id;

    [Required]
    public string Purpose { get; set; } = null!;

    public string? MoreInfo { get; set; }

    public string? CfsLink { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}