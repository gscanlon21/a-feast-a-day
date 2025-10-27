using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_NewXenogene")]
public class dt_NewXenogene
{
    public int? Taxon { get; set; }

    [DefaultValue(0)]
    public double? Percent { get; set; } = 0;

    public string? Name { get; set; }

    public string? Rank { get; set; }
}
