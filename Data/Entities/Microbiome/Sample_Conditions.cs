using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Sample_Conditions
{
    [Key, Column(Order = 0)]
    [Required]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Condid { get; set; }

    public int? Percentage { get; set; }
}

