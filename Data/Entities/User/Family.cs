using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_family")]
public class UserFamily
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private init; }

    public Person Person { get; init; }

    public int Weight { get; init; }

    public int CaloriesPerDay { get; init; }

    [NotMapped]
    public bool Hide { get; set; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserFamilies))]
    public virtual User User { get; private init; } = null!;
}
