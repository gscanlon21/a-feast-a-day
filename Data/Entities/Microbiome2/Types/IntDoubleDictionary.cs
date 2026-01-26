using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("int_double_dictionary")]
public class IntDoubleDictionary
{
    [Key]
    [Required]
    public int MyKey { get; set; }

    [Required]
    public double MyValue { get; set; }
}
