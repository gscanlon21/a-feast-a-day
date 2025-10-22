using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

class ThorneLookup
{
    [Key]
    [Required]
    public string TKey { get; set; }

    public int? Taxon { get; set; }
}
