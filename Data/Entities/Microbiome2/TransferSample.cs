using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class TransferSample
{
    [Required]
    [Key, Column(Order = 0)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SampleId { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public Guid Token { get; set; }
}
