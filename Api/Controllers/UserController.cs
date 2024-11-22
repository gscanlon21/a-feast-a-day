using Core.Models.Newsletter;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// User helpers.
/// </summary>
[ApiController, Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepo _userRepo;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserController(UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    /// <summary>
    /// Get the user.
    /// </summary>
    [HttpGet("User")]
    public async Task<IActionResult> GetUser(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    /// <summary>
    /// Get the user's current shopping list.
    /// </summary>
    [HttpGet("ShoppingList")]
    public async Task<IActionResult> GetShoppingList(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var currentFeast = await _userRepo.GetCurrentFeast(user);
        if (currentFeast == null) { return StatusCode(StatusCodes.Status204NoContent); }

        var recipes = await new QueryBuilder(Section.None)
            .WithUser(user)
            .WithRecipes(options =>
            {
                options.AddPastRecipes(currentFeast.UserFeastRecipes);
            })
            .Build()
            .Query(_serviceScopeFactory);

        var shoppingList = await NewsletterRepo.GetShoppingList(currentFeast, recipes);
        return StatusCode(StatusCodes.Status200OK, shoppingList);
    }

    /// <summary>
    /// Logs a client exception.
    /// </summary>
    [HttpPost("LogException")]
    public async Task LogException([FromForm] string? email, [FromForm] string? token, [FromForm] string? message)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null || string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        throw new Exception(message);
    }

    /// <summary>
    /// EXTERNAL. Get the user's weekly allergens.
    /// </summary>
    [HttpGet("Allergens")]
    public async Task<IActionResult> GetAllergens(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, int weeks = 1, bool includeToday = false)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var weeklyAllergens = await _userRepo.GetWeeklyAllergens(user, weeks: weeks, includeToday: includeToday);
        if (weeklyAllergens.weeks <= 0) { return StatusCode(StatusCodes.Status204NoContent); }

        return StatusCode(StatusCodes.Status200OK, weeklyAllergens.volume);
    }

    /// <summary>
    /// EXTERNAL. Get the user's current nutrients.
    /// </summary>
    [HttpGet("Nutrients")]
    public async Task<IActionResult> GetNutrients(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken, int weeks = 1, bool rawValues = true, bool tul = false, bool includeToday = true)
    {
        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var weeklyNutrients = await _userRepo.GetWeeklyNutrientVolume(user, weeks: weeks, rawValues: rawValues, tul: tul, includeToday: includeToday);
        if (weeklyNutrients.weeks <= 0) { return StatusCode(StatusCodes.Status204NoContent); }

        return StatusCode(StatusCodes.Status200OK, weeklyNutrients.volume);
    }
}
