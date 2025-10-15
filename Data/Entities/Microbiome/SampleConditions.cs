using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("sample_conditions")]
[DebuggerDisplay("{Name,nq}")]
public class SampleConditions
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}



/*
CREATE TABLE [dbo].[Sample_Conditions](
	[SampleId] [int] NOT NULL,
	[Condid] [int] NOT NULL,
	[Percentage] [int] NULL,
 CONSTRAINT [PK_Sample_Conditions] PRIMARY KEY CLUSTERED 
(
	[SampleId] ASC,
	[Condid] ASC
)
*/