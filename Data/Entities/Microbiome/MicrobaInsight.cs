using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("microba_insight")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobaInsight
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[MicrobaInsight](
	[Phylum] [varchar](50) NOT NULL,
	[taxRank] [varchar](20) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[Taxon] [int] NULL,
	[LowLevel] [float] NULL,
	[HighLevel] [nchar](10) NULL,
	[Adapt] [varchar](100) NULL
)
*/