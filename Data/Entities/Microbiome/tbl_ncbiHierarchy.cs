using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("TODO")]
public class tbl_ncbiHierarchy
{
    [Required]
    [Key, Column("taxon")]
    public int Taxon { get; set; }

    [Required]
    [Column("parent")]
    public int Parent { get; set; }

    [Column("rank")]
    public string Rank { get; set; } = string.Empty;
}
