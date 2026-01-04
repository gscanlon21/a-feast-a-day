using Core.Models.Newsletter;

namespace Data.Query.Options;

public class SelectionOptions : IOptions
{
    public SelectionOptions() { }

    /// <summary>
    /// Orders the recipes in a random order 
    /// instead of using the last seen date.
    /// </summary>
    public bool Randomized { get; set; } = false;

    public bool IncludeSkippedRecipes { get; set; } = false;

    /// <summary>
    /// Recipes that already exist as prep recipes and should be scaled if chosen again.
    /// </summary>
    public HashSet<QueryResults> PrepRecipes { get; set; } = [];

    /// <summary>
    /// Recipes that already exist as prep recipes and should be scaled if chosen again.
    /// </summary>
    internal void AddScaleRecipes(IEnumerable<QueryResults>? recipes)
    {
        if (recipes != null)
        {
            PrepRecipes = recipes.Where(r => r.Section == Section.Prep).ToHashSet();
        }
    }

    public bool HasData() => true;
}
