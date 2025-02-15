namespace Data.Entities.Microbiome;

internal class Cytokines
{
}

/*CREATE TABLE [dbo].[Cytokines](
	[CyId] [int] IDENTITY(1,1) NOT NULL,
	[Cytokine] [nvarchar](100) NOT NULL,
	[AltName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[AcuteInflammation] [bit] NULL,
	[ChronicInflammation] [bit] NULL,
	[CellularResponse] [bit] NULL,
	[Interferons] [bit] NULL,
	[TransformingGrowthFactor] [bit] NULL,
 CONSTRAINT [PK_Cytokines] PRIMARY KEY CLUSTERED 
(
	[CyId] ASC
)*/