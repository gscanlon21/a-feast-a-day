using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("probiotics")]
[DebuggerDisplay("{Name,nq}")]
public class Probiotics
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[Probiotics](
	[ProId] [int] IDENTITY(1,1) NOT NULL,
	[ProbioticName] [varchar](255) NOT NULL,
	[url]  AS ('/Library/ProbioticDetails?ProId='+CONVERT([varchar](11),[ProId])),
	[SpeciesCount] [float] NULL,
	[Canada] [bit] NOT NULL,
	[USA] [bit] NOT NULL,
 CONSTRAINT [PK_Probiotics] PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)*/