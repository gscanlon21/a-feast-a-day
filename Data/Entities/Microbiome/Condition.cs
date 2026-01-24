using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;


[Table("condition")]
[DebuggerDisplay("{Name,nq}")]
public class Condition
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int CondId { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public string ConditionCode { get; set; } = null!;

    [Required]
    [Key, Column(Order = 3)]
    public string Direction { get; set; } = null!;

    public string? RefUri { get; set; }

    [Required]
    [Key, Column(Order = 4)]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FactId { get; set; }

    public DateTime? Added { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
