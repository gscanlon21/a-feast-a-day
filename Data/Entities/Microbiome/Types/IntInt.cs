using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntInt
{
}

/*CREATE TYPE [dbo].[IntInt] AS TABLE(
	[Id] [int] NOT NULL,
	[ArrayIndex] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)*/