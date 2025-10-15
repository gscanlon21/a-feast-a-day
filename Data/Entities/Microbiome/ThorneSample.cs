using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("thorne_sample")]
[DebuggerDisplay("{Name,nq}")]
public class ThorneSample
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TYPE [dbo].[dt_ThorneSample] AS TABLE(
	[Domain] [varchar](200) NOT NULL,
	[Abundance] [float] NOT NULL DEFAULT ((0)),
	[Percentile] [float] NULL DEFAULT ((0)),
	[Taxon] [int] NULL
)
*/