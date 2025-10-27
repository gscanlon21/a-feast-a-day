using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome.Types;

public class KMJson
{
    [Key]
    public int Id { get; set; }
    public int? KmLow { get; set; }
    public int? KmHigh { get; set; }
    public string? Json { get; set; }
}
