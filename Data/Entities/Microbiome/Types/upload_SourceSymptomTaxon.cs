using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("upload_SourceSymptomTaxon")]
public class upload_SourceSymptomTaxon
{
    [Key]
    public string Source { get; set; } = null!;

    [Key]
    public int SymptomId { get; set; }

    [Key]
    public int Taxon { get; set; }

    public double? Chi2 { get; set; }

    public string? Direction { get; set; }
}
