using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("km_condition")]
public class KMCondition
{
    [Key]
    public string Id { get; set; } = null!;

    public int? KmLow { get; set; }

    public int? KmHigh { get; set; }
}
