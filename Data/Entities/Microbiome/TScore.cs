using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class TScore
{
    [Key, Required]
    public int Df { get; set; }

    public double? P01 { get; set; }

    public double? P001 { get; set; }
}
