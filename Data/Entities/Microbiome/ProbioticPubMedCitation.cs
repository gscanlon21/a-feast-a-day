using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("probiotic_pubmed_citation")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticPubMedCitation
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


/*
CREATE TABLE [dbo].[ProbioticPubMedCitation](
	[Pcid] [int] NOT NULL,
	[cid] [int] NOT NULL,
 CONSTRAINT [PK_ProbioticPubMedCitation] PRIMARY KEY CLUSTERED 
(
	[Pcid] ASC,
	[cid] ASC
)
*/