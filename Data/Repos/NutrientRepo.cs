using Data.Entities.Ingredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repos;

public class NutrientRepo
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NutrientRepo(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IList<Ingredient>> GetIngredientsWithFoodData()
    {
        return await _context.Ingredients.AsNoTracking().AsSplitQuery()
            .Include(i => i.IngredientAttr).Include(i => i.Nutrients)
            .Where(i => i.IngredientAttr!.FDC_ID.HasValue)
            .ToListAsync();
    }

    public async Task UpdateNutrient(Nutrient nutrient)
    {
        _context.Nutrients.Update(nutrient);
        await _context.SaveChangesAsync();
    }

    public async Task InsertNewNutrients(List<Nutrient> newNutrients)
    {
        foreach (var nutrient in newNutrients)
        {
            _context.Nutrients.Add(nutrient);
        }

        await _context.SaveChangesAsync();
    }
}
