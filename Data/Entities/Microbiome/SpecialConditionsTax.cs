using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("special_conditions_tax")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialConditionsTax
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[SpecialConditionsTax](
	[SymptomId] [int] NOT NULL,
	[Taxon] [int] NOT NULL,
	[Q4High] [float] NULL,
	[Obs] [int] NULL,
 CONSTRAINT [PK_SpecialConditionsTax] PRIMARY KEY CLUSTERED 
(
	[SymptomId] ASC,
	[Taxon] ASC
)*/