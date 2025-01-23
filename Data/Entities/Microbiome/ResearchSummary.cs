using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("research_summary")]
[DebuggerDisplay("{Name,nq}")]
public class ResearchSummary
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[Research_Summary](
	[SymptomId] [int] NOT NULL,
	[Taxon] [int] NOT NULL,
	[Src] [varchar](20) NOT NULL,
	[WithMean] [float] NULL,
	[WithoutMean] [float] NULL,
	[TScore] [float] NULL,
	[DF] [float] NULL,
	[Probability] [varchar](9) NOT NULL,
 CONSTRAINT [PK_Research_Summary] PRIMARY KEY CLUSTERED 
(
	[SymptomId] ASC,
	[Taxon] ASC,
	[Src] ASC
)
*/