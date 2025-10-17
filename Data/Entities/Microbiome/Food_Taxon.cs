namespace Data.Entities.Microbiome;

internal class Food_Taxon
{
}

/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food_Taxon](
	[FoodId] [int] NOT NULL,
	[taxonID] [float] NOT NULL,
	[Weight] [float] NULL,
	[Taxon] [int] NULL,
 CONSTRAINT [PK_Food_Taxon] PRIMARY KEY CLUSTERED 
(
	[FoodId] ASC,
	[taxonID] ASC
)
) 
GO
 * */