using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("condition")]
[DebuggerDisplay("{Name,nq}")]
public class Condition
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key, Column(Order = 0)]
    [Required]
    public int Taxon { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public int CondId { get; set; }

    [Key, Column(Order = 2)]
    [Required]
    public string ConditionCode { get; set; }

    [Key, Column(Order = 3)]
    [Required]
    public string Direction { get; set; }

    public string? RefUri { get; set; }

    [Key, Column(Order = 4)]
    [Required]
    public int Cid { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FactId { get; set; }

    public DateTime? Added { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
