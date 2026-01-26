using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("upload_SourceSymptomCompound")]
public class upload_SourceSymptomCompound
{
    [Required]
    public string Source { get; set; } = string.Empty;

    [Required]
    public int SymptomId { get; set; }

    [Required]
    public int CPID { get; set; }

    public double? Chi2 { get; set; }

    public string? Direction { get; set; }
}
