
namespace Data.Entities.Microbiome;

class dt_Maintenance_UpdateTaxHierarchy
{
}

/*CREATE TYPE [dbo].[dt_Maintenance_UpdateTaxHierarchy] AS TABLE(
	[taxon] [int] NOT NULL,
	[parent] [int] NULL,
	[tax_rank] [varchar](50) NULL,
	PRIMARY KEY CLUSTERED 
(
	[taxon] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)*/