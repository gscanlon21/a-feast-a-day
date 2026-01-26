using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("Special")]
public class Special
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SpecialId { get; set; }

    [Required]
    public int Mid2 { get; set; }

    [Required]
    public string Summary { get; set; } = string.Empty;

    [Required]
    public int SPId { get; set; }
}

