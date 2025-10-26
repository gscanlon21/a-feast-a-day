using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Temp;

public class Temp_Microba
{
    public int? Taxon { get; set; }

    [Required]
    public string TaxRank { get; set; }

    [Required]
    public string Name { get; set; }
}
