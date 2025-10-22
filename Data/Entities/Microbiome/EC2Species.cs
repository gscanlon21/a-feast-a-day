using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class EC2Species
{
    [Required]
    [Key, Column(Order = 0)]
    public string ECKey { get; set; } = null!;

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    public double? Cnt { get; set; }
}
