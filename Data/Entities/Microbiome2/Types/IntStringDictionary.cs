using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntStringDictionary
{
    [Key]
    public int MyKey { get; set; }
    public string MyValue { get; set; } = string.Empty;
}
