using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class DT_KeggTaxUpload
{
    public string Module { get; set; } = null!;
    public int Taxon { get; set; }
}

