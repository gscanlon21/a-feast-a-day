using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("TODO")]
public class tbl_ncbiHierarchy
{
    [Key, Column("taxon")]
    [Required]
    public int Taxon { get; set; }

    [Column("parent")]
    [Required]
    public int Parent { get; set; }

    [Column("rank")]
    [Required]
    public string Rank { get; set; } = string.Empty;
}
