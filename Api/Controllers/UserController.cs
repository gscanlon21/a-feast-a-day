using Core.Consts;
using Core.Models.Newsletter;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// User helpers.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController(UserRepo userRepo, IServiceScopeFactory serviceScopeFactory) : ControllerBase
{
    /// <summary>
    /// Get the user.
    /// </summary>
    [HttpGet("User")]
    public async Task<IActionResult> GetUser(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        return StatusCode(StatusCodes.Status200OK, user);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpGet("Feasts")]
    public async Task<IActionResult> GetFeasts(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var feasts = await userRepo.GetPastFeasts(user);
        return StatusCode(StatusCodes.Status200OK, feasts);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpGet("ShoppingList")]
    public async Task<IActionResult> GetShoppingList(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }

        var currentFeast = await userRepo.GetCurrentFeast(user);
        if (currentFeast == null) { return StatusCode(StatusCodes.Status204NoContent); }

        var recipes = (await new QueryBuilder(Section.None)
            .WithUser(user)
            .WithRecipes(options =>
            {
                options.AddPastRecipes(currentFeast.UserFeastRecipes);
            })
            .Build()
            .Query(serviceScopeFactory))
            .ToList();

        var shoppingList = await NewsletterRepo.GetShoppingList(currentFeast, recipes.SelectMany(r => r.Recipe.RecipeIngredients).ToList());
        return StatusCode(StatusCodes.Status200OK, shoppingList);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpPost("LogException")]
    public async Task LogException([FromForm] string? email, [FromForm] string? token, [FromForm] string? message)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null || string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        throw new Exception(message);
    }
}
