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
        public static readonly Person PersonDefault = Person.Adult;

        public const int CaloriesPerDayMin = 1500;
        public const int CaloriesPerDayDefault = 2000;
        public const int CaloriesPerDayMax = 3000;

        public const int WeightMin = 50;
        public const int WeightDefault = 75;
        public const int WeightMax = 150;
    }

    public UserFamily() { }

    public UserFamily(User user)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required]
    public Person Person { get; init; } = Consts.PersonDefault;

    [Range(Consts.WeightMin, Consts.WeightMax)]
    public int Weight { get; init; } = Consts.WeightDefault;

    [Range(Consts.CaloriesPerDayMin, Consts.CaloriesPerDayMax)]
    public int CaloriesPerDay { get; init; } = Consts.CaloriesPerDayDefault;

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFamilies))]
    public virtual User User { get; private init; } = null!;

    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserFamily other
        && other.Id == Id;

    public class PersonComparer : IEqualityComparer<UserFamily>
    {
        public int GetHashCode(UserFamily e) => HashCode.Combine(e.Person);
        public bool Equals(UserFamily? a, UserFamily? b)
            => a?.Person == b?.Person;
    }
}