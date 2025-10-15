using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("microbiome_upload")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobiomeUpload
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[MicrobiomeUpload](
	[Taxon] [int] NULL,
	[TaxName] [varchar](200) NOT NULL,
	[TaxRank] [varchar](50) NULL,
	[Count] [int] NULL,
	[CountNorm] [int] NOT NULL
)
*/