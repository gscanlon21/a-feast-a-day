using Core.Models.Newsletter;
using Data.Dtos.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query.Builders;

namespace Data.Repos;

public partial class NewsletterRepo
{
    internal async Task<List<RecipeDto>> GetBreakfastRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Breakfast)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithMuscleTargetsFromMuscleGroups(null)
                .AdjustMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Breakfast)?.Count
                    ?? UserServing.MuscleTargets[Section.Breakfast];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetLunchRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Lunch)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithMuscleTargetsFromMuscleGroups(null)
                .AdjustMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Lunch)?.Count
                    ?? UserServing.MuscleTargets[Section.Lunch];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            }).Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetDinnerRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Dinner)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithMuscleTargetsFromMuscleGroups(null)
                .AdjustMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Dinner)?.Count
                    ?? UserServing.MuscleTargets[Section.Dinner];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetSideRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Sides)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Sides)?.Count
                    ?? UserServing.MuscleTargets[Section.Sides];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetSnackRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Snacks)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Snacks)?.Count
                    ?? UserServing.MuscleTargets[Section.Snacks];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetDessertRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Dessert)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithServingsOptions(options =>
            {
                options.AtLeastXServingsPerRecipe = 2;
                options.WeeklyServings = newsletterContext.User.UserServings.FirstOrDefault(s => s.Section == Section.Dessert)?.Count
                    ?? UserServing.MuscleTargets[Section.Dessert];
            })
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory))
            .Select(r => new RecipeDto(r))
            .ToList();
    }
}
