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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 * */