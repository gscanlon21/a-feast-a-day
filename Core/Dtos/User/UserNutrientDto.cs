using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Dtos.User;

public class UserNutrientDto
{
    public Nutrients Nutrient { get; init; }

    public int UserId { get; init; }

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);
}
