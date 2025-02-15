namespace Data.Entities.Microbiome;

internal class Condition2Condition
{
}

/*CREATE TABLE [dbo].[Condition2Condition](
	[CondId1] [int] NOT NULL,
	[CondId2] [int] NOT NULL,
	[From1] [int] NOT NULL,
	[From2] [int] NOT NULL,
	[Common] [int] NULL,
	[PC1]  AS (((100.0)*[Common])/CONVERT([float],[From1])),
	[PC2]  AS (((100.0)*[Common])/CONVERT([float],[From2])),
 CONSTRAINT [PK_Condition2Condition] PRIMARY KEY CLUSTERED 
(
	[CondId1] ASC,
	[CondId2] ASC
)*/