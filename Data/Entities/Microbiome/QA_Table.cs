using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class QA_Table
{
    [Key, Required]
    public int SymptomId { get; set; }

    public decimal? Matches { get; set; }

    public double? Chi2Matches { get; set; }
}

