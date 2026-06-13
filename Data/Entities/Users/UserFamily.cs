using Core.Models.Nutrients;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_family")]
[DebuggerDisplay("{Weight}kg {Person}: {CaloriesPerDay}/day")]
public class UserFamily
{
    public static class Consts
    {
        public const int WeightMin = 50;
        public const int WeightDefault = 75;
        public const int WeightMax = 150;

        public const int CaloriesPerDayMin = 1500;
        public const int CaloriesPerDayDefault = 2000;
        public const int CaloriesPerDayMax = 3000;
    }

    public UserFamily() { }

    public UserFamily(User user)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
    }

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    [Required, ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; private init; }

    [Required, Range(Consts.WeightMin, Consts.WeightMax)]
    public int Weight { get; init; } = Consts.WeightDefault;

    [Required, Range(Consts.CaloriesPerDayMin, Consts.CaloriesPerDayMax)]
    public int CaloriesPerDay { get; init; } = Consts.CaloriesPerDayDefault;

    [Required]
    public Person Person { get; init; }


    #region Navigation Properties

    [JsonIgnore, InverseProperty(nameof(Users.User.UserFamilies))]
    public virtual User User { get; private init; } = null!;

    #endregion


    public override int GetHashCode() => HashCode.Combine(Id);
    public override bool Equals(object? obj) => obj is UserFamily other
        && other.Id == Id;


    public class PersonComparer : IEqualityComparer<UserFamily>
    {
        public int GetHashCode(UserFamily e) => HashCode.Combine(e.Person);
        public bool Equals(UserFamily? a, UserFamily? b) => a?.Person == b?.Person;
    }
}