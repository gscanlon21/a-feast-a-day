using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class KMString
{
    public string Id { get; set; } = string.Empty;
    public int? KmLow { get; set; }
    public int? KmHigh { get; set; }
}
