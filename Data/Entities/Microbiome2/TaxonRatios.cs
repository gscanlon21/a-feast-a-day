using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TaxonRatios
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RatioId { get; set; }

    [Required]
    public string TopTaxon { get; set; } = null!;

    [Required]
    public string BottomTaxon { get; set; } = null!;

    [Required]
    public string RatioName { get; set; } = null!;

    public string Description { get; set; } = null!;
}

