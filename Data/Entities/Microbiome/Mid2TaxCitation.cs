namespace Data.Entities.Microbiome;

internal class Mid2TaxCitation
{
}

/*CREATE TABLE [dbo].[Mid2TaxCitation](
	[mid2] [int] NOT NULL,
	[taxon] [int] NOT NULL,
	[cid] [int] NOT NULL,
	[increases] [float] NOT NULL,
	[decreases] [float] NOT NULL,
	[RuleId] [int] IDENTITY(1,1) NOT NULL,
	[Logic] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Mid2TaxCitation] PRIMARY KEY CLUSTERED 
(
	[mid2] ASC,
	[taxon] ASC,
	[cid] ASC,
	[Logic] ASC
)*/