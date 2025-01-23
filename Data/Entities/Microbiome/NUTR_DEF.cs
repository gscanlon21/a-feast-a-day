using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("nutr_def")]
[DebuggerDisplay("{Name,nq}")]
public class NUTR_DEF
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[NUTR_DEF](
	[Nutr_no] [nvarchar](4) NOT NULL,
	[Nutrient name] [nvarchar](255) NULL,
	[Flav_Class] [nvarchar](250) NULL,
	[Tagname] [nvarchar](20) NULL,
	[Unit] [nvarchar](255) NULL,
	[MastCellStabilizer] [bit] NULL,
 CONSTRAINT [PK_NUTR_DEF] PRIMARY KEY CLUSTERED 
(
	[Nutr_no] ASC
)
*/