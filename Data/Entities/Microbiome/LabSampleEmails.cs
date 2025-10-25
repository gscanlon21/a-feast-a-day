using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class LabSampleEmails
{
    [Required, Key, Column(Order = 0)]
    public int LabSampleId { get; set; }

    [Required, Key, Column(Order = 1)]
    public string Email { get; set; } = string.Empty;

    public DateTime? AddDate { get; set; }
}

