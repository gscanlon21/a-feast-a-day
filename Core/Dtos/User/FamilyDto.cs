using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Dtos.User;


[Table("user_family")]
public class UserFamilyDto
{
    public static class Consts
    {
        public const int CaloriesPerDayMin = 1500;
        public const int CaloriesPerDayDefault = 2000;
        public const int CaloriesPerDayMax = 3000;

        public const int WeightMin = 50;
        public const int WeightDefault = 75;
        public const int WeightMax = 150;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    public Person Person { get; init; }

    [Range(Consts.WeightMin, Consts.WeightMax)]
    public int Weight { get; init; } = Consts.WeightDefault;

    [Range(Consts.CaloriesPerDayMin, Consts.CaloriesPerDayMax)]
    public int CaloriesPerDay { get; init; } = Consts.CaloriesPerDayDefault;

    public int UserId { get; init; }

    [JsonIgnore]
    public virtual UserDto User { get; init; } = null!;
}
