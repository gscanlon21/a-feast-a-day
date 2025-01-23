using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("probiotic_strains")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticStrains
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
 CREATE TABLE [dbo].[ProbioticStrains](
	[ProSpeciesId] [int] NOT NULL,
	[ParentTaxon] [int] NULL,
	[Taxon] [int] NULL
)
 */