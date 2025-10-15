using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("BatchProcess")]
class BatchProcess
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int ScopeId { get; set; }

    [Required]
    public DateTime AsOf { get; set; }

    [Required]
    public string Scope { get; set; } = string.Empty;
}
