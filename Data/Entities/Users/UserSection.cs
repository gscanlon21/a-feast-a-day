using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.Users;

[Table("user_section")]
public class UserSection
{
    [Obsolete("Public parameterless constructor required for model binding.", error: true)]
    public UserSection() { }

    public UserSection(Section section)
    {
        Section = section;
    }

    public UserSection(User user, Section section) : this(section)
    {
        // Don't set User, so that EF Core doesn't add/update User.
        UserId = user.Id;
    }

    public Section Section { get; private init; }

    [ForeignKey(nameof(Users.User.Id))]
    public int UserId { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Users.User.UserSections))]
    public virtual User User { get; private init; } = null!;

    [Range(UserConsts.SectionWeightMin, UserConsts.SectionWeightMax)]
    public int Weight { get; set; }

    [Range(UserConsts.AtLeastXNutrientsPerRecipeMin, UserConsts.AtLeastXNutrientsPerRecipeMax)]
    public int AtLeastXNutrientsPerRecipe { get; set; } = UserConsts.AtLeastXNutrientsPerRecipeDefault;

    /// <summary>
    /// The volume each section should be exposed to each week.
    /// 
    /// <para>
    /// Deserts and Drinks are disabled by default:
    /// Deserts severly alter the nutrient targets.
    /// Drinks tend not to have enough nutrients.
    /// </para>
    /// </summary>
    public static readonly IDictionary<Section, int> DefaultWeight = new Dictionary<Section, int>
    {
        [Section.Breakfast] = 5,
        [Section.Lunch] = 6,
        [Section.Dinner] = 7,
        [Section.Sides] = 2,
        [Section.Snacks] = 1,
        [Section.Dessert] = 0,
        [Section.Drinks] = 0,
    };
}
