using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class TaxonEndProduct
{
    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int EPID { get; set; }

    [Key, Column(Order = 2)]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    [Required]
    public double Factor { get; set; }

    [Required]
    public string Logic { get; set; } = null!;


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
