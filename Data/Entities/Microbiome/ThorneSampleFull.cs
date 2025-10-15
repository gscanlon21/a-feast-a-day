using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("thorne_sample_full")]
[DebuggerDisplay("{Name,nq}")]
public class ThorneSampleFull
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TYPE [dbo].[dt_ThorneSampleFull] AS TABLE(
	[Domain] [varchar](200) NOT NULL,
	[KINGDOM] [varchar](200) NULL,
	[PHYLUM] [varchar](200) NULL,
	[CLASS] [varchar](200) NULL,
	[ORDER] [varchar](200) NULL,
	[FAMILY] [varchar](200) NULL,
	[GENUS] [varchar](200) NULL,
	[SPECIES] [varchar](200) NULL,
	[SEROGROUP] [varchar](200) NULL,
	[SEROTYPE] [varchar](200) NULL,
	[SUBSPECIES] [varchar](200) NULL,
	[STRAIN] [varchar](200) NULL,
	[ISOLATE] [varchar](200) NULL,
	[Abundance] [float] NULL,
	[P20] [float] NULL,
	[P80] [float] NULL,
	[Percentile] [float] NULL,
	[Taxon] [int] NULL
)
*/