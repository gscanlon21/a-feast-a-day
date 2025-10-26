using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class dt_Tiny
{
}

/*CREATE TYPE [dbo].[dt_Tiny] AS TABLE(
	[Rank] [varchar](200) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Amount] [float] NOT NULL DEFAULT ((0))
)*/