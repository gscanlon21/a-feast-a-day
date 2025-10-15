using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("probiotic_mixture")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticMixture
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
 CREATE TABLE [dbo].[ProbioticMixture](
	[ProId] [int] NOT NULL,
	[ProSpeciesId] [int] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_ProbioticMixture] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC,
	[ProSpeciesId] ASC
)
 */