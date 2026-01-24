using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class Mid2TaxCitation
{
    [Required]
    [Key, Column(Order = 0)]
    public int Mid2 { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 2)]
    public int CitationId { get; set; }
    public int Cid => CitationId;

    [Required]
    [Key, Column(Order = 3)]
    public string Logic { get; set; } = null!;

    [Required]
    public double Increases { get; set; }

    [Required]
    public double Decreases { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RuleId { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Citations.Mid2TaxCitation))]
    public virtual Citations Citation { get; private init; } = null!;

    #endregion
}
