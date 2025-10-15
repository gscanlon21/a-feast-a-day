using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("metabolites")]
[DebuggerDisplay("{Name,nq}")]
public class Metabolites
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[Metabolites](
	[Metabolite] [nvarchar](255) NULL,
	[Bacteria] [nvarchar](255) NULL,
	[Taxon ID] [float] NULL,
	[Rank] [nvarchar](255) NULL,
	[Reference URL] [nvarchar](255) NULL,
	[F6] [nvarchar](255) NULL
)
*/