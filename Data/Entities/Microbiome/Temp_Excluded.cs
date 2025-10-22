using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class Temp_Excluded
{
    [Key]
    [Required]
    public int PMID { get; set; }
}
