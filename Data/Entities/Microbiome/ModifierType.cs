using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class ModifierType
{
    [Key, Required]
    public string MType { get; set; }

    [Required, Column("ModifierType")]
    public string ModifierTypeName { get; set; }

    public string? De2 { get; set; }

    public string? Es2 { get; set; }

    public string? Da2 { get; set; }

    public string? Se2 { get; set; }

    public string? Cy2 { get; set; }

    public string? It2 { get; set; }

    public string? Fr2 { get; set; }

    [Required]
    public int Skills { get; set; }
}

