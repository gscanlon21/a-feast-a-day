namespace Data.Entities.Microbiome;

internal class ubiomeTax
{
}

/*
 CREATE TABLE [dbo].[ubiomeTax](
	[taxon] [int] NOT NULL,
	[parent] [int] NULL,
	[tax_name] [nvarchar](200) NULL,
	[tax_rank] [varchar](20) NULL,
	[datapunkUri]  AS (('https://www.datapunk.net/substrata/display.pl?'+CONVERT([varchar](11),[taxon]))+'+S'),
	[genomeUri]  AS ('https://www.ncbi.nlm.nih.gov/genomes/GenomesGroup.cgi?taxid='+CONVERT([varchar](11),[taxon])),
	[Significance] [float] NULL,
	[GutFrequency] [float] NULL,
	[AltName] [varchar](max) NULL,
	[MeanCount] [float] NULL,
	[url]  AS ('/library/details?taxon='+CONVERT([varchar](11),[taxon])) PERSISTED,
	[bacteriaUrl]  AS ('/library/details?taxon='+CONVERT([varchar](11),[taxon])),
	[StatisticsUrl]  AS ('/Library/Statistics?taxon='+CONVERT([varchar](11),[taxon])),
	[KMLow] [float] NULL,
	[KMHigh] [float] NULL,
	[gram] [varchar](50) NULL,
	[NormalLow]  AS ([KMLow]),
	[NormalHigh]  AS ([KMHigh]),
	[LabLow] [float] NULL,
	[LabHigh] [float] NULL,
	[BoxPlotLow] [float] NULL,
	[BoxPlotHigh] [float] NULL,
	[SampleCount] [int] NULL,
	[description] [nvarchar](max) NULL,
	[OralBacteria] [bit] NOT NULL,
	[HighAssociationCnt] [int] NULL,
	[LowAssociationCnt] [int] NULL,
	[ImageNo] [int] NULL,
	[ImageUrl]  AS ('http://www.ncbi.nlm.nih.gov/Taxonomy/taxi/images/'+CONVERT([varchar],[ImageNo])) PERSISTED,
	[Persistent] [float] NULL,
	[RefChart] [varchar](max) NULL,
 CONSTRAINT [PK_ubiomeTax] PRIMARY KEY CLUSTERED 
(
	[taxon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
 * */