namespace Data.Entities.Microbiome;

internal class AutoImmuneFilter
{
}

/*
 
CREATE TABLE [dbo].[AutoImmuneFilter](
	[taxon] [int] NOT NULL,
	[direction] [varchar](3) NOT NULL,
	[Weight] [float] NOT NULL,
	[Tax_rank] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AutoImmuneFilter] PRIMARY KEY CLUSTERED 
(
	[taxon] ASC,
	[direction] ASC
)
 
 */