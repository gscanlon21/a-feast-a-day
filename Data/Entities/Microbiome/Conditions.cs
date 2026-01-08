using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("conditions")]
[DebuggerDisplay("{Name,nq}")]
public class Conditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string ConditionName { get; set; } = null!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CondId { get; set; }

    [Required]
    public string ConditionCode { get; set; } = null!;

    public string? GMRepoName { get; set; }

    public string? ProbioticSearch { get; set; }

    public double? Prevelance { get; set; }

    [Required]
    public int TaxonCount { get; set; }

    public string? OtherName { get; set; }

    public string? ConditionUri { get; set; }

    public int? SymptomId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int ConditionId { get; private set; }

    public double? MaxValue { get; set; }

    public double? MinValue { get; set; }

    // AS ('/Library/Bacteria?ConditionCode='+[ConditionCode]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string BacteriaUrl { get; private set; } = null!;

    // AS ([ConditionUri]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Url { get; private set; } = null!;

    // AS ('/Library/Statistics?ConditionCode='+[ConditionCode]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string StatisticsUrl { get; private set; } = null!;

    public double? KmLow { get; set; }

    public double? KmHigh { get; set; }

    // AS (round([KMLow],(2))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? NormalLow { get; private set; }

    // AS (round([KMHigh],(2))),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public double? NormalHigh { get; private set; }

    // AS ([OtherName]),
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string AltName { get; private set; } = null!;

    public string? ICDCode { get; set; }

    public string? Description { get; set; }

    public string? cy { get; set; }
    public string? da { get; set; }
    public string? de { get; set; }
    public string? es { get; set; }
    public string? fr { get; set; }
    public string? it { get; set; }
    public string? se { get; set; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
