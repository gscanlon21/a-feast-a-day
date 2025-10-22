using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

class Pathogens
{
    [Key, Required]
    public int Taxon { get; set; }

    [Required]
    public string Disease { get; set; }

    [Required]
    public string PathogenUrl { get; set; }
}
