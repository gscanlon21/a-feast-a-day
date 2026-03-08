using Core.Models.Newsletter;
using Data.Entities.Users;
using Data.Models.Newsletter;
using Data.Query;
using Data.Query.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos;

public partial class NewsletterRepo
{
    internal async Task<IList<QueryResults>> GetBreakfastRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var breakfastServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Breakfast) ?? new UserSection(Section.Breakfast);
        if (breakfastServing.Weight == 0) return [];

        var scale = breakfastServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Breakfast)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = breakfastServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetLunchRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var lunchServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Lunch) ?? new UserSection(Section.Lunch);
        if (lunchServing.Weight == 0) return [];

        var scale = lunchServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Lunch)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = lunchServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDinnerRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dinnerServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Dinner) ?? new UserSection(Section.Dinner);
        if (dinnerServing.Weight == 0) return [];

        var scale = dinnerServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Dinner)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dinnerServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSideRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var sideServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Sides) ?? new UserSection(Section.Sides);
        if (sideServing.Weight == 0) return [];

        var scale = sideServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Sides)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = sideServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetSnackRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var snackServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Snacks) ?? new UserSection(Section.Snacks);
        if (snackServing.Weight == 0) return [];

        var scale = snackServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Snacks)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = snackServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDrinkRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var drinkServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Drinks) ?? new UserSection(Section.Drinks);
        if (drinkServing.Weight == 0) return [];

        var scale = drinkServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Drinks)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = drinkServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }

    internal async Task<IList<QueryResults>> GetDessertRecipes(FeastContext newsletterContext, IEnumerable<QueryResults>? exclude = null)
    {
        var dessertServing = newsletterContext.User.UserSections.FirstOrDefault(us => us.Section == Section.Dessert) ?? new UserSection(Section.Dessert);
        if (dessertServing.Weight == 0) return [];

        var scale = dessertServing.Weight / (double)newsletterContext.User.UserSections.Sum(us => us.Weight);
        return await new UserQueryBuilder(newsletterContext.User, Section.Dessert)
            .WithEquipment(newsletterContext.User.Equipment)
            .WithNutrients(NutrientTargetsContextBuilder
                .WithNutrients(newsletterContext, NutrientHelpers.All, newsletterContext.User.DataSource)
                .AdjustNutrientTargets(scale: scale), options =>
                {
                    options.AtLeastXNutrientsPerRecipe = dessertServing.AtLeastXNutrientsPerRecipe;
                })
            .WithExcludeRecipes(x =>
            {
                x.AddExcludeRecipes(exclude);
            })
            .WithSelectionOptions(options =>
            {
                options.IncludeSkippedRecipes = newsletterContext.IsBackfill;
                options.Randomized = newsletterContext.IsBackfill;
                // Scale serving-adjustable prep recipes.
                options.AddScaleRecipes(exclude);
            })
            .Build()
            .Query(_serviceScopeFactory);
    }
}
