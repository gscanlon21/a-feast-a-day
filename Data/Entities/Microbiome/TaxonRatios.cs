namespace Data.Entities.Microbiome;

internal class TaxonRatios
{
}

/*
 
 CREATE TABLE [dbo].[TaxonRatios](
	[RatioId] [int] IDENTITY(1,1) NOT NULL,
	[TopTaxon] [varchar](100) NOT NULL,
	[BottomTaxon] [varchar](100) NOT NULL,
	[RatioName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_TaxonRatios] PRIMARY KEY CLUSTERED 
(
	[RatioId] ASC
)
 */
