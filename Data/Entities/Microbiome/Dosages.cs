namespace Data.Entities.Microbiome;

internal class Dosages
{
}

/*CREATE TABLE [dbo].[Dosages](
	[DosageId] [int] IDENTITY(1,1) NOT NULL,
	[Mid2] [int] NOT NULL,
	[Cid] [int] NULL,
	[TrialName] [varchar](max) NULL,
	[TrialUrl] [varchar](255) NULL,
	[Units] [varchar](100) NOT NULL,
	[Dosage] [float] NOT NULL,
	[Effective] [bit] NULL,
	[Toxic] [bit] NULL,
 CONSTRAINT [PK_Dosages] PRIMARY KEY CLUSTERED 
(
	[DosageId] ASC,
	[Mid2] ASC
)*/