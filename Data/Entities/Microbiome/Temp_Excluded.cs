using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class Temp_Excluded
{
    [Key]
    [Required]
    public int PMID { get; set; }
}
