using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntIntDouble
{
}

/*CREATE TYPE [dbo].[IntIntDouble] AS TABLE(
	[SampleId] [int] NOT NULL,
	[Id] [int] NOT NULL,
	[Percent] [float] NULL,
	PRIMARY KEY CLUSTERED 
(
	[SampleId] ASC,
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)*/