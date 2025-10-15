using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


[Table("research_summary")]
[DebuggerDisplay("{Name,nq}")]
public class ProcessingStatus
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[ProcessingStatus](
	[ProcessKey] [nvarchar](50) NOT NULL,
	[LastId] [int] NOT NULL,
 CONSTRAINT [PK_ProcessingStatus] PRIMARY KEY CLUSTERED 
(
	[ProcessKey] ASC
)
*/