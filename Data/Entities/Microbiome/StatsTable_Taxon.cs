namespace Data.Entities.Microbiome;

class StatsTable_Taxon
{
}

/*CREATE TABLE [dbo].[StatsTable_Taxon](
	[source] [varchar](20) NOT NULL,
	[taxon] [int] NOT NULL,
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
	[lablow]  AS (case when ([mean]-(1.96)*[Stddev])>(0) then round([mean]-(1.96)*[Stddev],(1)) else (0) end),
	[labhigh]  AS (round([mean]+(1.96)*[Stddev],(1))),
	[P15] [float] NULL,
	[P85] [float] NULL,
 CONSTRAINT [PK_StatsTable_Taxon] PRIMARY KEY CLUSTERED 
(
	[source] ASC,
	[taxon] ASC
)*/