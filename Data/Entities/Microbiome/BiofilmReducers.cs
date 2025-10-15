using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("BiofilmReducers")]
class BiofilmReducers
{
    [Key, Column(Order = 0)]
    [Required]
    public int Mid2 { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int Cid { get; set; }
}
