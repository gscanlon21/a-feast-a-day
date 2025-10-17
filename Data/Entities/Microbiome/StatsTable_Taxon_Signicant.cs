namespace Data.Entities.Microbiome;

internal class StatsTable_Taxon_Signicant
{
}


/*
 CREATE TABLE [dbo].[StatsTable_Taxon_Signicant](
	[Taxon] [int] NOT NULL,
	[SymptomId] [int] NOT NULL,
	[Source] [varchar](20) NOT NULL,
	[Below15] [float] NULL,
	[Above15] [float] NULL,
	[WithSymptoms] [float] NULL,
	[BelowChi2] [float] NULL,
	[AboveChi2] [float] NULL,
 CONSTRAINT [PK_StatsTable_Taxon_Signicant] PRIMARY KEY CLUSTERED 
(
	[Taxon] ASC,
	[SymptomId] ASC,
	[Source] ASC
)
 */