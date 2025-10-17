using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

internal class FoodTaxaName
{
    [Key]
    [Required]
    public int FoodId { get; set; }

    [Required]
    public string FoodName { get; set; } = string.Empty;
}

