using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_Tiny")]
public class dt_Tiny
{
    public string Rank { get; set; } = null!;
    public string Name { get; set; } = null!;

    [DefaultValue(0)]
    public double Amount { get; set; } = 0;
}
