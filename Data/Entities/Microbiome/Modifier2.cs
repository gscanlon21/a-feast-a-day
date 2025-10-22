using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("modifier2")]
[DebuggerDisplay("{Name,nq}")]
public class Modifier2
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Mid2 { get; set; }

    [Required]
    public string ModifierOld { get; set; }

    // AS ([LatinName]+isnull((' {'+[CommonName])+'}','')),
    [Column("Modifier2")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Modifier2Name { get; set; }

    public string? LatinName { get; set; }

    public string? CommonName { get; set; }

    [Required]
    public string DrugNames { get; set; }

    [Required]
    public string MType { get; set; }

    [Required]
    public bool Exclude { get; set; }

    [Required]
    public bool Lactose { get; set; }

    [Required]
    public bool Histamine { get; set; }

    public int? Taxon { get; set; }

    public bool? Antihistamine { get; set; }

    public string? DosageUrl { get; set; }

    // AS ('https://microbiomeprescription.com/library/modifier?mid2='+CONVERT([varchar](11),[Mid2])),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Url { get; set; }

    public string? Dosage { get; set; }

    public bool? Synthetic { get; set; }

    public int? MpnId { get; set; }

    public string? Caution { get; set; }

    [Required]
    public bool Active { get; set; }

    public string? Description { get; set; }

    [Required]
    public bool External { get; set; }

    [Required]
    public bool Verified { get; set; }

    public string? De { get; set; }

    public string? Es { get; set; }

    public string? Da { get; set; }

    public string? Se { get; set; }

    public string? Cy { get; set; }

    public string? It { get; set; }

    public string? Fr { get; set; }

    [Required]
    public bool Biofilm { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
