using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class UserLabsCounts
{
    [Required]
    public int ULId { get; set; }

    [Required]
    public int Taxon { get; set; }

    [Required]
    public int Change { get; set; }

    public double? Weight { get; set; }
}

