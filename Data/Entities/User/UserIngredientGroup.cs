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
    /// </summary>
    public static readonly IDictionary<IngredientGroup, Range> MuscleTargets = new Dictionary<IngredientGroup, Range>
    {
        [IngredientGroup.Eggs] = 4..8,
        [IngredientGroup.Fruits] = 4..8,
        [IngredientGroup.Vegetables] = 4..8,
        [IngredientGroup.Beans] = 2..4,
        [IngredientGroup.Dairy] = 2..4,
        [IngredientGroup.Fish] = 2..4,
        [IngredientGroup.Nuts] = 2..4,
        [IngredientGroup.Poultry] = 2..4,
        [IngredientGroup.Seeds] = 2..4,
        [IngredientGroup.WholeGrains] = 2..4,
        [IngredientGroup.UnsaturatedFats] = 2..4,
        [IngredientGroup.VegetableOils] = 2..4,
        [IngredientGroup.Tofu] = 0..4,
        [IngredientGroup.Butter] = 0..2,
        [IngredientGroup.RedMeat] = 0..2,
        [IngredientGroup.RefinedGrains] = 0..2,
        [IngredientGroup.Sweet] = 0..2,
    };
}
