namespace Data.Entities.Microbiome;

class UserCounts
{
}

/*CREATE TABLE [dbo].[UserCounts](
	[UserId] [int] NOT NULL,
	[Taxon] [int] NOT NULL,
	[Count] [int] NULL,
	[Count_Norm] [int] NOT NULL,
	[SampleId] [int] NOT NULL,
	[Percentile] [float] NULL,
	[Percentage]  AS (round([Count_Norm]/(10000.0),(4))),
	[ZeroPercentile] [float] NULL,
 CONSTRAINT [PK_UserCounts2] PRIMARY KEY CLUSTERED 
(
	[SampleId] ASC,
	[Taxon] ASC
)
) */