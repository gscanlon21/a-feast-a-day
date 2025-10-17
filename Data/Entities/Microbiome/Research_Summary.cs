namespace Data.Entities.Microbiome;

internal class Research_Summary
{
}

/*CREATE TABLE [dbo].[Research_Summary](
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
)*/