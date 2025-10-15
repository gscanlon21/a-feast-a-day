using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("condition_progression")]
[DebuggerDisplay("{Name,nq}")]
public class ConditionProgression
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[ConditionProgression](
	[FromCondition] [varchar](3) NOT NULL,
	[ToCondition] [varchar](3) NOT NULL,
	[Matches] [float] NOT NULL,
	[Total] [float] NOT NULL,
	[Percentage]  AS (case when [Total]<[possible] then ((100.0)*[Matches])/[Total] else ((100.0)*[Matches])/[Possible] end),
	[Possible] [float] NOT NULL
)*/