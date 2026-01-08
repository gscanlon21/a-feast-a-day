using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public int Cid { get; set; }

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
}
