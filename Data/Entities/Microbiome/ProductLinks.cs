using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("product_links")]
[DebuggerDisplay("{Name,nq}")]
public class ProductLinks
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    public int Mod2 { get; set; }

    [Key, Column(Order = 1)]
    public string Country { get; set; } = string.Empty;

    [Key, Column(Order = 2)]
    public string Uri { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    public string? ImageUri { get; set; }

    public string? ImageCaption { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
