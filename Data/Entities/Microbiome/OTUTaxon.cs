using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class OTUTaxon
{
    [Key, Required]
    public int OTUNumber { get; set; }

    public int? Taxon { get; set; }

    [Required]
    public string OTUName { get; set; } = null!;
}
