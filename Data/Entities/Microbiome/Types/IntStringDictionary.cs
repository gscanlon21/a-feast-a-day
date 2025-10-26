using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.Types;

[Table("TODO")]
public class IntStringDictionary
{
}

/*CREATE TYPE [dbo].[IntStringDictionary] AS TABLE(
	[MyKey] [int] NOT NULL,
	[MyValue] [nvarchar](max) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[MyKey] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)*/