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
        [IngredientGroup.Beans] = 10..20, 
        [IngredientGroup.Dairy] = 10..20, 
        [IngredientGroup.Eggs] = 10..20, 
        [IngredientGroup.Fish] = 10..20, 
        [IngredientGroup.Fruits] = 10..20, 
        [IngredientGroup.Nuts] = 10..20, 
        [IngredientGroup.Poultry] = 10..20, 
        [IngredientGroup.Seeds] = 10..20, 
        [IngredientGroup.Vegetables] = 10..20, 
        [IngredientGroup.WholeGrains] = 10..20,
        [IngredientGroup.UnsaturatedFats] = 5..10,
        [IngredientGroup.VegetableOils] = 5..10,
        [IngredientGroup.Tofu] = 0..10,
        [IngredientGroup.Butter] = 0..5, 
        [IngredientGroup.RedMeat] = 0..5, 
        [IngredientGroup.RefinedGrains] = 5..5, 
        [IngredientGroup.Sweet] = 0..5, 
    };
}
