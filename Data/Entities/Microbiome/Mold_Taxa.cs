using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class Mold_Taxa
{
    [Key, Required]
    public int Taxon { get; set; }
}

