using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("condition_symptom")]
[DebuggerDisplay("{Name,nq}")]
public class ConditionSymptom
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[ConditionSymptom](
	[ConditionCode] [varchar](3) NOT NULL,
	[SymptomId] [int] NOT NULL,
 CONSTRAINT [PK_ConditionSymptom] PRIMARY KEY CLUSTERED 
(
	[ConditionCode] ASC,
	[SymptomId] ASC
)
*/