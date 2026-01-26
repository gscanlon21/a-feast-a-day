using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Index(nameof(Source))]
public class Sources
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SourceId { get; set; }

    [Required]
    public string Source { get; set; } = null!;
}
