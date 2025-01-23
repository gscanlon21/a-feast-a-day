using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("not_healthy_predictor")]
[DebuggerDisplay("{Name,nq}")]
public class NotHealthyPredictor
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[NotHealthyPredictor](
	[Taxon] [int] NOT NULL,
	[Tax_name] [varchar](200) NOT NULL,
	[Health] [float] NOT NULL,
	[Unhealthy] [float] NOT NULL,
	[Low] [float] NULL,
	[High] [float] NULL,
 CONSTRAINT [PK_NotHealthyPredictor] PRIMARY KEY CLUSTERED 
(
	[Tax_name] ASC
)
*/