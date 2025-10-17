using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class Health
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GMRepoID { get; set; }

    [StringLength(100)]
    public string? Status { get; set; }

    [NotMapped]
    public string? ConditionName => Status;
}

