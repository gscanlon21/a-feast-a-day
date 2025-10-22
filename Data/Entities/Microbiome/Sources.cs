using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Sources
{
    [Key]
    [Required]
    public string Source { get; set; } = null!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SourceId { get; set; }
}
