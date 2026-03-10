using Data.Entities.Ingredients;
using Data.Entities.Nutrients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Core.Code.Extensions.EnumerableExtensions;

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

    public async Task<IList<Ingredient>> GetIngredientsWithHealthCanadaData()
    {
        return await _context.Ingredients.AsNoTracking().AsSplitQuery()
            .Include(i => i.IngredientAttr).Include(i => i.NutrientsCanada)
            .Where(i => i.IngredientAttr!.HC_Id.HasValue)
            .ToListAsync();
    }

    public async Task<IList<Ingredient>> GetIngredientsWithFoodData()
    {
        return await _context.Ingredients.AsNoTracking().AsSplitQuery()
            .Include(i => i.IngredientAttr).Include(i => i.Nutrients)
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
        _context.NutrientsCanada.Update(nutrient);
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
            _context.NutrientsCanada.Add(nutrient);
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
