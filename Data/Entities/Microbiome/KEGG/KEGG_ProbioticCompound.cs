using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome.KEGG;

public class KEGG_ProbioticCompound
{
    [Key, Column(Order = 0)]
    [Required]
    public string CPID { get; set; } = string.Empty;

    [Key, Column(Order = 1)]
    [Required]
    public int Taxon { get; set; }

    public double? Cnt { get; set; }
}

