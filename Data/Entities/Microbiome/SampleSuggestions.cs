using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class SampleSuggestions
{
    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public DateTime AsOf { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public int Mod2 { get; set; }

    public double? Avoid { get; set; }

    public double? Take { get; set; }
}
