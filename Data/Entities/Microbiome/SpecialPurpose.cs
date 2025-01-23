using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("special_purpose")]
[DebuggerDisplay("{Name,nq}")]
public class SpecialPurpose
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


/*
CREATE TABLE [dbo].[SpecialPurpose](
	[Purpose] [varchar](50) NOT NULL,
	[MoreInfo] [varchar](max) NULL,
	[CfsLink] [varchar](max) NULL,
	[SPid] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_SpecialPurpose] PRIMARY KEY CLUSTERED 
(
	[SPid] ASC
)
*/