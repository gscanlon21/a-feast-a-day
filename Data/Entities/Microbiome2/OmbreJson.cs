using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class OmbreJson
{
    [Required]
    public DateTime PostedAt { get; set; }

    public string? Json { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int JsonId { get; set; }
}

