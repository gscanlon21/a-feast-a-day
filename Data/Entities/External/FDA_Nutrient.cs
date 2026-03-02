using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.External;

[Table("fda_nutrient")]
public class FDA_Nutrient
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; init; }

    public string Name { get; set; } = null!;

    public string UnitName { get; set; } = null!;

    public double NutrientNbr { get; set; }

    public double Rank { get; set; }
}