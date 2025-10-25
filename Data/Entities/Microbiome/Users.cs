using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Users
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int UserId { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public int SequenceId { get; set; }

    [Required]
    public DateTime SamplingTime { get; set; }

    [Required]
    public DateTime UploadDate { get; set; }

    [Required]
    public string Person { get; set; }

    [Required]
    public string Source { get; set; }

    public int? SourceId { get; set; }

    [Required]
    public string SampleName { get; set; }

    public string? ClinicEmail { get; set; }

    // XML type
    public string? CustomSelection { get; set; }

    [Required]
    public int MatchSampleId { get; set; }

    public double? SymptomHealth { get; set; }
    public double? ConditionHealth { get; set; }

    // AS (((((((([source]+':')+CONVERT([nvarchar](10),[sampling_time],(126)))+'  ')+[person])+' ')+case when [Biofilmcount]>(600) then N' 🛑' when [Biofilmcount]>(50) then N' ⚠️' else N'' end)+case when [dlacticcount]>(270) then N' ⚗️' else N'' end)+case when [histaminecount]>(15) then N' 🤧' when [histaminecount]>(1000) then N' 🤢' else N'' end),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string? Title { get; set; }

    public double? Hash { get; set; }
    public int? Custom { get; set; }
    public int? TaxonCount { get; set; }
    public int? Symptoms { get; set; }
    public int? SameSymptomsAs { get; set; }
    public int? FastQId { get; set; }
    public double? Chi2 { get; set; }
    public double? Chi2AdjPercentile { get; set; }

    //  AS (CONVERT([int],(100.0)*((1.0)-[SymptomHealth]))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? SymptomPercent { get; set; }

    //  AS (CONVERT([int],(100.0)*((1.0)-[ConditionHealth]))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int? ConditionPercent { get; set; }

    public string? Consultant { get; set; }

    public string? PersonEmail { get; set; }

    public string? UploadFileName { get; set; }
    public int? BiomeSightId { get; set; }
    public DateTime? RecalcDate { get; set; }
    public double? Shannon { get; set; }
    public double? Simpson { get; set; }
    public double? Chao { get; set; }
    public double? ShannonRank { get; set; }
    public double? SimpsonRank { get; set; }
    public double? ChaoRank { get; set; }

    [Required]
    public double Antiinflammatory { get; set; }

    public int? PdfEmail { get; set; }

    [Required]
    public double Histamine { get; set; }

    [Required]
    public double Butyrate { get; set; }

    [Required]
    public bool IsUnique { get; set; }

    public int? JasonCount { get; set; }
    public int? OralBacteriaCount { get; set; }
    public int? OralTaxaCount { get; set; }
    public int? KeySymptomBacteriaCnt { get; set; }
    public int? HealthPredictors { get; set; }

    [Required]
    public int BioFilmCount { get; set; }

    [Required]
    public int DLacticCount { get; set; }

    [Required]
    public int HistamineCount { get; set; }
}

