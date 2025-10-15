using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microba_samples")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobaSamples
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[MicrobaSamples](
	[sampleId] [int] NOT NULL,
	[Phylum] [varchar](100) NOT NULL,
	[Family] [varchar](100) NULL,
	[Genus] [varchar](100) NULL,
	[Species] [varchar](100) NULL,
	[Abundance] [float] NULL,
	[RangeLow] [float] NULL,
	[RangeHigh] [float] NULL,
	[Taxon] [int] NULL
)
*/