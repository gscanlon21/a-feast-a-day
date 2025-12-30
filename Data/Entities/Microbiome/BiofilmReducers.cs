using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("BiofilmReducers")]
class BiofilmReducers
{
    [Required]
    [Key, Column(Order = 0)]
    public int Mid2 { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Cid { get; set; }
}
