using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Microbiome;

public class Citations
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Cid { get; set; }

    [Required]
    [Column("uri")]
    public string Uri { get; set; } = string.Empty;

    public string? Abstract { get; set; }

    public string? Citation { get; set; }

    public string? PMID { get; set; }

    public string? PMCID { get; set; }

    public string? DOI { get; set; }

    public string? DirectUrl { get; set; }

    public string? JSON { get; set; }

    public int? AuditorId { get; set; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Mid2TaxCitation.Citation))]
    public virtual Mid2TaxCitation Mid2TaxCitation { get; private init; } = null!;

    #endregion
}
