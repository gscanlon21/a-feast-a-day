using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("nut_val_cR")]
[DebuggerDisplay("{Name,nq}")]
public class NutValCR
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[Nut_Val_CR](
	[NDB_No] [nvarchar](5) NULL,
	[Nutrient name] [nvarchar](45) NULL,
	[Nutrr_no] [nvarchar](3) NULL,
	[xbar_adj] [float] NULL,
	[SE] [float] NULL,
	[N] [float] NULL,
	[Low] [real] NULL,
	[High] [real] NULL,
	[CC] [nvarchar](255) NULL
)
*/