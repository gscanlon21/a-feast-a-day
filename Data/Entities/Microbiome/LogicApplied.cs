using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("logic_applied")]
[DebuggerDisplay("{Name,nq}")]
public class LogicApplied
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}
/*
CREATE TABLE [dbo].[LogicApplied](
	[LogicCode] [varchar](1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_LogicApplied] PRIMARY KEY CLUSTERED 
(
	[LogicCode] ASC
)
*/