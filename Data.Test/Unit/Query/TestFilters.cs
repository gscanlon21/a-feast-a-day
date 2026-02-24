using Core.Code.Extensions;
using Core.Models.Recipe;
using Data.Entities.Ingredients;
using Data.Entities.Recipes;
using Data.Query;
using Data.Test.Code;
using Microsoft.EntityFrameworkCore;

namespace Data.Test.Unit.Query;

[TestClass]
public class TestFilters : RealDatabase
{
    private class TestRecipeCombo : IRecipeCombo
    {
        public Recipe Recipe { get; init; } = null!;
        public IList<Nutrient> Nutrients { get; init; } = null!;
    }

    private IQueryable<IRecipeCombo>? Query { get; set; } = null!;

    [TestInitialize]
    public async Task Init()
    {
        Query = (await Context.Recipes.AsNoTracking()
            .Select(v => new TestRecipeCombo()
            {
                Recipe = v,
                Nutrients = v.RecipeIngredients.SelectMany(ri => ri.Ingredient.Nutrients).ToList()
            })
            .ToListAsync())
            .AsQueryable();
    }

    [TestMethod]
    public async Task FilterEquipment_ReturnsFiltered()
    {
        foreach (var filter in EnumExtensions.GetNotNoneValues<Equipment>())
        {
            var results = Filters.FilterEquipment(Query!, filter).Where(r => r.Recipe.Instructions.All(i => i.Equipment != Equipment.None)).ToList();
            Assert.IsTrue(results.All(r => r.Recipe.Instructions.All(i => filter.HasFlag(i.Equipment))));
        }
    }
}