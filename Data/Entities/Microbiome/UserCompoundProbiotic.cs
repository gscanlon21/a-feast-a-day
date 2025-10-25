using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class UserCompoundProbiotic
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int Taxon { get; set; }

    [Required]
    public int Bit { get; set; }
}
