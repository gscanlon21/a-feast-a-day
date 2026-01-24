using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class ConditionModifier2
{
    [Required]
    [Key, Column(Order = 0)]
    public string ConditionCode { get; set; } = string.Empty;

    [Required]
    [Key, Column(Order = 1)]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    [Required]
    [Key, Column(Order = 2)]
    public int Mid2 { get; set; }

    [Required]
    public string Impact { get; set; } = string.Empty;

    [Required]
    public string Comment { get; set; } = string.Empty;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
