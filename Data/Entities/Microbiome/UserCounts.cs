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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]*/