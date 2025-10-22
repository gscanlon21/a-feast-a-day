using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class EndproductExtract
{
    [Key, Column(Order = 0)]
    [Required]
    public int EpId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }

    public string? Extract { get; set; }
}
