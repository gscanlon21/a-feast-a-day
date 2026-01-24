using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

[Table("SpecialCitation")]
public class SpecialCitation
{
    [Required]
    [Key, Column(Order = 0)]
    public int SpecialId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int CitationId { get; set; }
    public int Cid => CitationId;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}

