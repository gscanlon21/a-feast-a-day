using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class SpecialConditionCitation
{
    [Required]
    [Key, Column(Order = 0)]
    public int SCId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Mid2 { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    [Required]
    public bool Improves { get; set; }

    public string? Comment { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
