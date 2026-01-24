using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class UserLabs
{
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ULId { get; set; }

    [Required]
    public string LG { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;

    [Required]
    public DateTime TakenDate { get; set; }

    public string? Person { get; set; }
}
