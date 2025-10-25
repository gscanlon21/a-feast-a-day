using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TaxonRatios
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RatioId { get; set; }

    [Required]
    public string TopTaxon { get; set; }

    [Required]
    public string BottomTaxon { get; set; }

    [Required]
    public string RatioName { get; set; }

    public string Description { get; set; }
}

