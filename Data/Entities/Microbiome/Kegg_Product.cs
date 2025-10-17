namespace Data.Entities.Microbiome;

internal class Kegg_Product
{
}


/*
 
CREATE TABLE [dbo].[Kegg_Product](
	[Pid] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](300) NOT NULL,
	[Enzymes] [int] NOT NULL,
	[Species] [int] NULL,
	[Comment] [varchar](50) NULL,
	[NormalLow] [float] NULL,
	[NormalHigh] [float] NULL,
	[bacteriaUrl]  AS (('/Library/Bacteria?pid='+CONVERT([varchar](11),[pid]))+'&SampleId='),
	[statisticsUrl]  AS ('/Library/Statistics?pid='+CONVERT([varchar](11),[Pid])),
	[url]  AS ('https://www.kegg.jp/dbget-bin/www_bfind_sub?mode=bfind&max_hit=1000&dbkey=kegg&keywords='+[ProductName]),
	[Product]  AS ([ProductName]+isnull([Comment],'')),
	[Supplement] [varchar](100) NULL,
 CONSTRAINT [PK_Kegg_ProductEnzymes] PRIMARY KEY CLUSTERED 
(
	[ProductName] ASC
) 

 */
