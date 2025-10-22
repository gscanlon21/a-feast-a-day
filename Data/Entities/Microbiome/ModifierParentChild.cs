using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class ModifierParentChild
{
    [Required]
    [Key, Column(Order = 0)]
    public int ParentMid { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int ChildMid { get; set; }
}
