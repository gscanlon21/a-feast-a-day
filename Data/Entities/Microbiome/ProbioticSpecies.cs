using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("probiotic_species")]
[DebuggerDisplay("{Name,nq}")]
public class ProbioticSpecies
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[ProbioticSpecies](
	[ProSpeciesId] [int] IDENTITY(1,1) NOT NULL,
	[SpeciesName] [varchar](255) NOT NULL,
	[Mid2] [int] NOT NULL,
	[Persists] [bit] NOT NULL,
	[NotHistamineProducer] [bit] NOT NULL,
	[HistamineProducer] [bit] NOT NULL,
	[LacticAcidProducer] [bit] NULL,
	[DLacticAcid] [bit] NULL,
	[LLacticAcid] [bit] NULL,
	[BalancedLacticAcid] [bit] NULL,
	[Bacteremia] [bit] NULL,
	[Taxon] [int] NULL,
	[GABA] [bit] NULL,
	[Features] [nvarchar](max) NULL,
 CONSTRAINT [PK_ProbioticSpecies] PRIMARY KEY CLUSTERED 
(
	[ProSpeciesId] ASC
)*/