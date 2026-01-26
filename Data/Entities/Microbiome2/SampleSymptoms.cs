using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class SampleSymptoms
{
    [Key, Column(Order = 0)]
    [Required]
    public int SequenceId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int SymptomId { get; set; }
}
