namespace Data.Entities.Microbiome;

internal class HealthProfiles
{
}

/*
 
CREATE TABLE [dbo].[HealthProfiles](
	[Source] [varchar](20) NOT NULL,
	[Taxon] [int] NOT NULL,
	[LowValue] [float] NOT NULL,
	[HighValue] [float] NOT NULL,
 CONSTRAINT [PK_HealthProfiles] PRIMARY KEY CLUSTERED 
(
	[Source] ASC,
	[Taxon] ASC
) 

 */