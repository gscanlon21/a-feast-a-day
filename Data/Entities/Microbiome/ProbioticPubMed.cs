using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("probiotic_pubmed")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticPubMed
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[ProbioticPubMed](
	[psid] [int] IDENTITY(1,1) NOT NULL,
	[ProbioticSpecies] [varchar](100) NOT NULL,
	[SellerName] [varchar](100) NOT NULL,
	[SellerUtl] [varchar](255) NOT NULL,
	[Taxon] [int] NULL,
	[SearchKey] [varchar](40) NULL,
	[mid2] [int] NULL,
 CONSTRAINT [PK_ProbioticPubMed] PRIMARY KEY CLUSTERED 
(
	[psid] ASC
)
*/