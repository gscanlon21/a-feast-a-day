using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class vw_SampleEndProduct
{
    [Required]
    public int EPid { get; set; }

    public int? SampleId { get; set; }

    public int? CountNorm { get; set; }
}

