using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_StatsChiTable
{
}

/*CREATE TYPE [dbo].[dt_StatsChiTable] AS TABLE(
	[Taxon] [int] NULL,
	[symptomid] [int] NULL,
	[src] [int] NULL,
	[chi2] [float] NULL,
	[end] [char](1) NULL,
	[shift] [char](1) NULL
)*/