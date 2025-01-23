using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("microba_map")]
[DebuggerDisplay("{Name,nq}")]
public class MicrobaMap
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[MicrobaMap](
	[Phylum] [varchar](100) NOT NULL,
	[Family] [varchar](100) NULL,
	[Genus] [varchar](100) NULL,
	[Species] [varchar](100) NULL,
	[Taxon] [int] NULL,
	[wORKING] [varchar](100) NULL
)
*/