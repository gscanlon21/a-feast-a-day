using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Temp;

public class Temp_Excluded
{
    [Key]
    [Required]
    public int PMID { get; set; }
}
