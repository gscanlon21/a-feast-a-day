using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Thorne;

class ThorneLookup
{
    [Key, Required]
    public string TKey { get; set; } = null!;

    public int? Taxon { get; set; }
}
