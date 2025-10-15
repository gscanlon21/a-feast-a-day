using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("special_conditions")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialConditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[SpecialConditions](
	[SCId] [int] IDENTITY(1,1) NOT NULL,
	[SpecialCondition] [varchar](100) NOT NULL,
	[ConditionCode] [varchar](2) NULL,
	[SymptomId] [int] NULL,
 CONSTRAINT [PK_SpecialConditions] PRIMARY KEY CLUSTERED 
(
	[SCId] ASC
)*/