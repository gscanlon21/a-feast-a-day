using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("lab_sample_bacteria")]
[DebuggerDisplay("{Name,nq}")]
public class LabSampleBacteria
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[LabSampleBacteria](
	[LabSampleId] [int] NOT NULL,
	[Taxon] [int] NOT NULL,
	[Shift] [float] NOT NULL,
 CONSTRAINT [PK_LabSampleBacteria] PRIMARY KEY CLUSTERED 
(
	[LabSampleId] ASC,
	[Taxon] ASC
)
 * */