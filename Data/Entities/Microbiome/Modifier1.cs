using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Modifier1
{
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Mid1 { get; set; }

    [Required, Column("Modifier1")]
    public string Modifier1Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Uri { get; set; }

    public string? MType { get; set; }
}
