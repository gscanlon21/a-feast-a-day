using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("dt_newInformeDeMicrobiotaIntestinal")]
public class dt_newInformeDeMicrobiotaIntestinal
{
    public int Taxon { get; set; }
    public double? RawCount { get; set; }
    public double? Percentage { get; set; }
}
