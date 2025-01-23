using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("citation_logic")]
[DebuggerDisplay("{Name,nq}")]
public class CitationLogic
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}


/*
CREATE TABLE [dbo].[CitationLogic](
	[Logic] [varchar](1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CitationLogic] PRIMARY KEY CLUSTERED 
(
	[Logic] ASC
)
*/