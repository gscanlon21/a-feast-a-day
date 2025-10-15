using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microba")]
[DebuggerDisplay("{Name,nq}")]
public class Microba
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[Microba](
	[Taxon] [int] NOT NULL,
	[Tax_Rank] [varchar](20) NULL,
	[gtdbName] [varchar](50) NOT NULL
)
*/