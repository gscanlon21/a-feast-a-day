using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("taxa")]
[DebuggerDisplay("{Name,nq}")]
public class Taxa
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


/*CREATE TABLE [dbo].[Taxa](
	[taxonId] [float] NULL,
	[Taxon] [int] NULL,
	[label] [nvarchar](255) NULL,
	[domain] [nvarchar](255) NULL,
	[phylum] [nvarchar](255) NULL,
	[class] [nvarchar](255) NULL,
	[order] [nvarchar](255) NULL,
	[family] [nvarchar](255) NULL,
	[genus] [nvarchar](255) NULL,
	[species] [nvarchar](255) NULL,
	[id_L6] [nvarchar](255) NULL,
	[taxonomy] [nvarchar](255) NULL,
	[idelevel] [nvarchar](255) NULL,
	[NCBI_outlink] [nvarchar](255) NULL,
	[BacterioNet_outlink] [nvarchar](255) NULL,
	[Omni_habitat] [nvarchar](255) NULL,
	[Omni_pheno] [nvarchar](255) NULL,
	[Omni_use] [nvarchar](255) NULL
)*/