namespace Data.Entities.Microbiome;

internal class Users
{
}



/*
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[SequenceId] [int] NOT NULL,
	[sampling_time] [smalldatetime] NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[Person] [nvarchar](max) NOT NULL,
	[Source] [varchar](20) NOT NULL,
	[SourceId] [int] NULL,
	[SampleName] [varchar](max) NOT NULL,
	[ClinicEmail] [varchar](max) NULL,
	[CustomSelection] [xml] NULL,
	[MatchSampleId] [int] NOT NULL,
	[SymptomHealth] [float] NULL,
	[ConditionHealth] [float] NULL,
	[_Title]  AS (((((((([source]+':')+CONVERT([nvarchar](10),[sampling_time],(126)))+'  ')+[person])+' ')+case when [Biofilmcount]>(600) then N' 🛑' when [Biofilmcount]>(50) then N' ⚠️' else N'' end)+case when [dlacticcount]>(270) then N' ⚗️' else N'' end)+case when [histaminecount]>(15) then N' 🤧' when [histaminecount]>(1000) then N' 🤢' else N'' end),
	[Hash] [float] NULL,
	[Custom] [int] NULL,
	[TaxonCount] [int] NULL,
	[Symptoms] [int] NULL,
	[SameSymptomsAs] [int] NULL,
	[FastQId] [int] NULL,
	[Chi2] [float] NULL,
	[Chi2AdjPercentile] [float] NULL,
	[SymptomPercent]  AS (CONVERT([int],(100.0)*((1.0)-[SymptomHealth]))),
	[ConditionPercent]  AS (CONVERT([int],(100.0)*((1.0)-[ConditionHealth]))),
	[Consultant] [varchar](255) NULL,
	[PersonEmail] [varchar](255) NULL,
	[UploadFileName] [varchar](max) NULL,
	[BiomeSightId] [int] NULL,
	[RecalcDate] [datetime] NULL,
	[Shannon] [float] NULL,
	[Simpson] [float] NULL,
	[Chao] [float] NULL,
	[ShannonRank] [float] NULL,
	[SimpsonRank] [float] NULL,
	[ChaoRank] [float] NULL,
	[antiinflammatory] [float] NOT NULL,
	[PdfEmail] [int] NULL,
	[histamine] [float] NOT NULL,
	[butyrate] [float] NOT NULL,
	[IsUnique] [bit] NOT NULL,
	[JasonCount] [int] NULL,
	[OralBacteriaCount] [int] NULL,
	[OralTaxaCount] [int] NULL,
	[KeySymptomBacteriaCnt] [int] NULL,
	[HealthPredictors] [int] NULL,
	[BioFilmCount] [int] NOT NULL,
	[DLacticCount] [int] NOT NULL,
	[HistamineCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)

GO*/