using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class tbl_Covid_State
{
    public int Date { get; set; }
    public string State { get; set; } = null!;
    public int Positive { get; set; }
    public int Negative { get; set; }
    public int Hospitalized { get; set; }
    public int Death { get; set; }
}
