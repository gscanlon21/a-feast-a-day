using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

public class Food_Taxon
{
    [Key, Column(Order = 0)]
    [Required]
    public int FoodId { get; set; }

    [Key, Column(Order = 1)]
    [Required]
    public double TaxonID { get; set; }

    public double? Weight { get; set; }

    public int? Taxon { get; set; }
}

