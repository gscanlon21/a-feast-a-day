using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

class EndproductExtract
{
    [Key, Column(Order = 0)]
    [Required]
    public int EpId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    public string? Extract { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
