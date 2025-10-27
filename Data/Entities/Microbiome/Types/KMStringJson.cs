using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Types;

public class KMStringJson
{
    [Key]
    public string Id { get; set; } = null!;
    public int? KmLow { get; set; }
    public int? KmHigh { get; set; }
}

