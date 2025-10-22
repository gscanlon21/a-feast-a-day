using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class vw_Flavonoids
{
    [Required]
    public string NDBNo { get; set; }

    [Required]
    public string FId { get; set; }

    public string? FoodGroup { get; set; }

    public string? Food { get; set; }

    public string? SciName { get; set; }

    public string? Flavonoids { get; set; }

    public string? FlavClass { get; set; }

    public double? Amount { get; set; }

    public bool? MastCellStabilizer { get; set; }
}
