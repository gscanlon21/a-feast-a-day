using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class Taxon_NetCompound
{
    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int CPID { get; set; }

    [Required]
    public double NetCompound { get; set; }
}

