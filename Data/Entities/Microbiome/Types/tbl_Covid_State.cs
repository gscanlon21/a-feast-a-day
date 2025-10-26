using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class tbl_Covid_State
{
}

/*CREATE TYPE [dbo].[tbl_Covid_State] AS TABLE(
	[Date] [int] NOT NULL,
	[State] [varchar](4) NOT NULL,
	[positive] [int] NOT NULL,
	[negative] [int] NOT NULL,
	[hospitalized] [int] NOT NULL,
	[death] [int] NOT NULL
)*/