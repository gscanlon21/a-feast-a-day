using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Microbiome;

[Table("Food_Bacteria")]
public class FoodBacteria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FoodId { get; set; }

    public string? Description { get; set; }
}
