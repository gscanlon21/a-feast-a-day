using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class ConditionProbioticPubMed
{
    [Required]
    [Key, Column(Order = 0)]
    public int CondId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Psid { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public int CitationId { get; set; }
    public int Cid => CitationId;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
