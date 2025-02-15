namespace Data.Entities.Microbiome;

internal class Kegg_Enzymes
{
}

/*CREATE TABLE [dbo].[Kegg_Enzymes](
	[EcId] [int] IDENTITY(1,1) NOT NULL,
	[EcKey] [varchar](20) NOT NULL,
	[OtherName] [varchar](max) NULL,
	[EnzymeName] [varchar](2000) NULL,
	[Density] [float] NOT NULL,
	[url]  AS ('https://www.kegg.jp/entry/'+[ecKey]) PERSISTED NOT NULL,
	[LowEdge] [float] NULL,
	[HighEdge] [float] NULL,
	[BacteriaUrl]  AS ('/Library/Bacteria?ecid='+CONVERT([varchar](11),[ecid])),
	[StatisticsUrl]  AS ('/Library/Statistics?ecid='+CONVERT([varchar](11),[ecid])),
	[NormalLow] [float] NULL,
	[NormalHigh] [float] NULL,
	[Species] [int] NULL,
	[Supplement] [varchar](100) NULL,
	[TaxonCount] [int] NULL,
	[HealthName] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Reaction] [nvarchar](max) NULL,
	[Comment] [nvarchar](max) NULL,
 CONSTRAINT [PK_KEGG_Enzymes] PRIMARY KEY CLUSTERED 
(
	[EcKey] ASC
)*/