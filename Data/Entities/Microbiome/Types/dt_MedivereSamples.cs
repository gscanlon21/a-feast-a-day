using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_MedivereSamples
{
}

/*CREATE TYPE [dbo].[dt_MedivereSamples] AS TABLE(
	[TaxRank] [varchar](20) NOT NULL,
	[TaxName] [varchar](max) NULL,
	[Count] [int] NULL,
	[CountNorm] [int] NULL,
	[Taxon] [int] NOT NULL DEFAULT ((0))
)*/