namespace Data.Entities.Microbiome.Types;

public class tbl_Covid_US
{
    public int Date { get; set; }
    public int States { get; set; }
    public int Positive { get; set; }
    public int Negative { get; set; }
    public int Hospitalized { get; set; }
    public int Death { get; set; }
}
