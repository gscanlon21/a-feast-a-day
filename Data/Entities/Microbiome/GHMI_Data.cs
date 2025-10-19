using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class GHMI_Data
{
    [Required]
    public string TaxonName { get; set; } = string.Empty;

    [Key, Required]
    public int Taxon { get; set; }

    [Required]
    public int PositiveHealth { get; set; }
}
