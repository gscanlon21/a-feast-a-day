using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_ingredient_group")]
public class UserIngredientGroup
{
    public const int MuscleTargetMin = 0;

    public IngredientGroup Group { get; init; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserIngredientGroups))]
    public virtual User User { get; private init; } = null!;

    public int Start { get; set; }

    public int End { get; set; }

    [NotMapped]
    public Range Range => new(Start, End);

    /// <summary>
    /// The volume each muscle group should be exposed to each week.
    /// 
    /// ~24 per exercise.
    /// 
    /// https://www.bodybuilding.com/content/how-many-exercises-per-muscle-group.html
    /// 50-70 for minor muscle groups.
    /// 90-120 for major muscle groups.
    /// </summary>
    public static readonly IDictionary<IngredientGroup, Range> MuscleTargets = new Dictionary<IngredientGroup, Range>
    {
        [IngredientGroup.Beans] = 120..240, // Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.Butter] = 110..220, // Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.Dairy] = 100..200, // Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.Eggs] = 90..130, // Mega muscle.
        [IngredientGroup.Fish] = 80..120, // Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.Fruits] = 80..120, // Major muscle.
        [IngredientGroup.Nuts] = 80..120, // Major muscle.
        [IngredientGroup.Poultry] = 80..120, // Major muscle.
        [IngredientGroup.RedMeat] = 80..120, // Major muscle.
        [IngredientGroup.RefinedGrains] = 80..120, // Major muscle.
        [IngredientGroup.Seeds] = 70..110, // Major muscle.
        [IngredientGroup.Tofu] = 60..100, // Minor muscle. Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.UnsaturatedFats] = 60..100, // Minor muscle. Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.VegetableOils] = 60..100, // Minor muscle. Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.Vegetables] = 60..100, // Minor muscle. Type 1 (slow-twitch) muscle fibers, for endurance.
        [IngredientGroup.WholeGrains] = 60..100, // Minor muscle. Type 1 (slow-twitch) muscle fibers, for endurance.
    };
}
