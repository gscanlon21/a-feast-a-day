using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class LabTests
{
    [Key, Required]
    public string LG { get; set; }

    [Required]
    public string LabName { get; set; }

    public int? Levels { get; set; }

    public string? Url { get; set; }

    public string? Email { get; set; }
}

