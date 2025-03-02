namespace Data.Entities.Microbiome;

class StatsTable_Compound
{
}

/*CREATE TABLE [dbo].[StatsTable_Compound](
	[source] [varchar](20) NOT NULL,
	[compound] [int] NOT NULL,
	[obs] [int] NULL,
	[percentiles] [varchar](max) NULL,
	[mean] [float] NULL,
	[stddev] [float] NULL,
	[median] [float] NULL,
	[lowlimit] [float] NULL,
	[highlimit] [float] NULL,
	[lowpercentile] [float] NULL,
	[highpercentile] [float] NULL,
	[lowpercentage] [float] NULL,
	[highpercentage] [float] NULL,
	[boxplotlow] [float] NULL,
	[boxplothigh] [float] NULL,
 CONSTRAINT [PK_StatsTable_Compound] PRIMARY KEY CLUSTERED 
(
	[source] ASC,
	[compound] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]*/