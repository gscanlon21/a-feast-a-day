using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_TaxNameRankUpload
{
    public string? Tax_rank { get; set; }
    public string? Tax_Name { get; set; }
    public double? BaseOneMillion { get; set; }
}

