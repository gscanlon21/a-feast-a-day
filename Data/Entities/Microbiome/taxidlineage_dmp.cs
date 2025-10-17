using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("ncbi_taxidlineage_dmp")]
class taxidlineage_dmp
{
}

/*CREATE TABLE [NCBI].[taxidlineage_dmp](
	[d_Taxon] [int] NOT NULL,
	[d_hierarchy] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[d_Taxon] ASC
)
*/