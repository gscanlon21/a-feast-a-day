namespace Data.Entities.Microbiome;

class Sample_IndexRatios
{
}

/*CREATE TABLE [dbo].[Sample_IndexRatios](
	[sequenceId] [int] NOT NULL,
	[IndexName] [varchar](50) NOT NULL,
	[AValue] [float] NULL,
	[Percentile] [numeric](3, 1) NULL,
 CONSTRAINT [PK_Sample_IndexRatios] PRIMARY KEY CLUSTERED 
(
	[sequenceId] ASC,
	[IndexName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]*/