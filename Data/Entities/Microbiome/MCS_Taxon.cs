using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("mcs_taxon")]
[DebuggerDisplay("{Name,nq}")]
public class MCS_Taxon
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[MCS_Taxon](
	[Taxon] [int] NOT NULL,
	[ShiftIs] [varchar](4) NULL
)
*/