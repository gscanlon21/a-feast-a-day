using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("net_compound")]
[DebuggerDisplay("{Name,nq}")]
public class NetCompound
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[NetCompound](
	[Cpid] [int] NOT NULL,
	[KMLow] [float] NULL,
	[KMHigh] [float] NULL,
 CONSTRAINT [PK_NetCompound] PRIMARY KEY CLUSTERED 
(
	[Cpid] ASC
)
*/