using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;

[Table("modifier2")]
[DebuggerDisplay("{Name,nq}")]
public class Modifier2
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*CREATE TABLE [dbo].[Modifier2](
	[Mid2] [int] IDENTITY(1,1) NOT NULL,
	[Modifier_old] [nvarchar](255) NOT NULL,
	[Modifier2]  AS ([LatinName]+isnull((' {'+[CommonName])+'}','')),
	[LatinName] [nvarchar](2550) NULL,
	[CommonName] [nvarchar](50) NULL,
	[DrugNames] [nvarchar](max) NOT NULL,
	[MType] [varchar](1) NOT NULL,
	[Exclude] [bit] NOT NULL,
	[Lactose] [bit] NOT NULL,
	[Histamine] [bit] NOT NULL,
	[Taxon] [int] NULL,
	[Antihistamine] [bit] NULL,
	[DosageUrl] [varchar](50) NULL,
	[Url]  AS ('https://microbiomeprescription.com/library/modifier?mid2='+CONVERT([varchar](11),[Mid2])),
	[Dosage] [varchar](100) NULL,
	[Synthetic] [bit] NULL,
	[mpnId] [int] NULL,
	[caution] [nvarchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[External] [bit] NOT NULL,
	[Verified] [bit] NOT NULL,
	[de] [nvarchar](255) NULL,
	[es] [nvarchar](255) NULL,
	[da] [nvarchar](255) NULL,
	[se] [nvarchar](255) NULL,
	[cy] [nvarchar](255) NULL,
	[it] [nvarchar](255) NULL,
	[fr] [nvarchar](255) NULL,
	[Biofilm] [bit] NOT NULL,
 CONSTRAINT [PK_Modifier2] PRIMARY KEY CLUSTERED 
(
	[Mid2] ASC
)*/