namespace Data.Entities.Microbiome;

class StatisticsCondition
{
}

/*CREATE TABLE [statistics].[Condition](
	[source] [varchar](16) NOT NULL,
	[ConditionCode] [varchar](16) NOT NULL,
	[Mean] [float] NULL,
	[SD] [float] NULL,
	[BoxLow] [float] NULL,
	[BoxHigh] [float] NULL,
	[KMLow] [float] NULL,
	[KMHigh] [float] NULL,
	[Count] [float] NULL,
	[Median] [float] NULL,
 CONSTRAINT [PK_Condition_1] PRIMARY KEY CLUSTERED 
(
	[source] ASC,
	[ConditionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]*/