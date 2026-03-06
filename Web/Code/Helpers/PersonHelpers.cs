
namespace Web.Code.Helpers;

public static class PersonHelpers
{
    /// <summary>
    /// Since signups are only for people 18+.
    /// </summary>
    public static readonly Person[] SignupPeople =
    [
        Person.Male_19_30_Years, Person.Female_19_30_Years, Person.Pregnant_19_30_Years, Person.Lactating_19_30_Years,
        Person.Male_31_50_Years, Person.Female_31_50_Years, Person.Pregnant_31_50_Years, Person.Lactating_31_50_Years,
        Person.Male_51_70_Years, Person.Female_51_70_Years, Person.Male_71_XX_Years, Person.Female_71_XX_Years
    ];
}
