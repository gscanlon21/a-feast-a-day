using Core.Models.User;

namespace Data.Query.Options;

public class AllergenOptions : IOptions
{
    public AllergenOptions() { }

    public AllergenOptions(Allergy? allergy)
    {
        Allery = allergy;
    }

    public Allergy? Allery { get; set; }
}
