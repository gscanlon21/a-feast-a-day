using Core.Models.Newsletter;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

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

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; private init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserSections))]
    public virtual User User { get; private init; } = null!;

    [Range(UserConsts.SectionWeightMin, UserConsts.SectionWeightMax)]
    public int Weight { get; set; }

    [Range(UserConsts.AtLeastXNutrientsPerRecipeMin, UserConsts.AtLeastXNutrientsPerRecipeMax)]
    public int AtLeastXNutrientsPerRecipe { get; set; } = UserConsts.AtLeastXNutrientsPerRecipeDefault;

    /// <summary>
    /// The volume each section should be exposed to each week.
    /// </summary>
    public static readonly IDictionary<Section, int> DefaultWeight = new Dictionary<Section, int>
    {
        [Section.Breakfast] = 5,
        [Section.Dessert] = 2,
        [Section.Dinner] = 7,
        [Section.Lunch] = 7,
        [Section.Sides] = 4,
        [Section.Snacks] = 4,
    };
}
