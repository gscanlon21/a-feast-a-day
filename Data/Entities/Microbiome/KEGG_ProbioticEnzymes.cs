using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

internal class KEGG_ProbioticEnzymes
{
    [Required]
    [Key, Column(Order = 0)]
    public string ECKey { get; set; }

    [Required]
    [Key, Column(Order = 1)]
    public int Taxon { get; set; }

    public double? Cnt { get; set; }
}

