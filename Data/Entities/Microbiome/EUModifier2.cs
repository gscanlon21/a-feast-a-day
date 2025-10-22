using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

class EUModifier2
{
    [Key, Required]
    public int Mid2 { get; set; }

    public bool? Include { get; set; }
}
