using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class ItemList
{
}

/*CREATE TYPE [dbo].[ItemList] AS TABLE(
	[item] [int] NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[item] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)*/