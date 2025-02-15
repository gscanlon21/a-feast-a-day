namespace Data.Entities.Microbiome;

internal class UserCountsThorne
{
}

/*CREATE TABLE [dbo].[UserCountsThorne](
	[UserId] [int] NOT NULL,
	[Taxon] [int] NOT NULL,
	[Count] [int] NULL,
	[Count_Norm] [float] NOT NULL,
	[SampleId] [int] NOT NULL,
	[Percentile] [float] NULL,
	[Percentage]  AS (round([Count_Norm]/(10000.0),(4))),
	[ZeroPercentile] [float] NULL,
 CONSTRAINT [PK_UserCountsThorne] PRIMARY KEY CLUSTERED 
(
	[SampleId] ASC,
	[Taxon] ASC
)*/