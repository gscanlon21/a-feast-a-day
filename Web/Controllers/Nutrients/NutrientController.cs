using Core.Models.User;
using Data;
using Data.Entities.Nutrients;
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
    /// Allows admins to manage a nutrient and it's dietary intake reference values.
    /// Using nutrient.Id b/c nutrient.Key can be updated which breaks GoBackOnSave.
    /// </summary>
    [HttpGet, Route("{id}")]
    public async Task<IActionResult> ManageNutrient(string email, string token, int id, bool? wasUpdated = null)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: false);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingNutrient = await _context.Nutrients.AsNoTracking()
            .Include(n => n.DietaryIntakes)
            .Where(n => n.Id == id)
            .FirstOrDefaultAsync();

        if (existingNutrient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        List<DietaryIntakeViewModel> dietaryIntakes = [];
        foreach (var person in EnumExtensions.GetValuesExcluding(Person.None, Person.All))
        {
            var existing = existingNutrient.DietaryIntakes.FirstOrDefault(di => di.Person == person);
            if (existing != null)
            {
                dietaryIntakes.Add(new DietaryIntakeViewModel(existing));
            }
            else
            {
                dietaryIntakes.Add(new DietaryIntakeViewModel()
                {
                    Person = person,
                });
            }
        }

        return View(nameof(ManageNutrient), new ManageNutrientViewModel()
        {
            User = user,
            Token = token,
            WasUpdated = wasUpdated,
            Nutrient = existingNutrient,
            DietaryIntakes = dietaryIntakes.OrderBy(di => di.Person.GetOrder(), NullOrder.NullsLast).ToList(),
        });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> UpsertNutrient(string email, string token, Nutrient nutrient)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: false);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingEntity = await _context.Nutrients.FirstOrDefaultAsync(r => r.Id == nutrient.Id);
        if (existingEntity != null)
        {
            existingEntity.Key = nutrient.Key;
            existingEntity.Name = nutrient.Name;
            existingEntity.Order = nutrient.Order;
            existingEntity.Notes = nutrient.Notes;
            existingEntity.LastUpdated = DateHelpers.Today;
        }
        else
        {
            existingEntity = new Nutrient()
            {
                Key = nutrient.Key,
                Name = nutrient.Name,
                Notes = nutrient.Notes,
                Order = nutrient.Order,
            };

            _context.Nutrients.Add(existingEntity);
        }
       
        await _context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your nutrient has been updated!";
        return RedirectToAction(nameof(ManageNutrient), new { email, token, nutrient.Id, wasUpdated = true });
    }

    [HttpPost, Route("[action]")]
    public async Task<IActionResult> UpsertDietaryIntake(string email, string token, Nutrient nutrient, List<DietaryIntakeViewModel> dietaryIntakes)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: false);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        //await _context.DietaryIntakes.Where(r => r.Nutrient!.Id == nutrient.Id).ExecuteDeleteAsync();
        foreach (var dietaryIntake in dietaryIntakes.Where(di => di.Min.HasValue || di.Max.HasValue))
        {
            var existingEntity = await _context.DietaryIntakes.FirstOrDefaultAsync(r => r.Id == dietaryIntake.Id);
            if (existingEntity != null)
            {
                existingEntity.Min = dietaryIntake.Min;
                existingEntity.Max = dietaryIntake.Max;
                existingEntity.Notes = dietaryIntake.Notes;
                existingEntity.Person = dietaryIntake.Person;
                existingEntity.Measure = dietaryIntake.Measure;
                existingEntity.Source = dietaryIntake.Source ?? "";
                existingEntity.Multiplier = dietaryIntake.Multiplier;
                existingEntity.CaloriesPerGram = dietaryIntake.CaloriesPerGram;
                existingEntity.LastUpdated = DateHelpers.Today;
            }
            else
            {
                existingEntity = new DietaryIntake()
                {
                    NutrientId = nutrient.Id,
                    Min = dietaryIntake.Min,
                    Max = dietaryIntake.Max,
                    Notes = dietaryIntake.Notes,
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
        TempData[TempData_User.SuccessMessage] = "Your dietary intakes have been updated!";
        return RedirectToAction(nameof(ManageNutrient), new { email, token, nutrient.Id, wasUpdated = true });
    }
}
