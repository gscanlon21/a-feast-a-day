using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("probiotic_pubmed_sellers")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticPubMedSellers
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[ProbioticPubMedSellers](
	[psid] [int] NOT NULL,
	[SellerName] [varchar](100) NOT NULL,
	[SellerUtl] [varchar](255) NOT NULL,
	[ProId] [int] NULL,
 CONSTRAINT [PK_ProbioticPubMedSellers] PRIMARY KEY CLUSTERED 
(
	[psid] ASC,
	[SellerName] ASC
)
*/