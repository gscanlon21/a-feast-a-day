using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Cytokines
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CyId { get; set; }
    public string Cytokine { get; set; } = string.Empty;
    public string? AltName { get; set; }
    public string? Description { get; set; }
    public bool? AcuteInflammation { get; set; }
    public bool? ChronicInflammation { get; set; }
    public bool? CellularResponse { get; set; }
    public bool? Interferons { get; set; }
    public bool? TransformingGrowthFactor { get; set; }
}
