using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntIntDouble
{
    [Key, Column(Order = 0)]
    public int SampleId { get; set; }

    [Key, Column(Order = 1)]
    public int Id { get; set; }

    public double? Percent { get; set; }
}

