using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

class GutClubTaxonSets
{
    [Key, Required, Column(Order = 0)]
    public string Scope { get; set; } = string.Empty;

    [Key, Required, Column(Order = 1)]
    public int Taxon { get; set; }
}
