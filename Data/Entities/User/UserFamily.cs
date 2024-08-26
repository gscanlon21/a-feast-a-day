using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_family")]
public class UserFamily
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

    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserFamily() { }

    public UserFamily(User user)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public Person Person { get; init; }

    [Range(Consts.WeightMin, Consts.WeightMax)]
    public int Weight { get; init; } = Consts.WeightDefault;

    [Range(Consts.CaloriesPerDayMin, Consts.CaloriesPerDayMax)]
    public int CaloriesPerDay { get; init; } = Consts.CaloriesPerDayDefault;

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFamilies))]
    public virtual User User { get; private init; } = null!;
}
