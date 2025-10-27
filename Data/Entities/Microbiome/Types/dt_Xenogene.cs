using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Xenogene
{
    public string TaxName { get; set; } = null!;
    public double? Percent { get; set; }
    public double? MinGoal { get; set; }
    public double? MaxGoal { get; set; }
}

