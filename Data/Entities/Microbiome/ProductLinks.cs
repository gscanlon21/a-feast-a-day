using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Data.Entities.Microbiome;


/// <summary>
/// Recipes listed on the website.
/// </summary>
[Table("product_links")]
[DebuggerDisplay("{Name,nq}")]
public class ProductLinks
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is Salicylate other
        && other.Id == Id;
}

/*
CREATE TABLE [dbo].[ProductLinks](
	[Mod2] [int] NOT NULL,
	[Country] [varchar](2) NOT NULL,
	[Uri] [varchar](255) NOT NULL,
	[Type] [varchar](10) NOT NULL,
	[ImageUri] [varchar](255) NULL,
	[ImageCaption] [varchar](max) NULL,
 CONSTRAINT [PK_ProductLinks] PRIMARY KEY CLUSTERED 
(
	[Mod2] ASC,
	[Country] ASC,
	[Uri] ASC
)
*/