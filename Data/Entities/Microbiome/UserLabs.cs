using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class UserLabs
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int ULId { get; set; }

    [Required]
    public string LG { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime TakenDate { get; set; }

    public string? Person { get; set; }
}
