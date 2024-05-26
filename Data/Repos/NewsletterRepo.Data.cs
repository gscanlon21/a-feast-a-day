using Core.Models.Newsletter;
using Data.Dtos.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Data.Query.Builders;

namespace Data.Repos;

public partial class NewsletterRepo
{
    internal async Task<List<RecipeDto>> GetDinnerRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Dinner)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithExcludeExercises(x => 
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory, take: 2))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetLunchRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Lunch)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            }).Build()
            .Query(serviceScopeFactory, take: 2))
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
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory, take: 2))
            .Select(r => new RecipeDto(r))
            .ToList();
    }

    internal async Task<List<RecipeDto>> GetBreakfastRecipes(WorkoutContext newsletterContext, IEnumerable<RecipeDto>? exclude = null)
    {
        return (await new QueryBuilder(Section.Breakfast)
            .WithUser(newsletterContext.User)
            .WithIngredientGroups(MuscleTargetsBuilder
                .WithMuscleGroups(newsletterContext, UserIngredientGroup.MuscleTargets.Select(mt => mt.Key).ToList())
                .WithoutMuscleTargets())
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory, take: 2))
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
            .WithExcludeExercises(x =>
            {
                x.AddExcludeExercises(exclude?.Select(r => r.Recipe));
            })
            .Build()
            .Query(serviceScopeFactory, take: 2))
            .Select(r => new RecipeDto(r))
            .ToList();
    }
}
