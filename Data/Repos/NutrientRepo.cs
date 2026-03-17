using Data.Entities.Ingredients;
using Data.Entities.Nutrients;
using Microsoft.EntityFrameworkCore;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Data.Repos;

public class NutrientRepo
{
    private readonly CoreContext _context;

    public NutrientRepo(CoreContext context)
    {
        _context = context;
    }

    public async Task<IList<Ingredient>> GetIngredientsWithHealthCanadaData()
    {
        await _context.CanadaNutrients.Where(n => n.Ingredient!.IngredientAttr!.LastUpdated >= n.LastUpdated).ExecuteDeleteAsync();
        return await _context.Ingredients.AsNoTracking().AsSplitQuery()
            .Include(i => i.IngredientAttr).Include(i => i.CanadaNutrients)
            .Where(i => i.IngredientAttr!.HC_Id.HasValue)
            .ToListAsync();
    }

    public async Task<IList<Ingredient>> GetIngredientsWithFoodData()
    {
        await _context.USDANutrients.Where(n => n.Ingredient!.IngredientAttr!.LastUpdated >= n.LastUpdated).ExecuteDeleteAsync();
        return await _context.Ingredients.AsNoTracking().AsSplitQuery()
            .Include(i => i.IngredientAttr).Include(i => i.USDANutrients)
            .Where(i => i.IngredientAttr!.FDC_ID.HasValue)
            .ToListAsync();
    }

    public async Task UpdateNutrient(USDANutrient nutrient)
    {
        _context.USDANutrients.Update(nutrient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNutrientCa(HealthCanadaNutrient nutrient)
    {
        _context.CanadaNutrients.Update(nutrient);
        await _context.SaveChangesAsync();
    }

    public async Task InsertNewNutrients(List<USDANutrient> newNutrients)
    {
        foreach (var nutrient in newNutrients)
        {
            _context.USDANutrients.Add(nutrient);
        }

        await _context.SaveChangesAsync();
    }

    public async Task InsertCanadaNutrients(List<HealthCanadaNutrient> newNutrients)
    {
        foreach (var nutrient in newNutrients)
        {
            _context.CanadaNutrients.Add(nutrient);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<Dictionary<Nutrient, List<DietaryIntake>>> GetDietaryIntakeMap()
    {
        return await _context.Nutrients.AsNoTracking()
            .Include(n => n.DietaryIntakes!.OrderBy(di => di.Person))
            .ToDictionaryAsync(n => n, n => n.DietaryIntakes!.Where(di => Enum.IsDefined(di.Person)).ToList());
    }
}
