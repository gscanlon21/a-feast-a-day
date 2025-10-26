using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("upload_SourceSymptomEnzyme")]
public class upload_SourceSymptomEnzyme
{
    [Key]
    public string Source { get; set; } = null!;

    [Key]
    public int SymptomId { get; set; }

    [Key]
    public string ECKey { get; set; } = null!;

    public double? Chi2 { get; set; }

    public string? Direction { get; set; }
}
