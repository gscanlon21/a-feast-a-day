using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class Symptoms
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SymptomId { get; set; }

    [Required]
    public string SymptomName { get; set; }

    [Required]
    public string SymptomUri { get; set; }

    [Required]
    public int SymptomCnt { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

    public string StudyName { get; set; }

    public string ICDCode { get; set; }

    [Required]
    public bool UseSymptom { get; set; }
}
