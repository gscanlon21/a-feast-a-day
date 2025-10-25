using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class SIBO_Taxon
{
    [Key]
    [Required]
    public int Taxon { get; set; }

    [Required]
    public string Shiftis { get; set; }
}
