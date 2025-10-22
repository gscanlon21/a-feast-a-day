using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class OTUTaxon
{
    [Key, Required]
    public int OTUNumber { get; set; }

    public int? Taxon { get; set; }

    [Required]
    public string OTUName { get; set; }
}
