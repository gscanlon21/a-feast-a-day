using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("precision_biome_taxa")]
[DebuggerDisplay("{Name,nq}")]
public class PrecisionBiomeTaxa
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[PrecisionBiomeTaxa](
	[Sample] [nvarchar](255) NULL,
	[ncbi_id] [float] NULL,
	[domain] [nvarchar](255) NULL,
	[kingdom] [nvarchar](255) NULL,
	[phylum] [nvarchar](255) NULL,
	[class] [nvarchar](255) NULL,
	[order] [nvarchar](255) NULL,
	[family] [nvarchar](255) NULL,
	[genus] [nvarchar](255) NULL,
	[species] [nvarchar](255) NULL,
	[mean_abundance] [float] NULL,
	[q0_abundance] [float] NULL,
	[q10_abundance] [float] NULL,
	[q20_abundance] [float] NULL,
	[q30_abundance] [float] NULL,
	[q40_abundance] [float] NULL,
	[q50_abundance] [float] NULL,
	[q60_abundance] [float] NULL,
	[q70_abundance] [float] NULL,
	[q80_abundance] [float] NULL,
	[q90_abundance] [float] NULL,
	[q100_abundance] [float] NULL
) ON [PRIMARY]
GO
*/