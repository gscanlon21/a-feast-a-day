using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("blood_feature")]
[DebuggerDisplay("{Name,nq}")]
public class BloodFeature
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[BloodFeature](
	[BloodId] [int] IDENTITY(1,1) NOT NULL,
	[ClinicalFeature] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
*/