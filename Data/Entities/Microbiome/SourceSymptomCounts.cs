using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class SourceSymptomCounts
{
    [Key, Required]
    public int SymptomId { get; set; }

    public int? Associations { get; set; }
}

