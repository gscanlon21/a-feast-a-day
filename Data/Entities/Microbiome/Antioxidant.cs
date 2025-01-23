using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("antioxidant")]
[DebuggerDisplay("{Name,nq}")]
public class Antioxidant
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[Antioxidant](
	[Food] [varchar](100) NOT NULL,
	[mmolPer100g] [float] NOT NULL,
	[Mid2] [int] NULL,
	[Cid] [int] NULL,
	[Aid] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Antioxidant] PRIMARY KEY CLUSTERED 
(
	[Food] ASC
)
*/