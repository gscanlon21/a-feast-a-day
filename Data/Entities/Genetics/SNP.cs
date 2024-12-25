using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;


/// <summary>
/// User's custom todo tasks.
/// </summary>
[Table("snp")]
[DebuggerDisplay("{Name,nq}")]
public class SNP
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// An rsid or an internal id .
    /// </summary>
    [Required]
    public string Name { get; set; } = null!;

    public string? Notes { get; set; } = null;

    public string? DisabledReason { get; set; } = null;

    [NotMapped]
    public bool Enabled
    {
        get => string.IsNullOrWhiteSpace(DisabledReason);
        set => DisabledReason = value ? null : "Disabled by user";
    }


    [JsonIgnore, InverseProperty(nameof(Genetics.Gene.SNPs))]
    public virtual Gene Gene { get; set; } = null!;

    [JsonIgnore, InverseProperty(nameof(Study.SNP))]
    public virtual ICollection<Study> Studies { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is SNP other
        && other.Id == Id;
}
