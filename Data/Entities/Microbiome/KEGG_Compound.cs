using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("kegg_compound")]
[DebuggerDisplay("{Name,nq}")]
public class KEGG_Compound
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


/*CREATE TABLE [dbo].[KEGG_Compound](
	[CPId] [int] NOT NULL,
	[CPD] [varchar](6) NOT NULL,
	[CompoundName] [nvarchar](256) NULL,
	[OtherName] [nvarchar](max) NULL,
	[Formula] [varchar](50) NULL,
	[url]  AS ('https://www.kegg.jp/entry/'+[CPD]),
	[Mass] [float] NULL,
	[ProducedNormalLow] [float] NULL,
	[ProducedNormalHigh] [float] NULL,
	[ConsumedNormalLow] [float] NULL,
	[ConsumedNormalHigh] [float] NULL,
	[OATS] [varchar](8) NULL,
	[ProductCount] [int] NULL,
	[SubstrateCount] [nchar](10) NULL,
	[Supplement] [nvarchar](100) NULL,
	[HealthName] [varchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Checked] [bit] NULL,
 CONSTRAINT [PK_KEGG_Compound] PRIMARY KEY CLUSTERED 
(
	[CPD] ASC
)*/