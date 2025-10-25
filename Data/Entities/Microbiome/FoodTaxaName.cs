using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Microbiome;

public class FoodTaxaName
{
    [Key]
    [Required]
    public int FoodId { get; set; }

    [Required]
    public string FoodName { get; set; } = string.Empty;
}

