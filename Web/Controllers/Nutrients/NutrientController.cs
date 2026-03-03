using Core.Models.User;
using Data;
using Data.Entities.External;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Code.TempData;
using Web.Views.Nutrient;
using static Core.Code.Extensions.EnumerableExtensions;

namespace Web.Controllers.Nutrients;

[Route($"nutrient/{UserRoute}", Order = 1)]
public class NutrientController : ViewController
{
    /// <summary>
    /// The name of the controller for routing purposes.
    /// </summary>
    public const string Name = "Nutrient";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;

    public NutrientController(CoreContext context, UserRepo userRepo)
    {
        _context = context;
        _userRepo = userRepo;
    }

    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet, Route("{nutrient}")]
    public async Task<IActionResult> ManageNutrient(string email, string token, string nutrient, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var dietaryIntakesExisting = await _context.DietaryIntakes.AsNoTracking()
            .Where(di => EF.Functions.ILike(di.Key, nutrient))
            .ToListAsync();

        List<DietaryIntakeViewModel> dietaryIntakes = [];
        foreach (var person in EnumExtensions.GetValuesExcluding(Person.None, Person.All))
        {
            var existing = dietaryIntakesExisting.FirstOrDefault(di => di.Person == person);
            if (existing != null)
            {
                dietaryIntakes.Add(new DietaryIntakeViewModel(existing));
            }
            else
            {
                dietaryIntakes.Add(new DietaryIntakeViewModel()
                {
                    Key = nutrient,
                    Person = person,
                });
            }
        }

        return View(nameof(ManageNutrient), new ManageNutrientViewModel()
        {
            User = user,
            Token = token,
            Nutrient = nutrient,
            WasUpdated = wasUpdated,
            DietaryIntakes = dietaryIntakes.OrderBy(di => di.Person.GetOrder(), NullOrder.NullsLast).ToList(),
        });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> UpsertDietaryIntake(string email, string token, string nutrient, List<DietaryIntakeViewModel> dietaryIntakes)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        //await _context.DietaryIntakes.Where(r => r.Key == nutrient).ExecuteDeleteAsync();
        foreach (var dietaryIntake in dietaryIntakes.Where(di => di.Min.HasValue || di.Max.HasValue))
        {
            var existingEntity = await _context.DietaryIntakes.FirstOrDefaultAsync(r => r.Id == dietaryIntake.Id);
            if (existingEntity != null)
            {
                existingEntity.Key = dietaryIntake.Key;
                existingEntity.Min = dietaryIntake.Min;
                existingEntity.Max = dietaryIntake.Max;
                existingEntity.Person = dietaryIntake.Person;
                existingEntity.Measure = dietaryIntake.Measure;
                existingEntity.Source = dietaryIntake.Source ?? "";
                existingEntity.Multiplier = dietaryIntake.Multiplier;
                existingEntity.CaloriesPerGram = dietaryIntake.CaloriesPerGram;
            }
            else
            {
                existingEntity = new DietaryIntake()
                {
                    Key = dietaryIntake.Key,
                    Min = dietaryIntake.Min,
                    Max = dietaryIntake.Max,
                    Person = dietaryIntake.Person,
                    Measure = dietaryIntake.Measure,
                    Source = dietaryIntake.Source ?? "",
                    Multiplier = dietaryIntake.Multiplier,
                    CaloriesPerGram = dietaryIntake.CaloriesPerGram,
                };

                _context.DietaryIntakes.Add(existingEntity);
            }
        }

        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient has been updated!";
        return RedirectToAction(nameof(ManageNutrient), new { email, token, nutrient, wasUpdated = true });
    }
}
