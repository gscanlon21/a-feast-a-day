using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

[Table("biofilm_reducers")]
public class BiofilmReducers
{
    [Required]
    [Key, Column(Order = 0)]
    public int Mid2 { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int CitationId { get; set; }
    public int Cid => CitationId;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
