using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class ConditionDirection
{
    [Key]
    [Required]
    public string Direction { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
}
