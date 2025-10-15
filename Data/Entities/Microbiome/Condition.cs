using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("condition")]
[DebuggerDisplay("{Name,nq}")]
public class Condition
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[Condition](
	[Taxon] [int] NOT NULL,
	[CondId] [int] NOT NULL,
	[ConditionCode] [varchar](3) NOT NULL,
	[Direction] [varchar](1) NOT NULL,
	[RefUri] [varchar](255) NULL,
	[Cid] [int] NOT NULL,
	[FactId] [int] IDENTITY(1,1) NOT NULL,
	[Added] [datetime] NULL,
 CONSTRAINT [PK_Condition] PRIMARY KEY CLUSTERED 
(
	[Taxon] ASC,
	[ConditionCode] ASC,
	[Direction] ASC,
	[Cid] ASC
)*/