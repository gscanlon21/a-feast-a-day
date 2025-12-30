using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.BiomeSight;

[Table("BiomeShifts")]
public class BiomeShifts
{
    [Key, Required]
    public int Taxon { get; set; }

    [Required]
    public double Shift { get; set; }
}
