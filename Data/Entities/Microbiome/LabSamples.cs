using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("lab_samples")]
[DebuggerDisplay("{Name,nq}")]
public class LabSamples
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[LabSamples](
	[LabSampleId] [int] IDENTITY(1,1) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[LabTitle] [nvarchar](max) NOT NULL,
	[LabCode] [varchar](10) NOT NULL,
	[LabDate] [varchar](20) NULL,
	[LabNotes] [nvarchar](max) NULL,
	[SampleId] [int] NULL,
	[PDFEmail] [int] NULL,
 CONSTRAINT [PK_LabSamples] PRIMARY KEY CLUSTERED 
(
	[LabSampleId] ASC
)
*/