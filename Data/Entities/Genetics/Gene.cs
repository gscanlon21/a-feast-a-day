using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Genetics;


/// <summary>
/// User's custom todo tasks.
/// </summary>
[Table("gene")]
[DebuggerDisplay("{Name,nq}")]
public class Gene
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    /// <summary>
    /// The name of the gene.
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


    [JsonIgnore, InverseProperty(nameof(SNP.Gene))]
    public virtual IList<SNP> SNPs { get; set; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Gene other
        && other.Id == Id;
}
