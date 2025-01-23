using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("category_upload")]
[DebuggerDisplay("{Name,nq}")]
public class CategoryUpload
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[CategoryUpload](
	[Phylum] [varchar](50) NULL,
	[Class] [varchar](50) NULL,
	[Order] [varchar](50) NULL,
	[Family] [varchar](50) NULL,
	[Genus] [varchar](50) NULL,
	[Species] [varchar](255) NULL,
	[rawcount] [float] NULL,
	[ratio] [float] NULL,
	[taxon] [int] NULL
)
*/