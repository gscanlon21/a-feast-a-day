using Core.Models.Newsletter;
using Core.Models.Recipe;
using Data.Entities.Newsletter;
using Data.Models.Newsletter;
using Data.Query;

namespace Data.Repos;

public partial class NewsletterRepo
{
    /// <summary>
    /// Creates a new instance of the newsletter and saves it.
    /// </summary>
    internal async Task<UserFeast> CreateAndAddNewsletterToContext(FeastContext newsletterContext, IList<QueryResults> recipes)
    {
        var newsletter = new UserFeast(newsletterContext.Date, newsletterContext);
        newsletter.UserFeastRecipes.AddRange(ConvertToUserFeastRecipes(newsletter, recipes));

        _context.UserFeasts.Add(newsletter);
        await _context.SaveChangesAsync();
        return newsletter;
    }

    public IEnumerable<UserFeastRecipe> ConvertToUserFeastRecipes(UserFeast newsletter, IList<QueryResults> recipes)
    {
        for (var i = 0; i < recipes.Count; i++)
        {
            var recipe = recipes[i];
            // Ignoring base preps here because
            // ... those may be scaled with other preps.
            if (recipe.Section == Section.Prep)
            {
                continue;
            }

            // NOTE: Base recipes should be unique and shouldn't include duplicates.
            yield return new UserFeastRecipe(newsletter, recipe, i)
            {
                UserFeastRecipeIngredients = recipe.RecipeIngredients
                    .Where(ri => ri.Type == RecipeIngredientType.Ingredient)
                    .Select(ri => new UserFeastRecipeIngredient(ri)).ToList(),
            };

            // Using the recipe's prep recipes instead of the prep section recipes so that we can
            // ... swap recipes with their preps even if they were scaled with other preps.
            foreach (var prepRecipe in recipe.PrepRecipes)
            {
                // Order doesn't matter because prep recipes are always requeryed from main recipes.
                yield return new UserFeastRecipe(newsletter, prepRecipe.Key, i)
                {
                    ParentRecipeId = recipe.Recipe.Id,
                    UserFeastRecipeIngredients = prepRecipe.Key.RecipeIngredients
                        .Where(ri => ri.Type == RecipeIngredientType.Ingredient)
                        .Select(ri => new UserFeastRecipeIngredient(ri)).ToList(),
                };
            }
        }
    }
}
