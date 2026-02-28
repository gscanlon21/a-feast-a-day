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
        return await _context.Ingredients.AsNoTracking()
            .Include(i => i.Nutrients)
            .Where(i => i.IngredientAttr!.FDC_ID.HasValue)
            .Where(i => i.IngredientAttr!.NDB_Number.HasValue)
            .ToListAsync();
    }
}
