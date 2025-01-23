using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("conditions")]
[DebuggerDisplay("{Name,nq}")]
public class Conditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[Conditions](
	[CondId] [int] IDENTITY(1,1) NOT NULL,
	[ConditionCode] [varchar](3) NOT NULL,
	[ConditionName] [varchar](255) NOT NULL,
	[GMRepoName] [varchar](100) NULL,
	[ProbioticSearch] [nvarchar](50) NULL,
	[Prevelance] [float] NULL,
	[TaxonCount] [int] NOT NULL,
	[OtherName] [varchar](2000) NULL,
	[ConditionUri] [varchar](255) NULL,
	[SymptomId] [int] NULL,
	[ConditionId]  AS ([CondId]),
	[MaxValue] [float] NULL,
	[MinValue] [float] NULL,
	[BacteriaUrl]  AS ('/Library/Bacteria?ConditionCode='+[ConditionCode]),
	[Url]  AS ([ConditionUri]),
	[StatisticsUrl]  AS ('/Library/Statistics?ConditionCode='+[ConditionCode]),
	[KmLow] [float] NULL,
	[KmHigh] [float] NULL,
	[NormalLow]  AS (round([KMLow],(2))),
	[NormalHigh]  AS (round([KMHigh],(2))),
	[AltName]  AS ([OtherName]),
	[ICDCode] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[cy] [nvarchar](max) NULL,
	[da] [nvarchar](max) NULL,
	[de] [nvarchar](max) NULL,
	[es] [nvarchar](max) NULL,
	[fr] [nvarchar](max) NULL,
	[it] [nvarchar](max) NULL,
	[se] [nvarchar](max) NULL,
 CONSTRAINT [PK_Conditions] PRIMARY KEY CLUSTERED 
(
	[ConditionName] ASC
)*/