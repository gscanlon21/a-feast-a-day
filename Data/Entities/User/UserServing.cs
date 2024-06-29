using Core.Consts;
using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;


[Table("user_serving")]
public class UserServing
{
    public Section Section { get; init; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserServings))]
    public virtual User User { get; private init; } = null!;

    [Range(UserConsts.WeeklyServingsMin, UserConsts.WeeklyServingsMax)]
    public int Count { get; set; }

    [Range(UserConsts.AtLeastXUniqueNutrientsPerRecipeMin, UserConsts.AtLeastXUniqueNutrientsPerRecipeMax)]
    public int AtLeastXUniqueNutrientsPerRecipe { get; set; } = UserConsts.AtLeastXUniqueNutrientsPerRecipeDefault;

    [Range(UserConsts.AtLeastXServingsPerRecipeMin, UserConsts.AtLeastXServingsPerRecipeMax)]
    public int AtLeastXServingsPerRecipe { get; set; } = UserConsts.AtLeastXServingsPerRecipeDefault;

    /// <summary>
    /// The volume each muscle group should be exposed to each week.
    /// </summary>
    public static readonly IDictionary<Section, int> DefaultServings = new Dictionary<Section, int>
    {
        [Section.Breakfast] = 5,
        [Section.Dessert] = 2,
        [Section.Dinner] = 7,
        [Section.Lunch] = 7,
        [Section.Sides] = 4,
        [Section.Snacks] = 4,
    };
}
