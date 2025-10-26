using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("health")]
public class Health
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GMRepoID { get; set; }

    public string? Status { get; set; }

    [NotMapped]
    public string? ConditionName => Status;
}

