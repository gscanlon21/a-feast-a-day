using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("end_product")]
[DebuggerDisplay("{Name,nq}")]
public class EndProduct
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[EndProduct](
	[EpId] [int] IDENTITY(1,1) NOT NULL,
	[EndProduct] [nvarchar](max) NOT NULL,
	[AverageCount] [float] NULL,
	[DataPunkUri] [varchar](255) NULL,
	[StandardDeviation] [float] NULL,
	[Cnt] [int] NOT NULL,
	[Json] [varchar](max) NULL,
	[Density] [float] NOT NULL,
	[url]  AS ('/Library/EndProductProducers?epid='+CONVERT([varchar](11),[epid])) PERSISTED,
	[BacteriaUrl]  AS ('/Library/Bacteria?epid='+CONVERT([varchar](11),[epid])),
	[StatisticsUrl]  AS ('/Library/Statistics?epid='+CONVERT([varchar](11),[epid])),
	[NormalLow] [float] NULL,
	[NormalHigh] [float] NULL,
	[Mid2] [int] NULL,
	[KMLow] [float] NULL,
	[KMHigh] [float] NULL,
 CONSTRAINT [PK_EndProduct] PRIMARY KEY CLUSTERED 
(
	[EpId] ASC
)*/