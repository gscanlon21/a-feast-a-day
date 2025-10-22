using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class UserCompoundProbiotic
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int Taxon { get; set; }

    [Required]
    public int Bit { get; set; }
}
