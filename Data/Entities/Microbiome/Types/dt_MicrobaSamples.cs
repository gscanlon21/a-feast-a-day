namespace Data.Entities.Microbiome.Types;

public class dt_MicrobaSamples
{
}

/*CREATE TYPE [dbo].[dt_MicrobaSamples] AS TABLE(
	[sampleId] [int] NULL,
	[Phylum] [varchar](100) NOT NULL,
	[Family] [varchar](100) NULL,
	[Genus] [varchar](100) NULL,
	[Species] [varchar](100) NULL,
	[Abundance] [float] NOT NULL DEFAULT ((0)),
	[RangeLow] [float] NULL DEFAULT ((0)),
	[RangeHigh] [float] NULL DEFAULT ((0))
)*/