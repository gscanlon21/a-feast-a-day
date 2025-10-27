using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class ItemList
{
    [Key]
    public int Item { get; set; }
}

