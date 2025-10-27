using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Types;

public class MPDaily_Percentile
{
    [Key]
    public int Id { get; set; }

    public double? Percentile { get; set; }
}
