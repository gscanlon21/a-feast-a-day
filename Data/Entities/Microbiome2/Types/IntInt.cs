using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntInt
{
    [Key]
    public int Id { get; set; }

    public int ArrayIndex { get; set; }
}
