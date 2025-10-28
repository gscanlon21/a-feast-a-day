using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_StatsChiTable
{
    public int? Taxon { get; set; }
    public int? SymptomId { get; set; }
    public int? Src { get; set; }
    public double? Chi2 { get; set; }
    public char? End { get; set; }
    public char? Shift { get; set; }
}
