using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class KyberKompakt
{
    [Required]
    [Key, Column(Order = 0)]
    public int Taxon { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public string LabGroup { get; set; } = null!;

    public int? DisplayOrder { get; set; }
}
