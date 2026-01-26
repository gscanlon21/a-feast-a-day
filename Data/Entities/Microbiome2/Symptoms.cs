using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

/// <summary>
/// R00-R99  Symptoms, signs and abnormal clinical and laboratory findings, not elsewhere classified.
/// https://ftp.cdc.gov/pub/Health_Statistics/NCHS/Publications/ICD10CM/
/// https://icdcdn.who.int/icd10/index.html
/// </summary>
public class Symptoms
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SymptomId { get; set; }

    [Required]
    public string SymptomName { get; set; } = null!;

    [Required]
    public string SymptomUri { get; set; } = null!;

    [Required]
    public int SymptomCnt { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

    public string StudyName { get; set; } = null!;

    public string ICDCode { get; set; } = null!;

    [Required]
    public bool UseSymptom { get; set; }
}
