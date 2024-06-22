using Core.Consts;
using Core.Dtos.User;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// User helpers.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController(UserRepo userRepo) : ControllerBase
{
    /// <summary>
    /// Get the user.
    /// </summary>
    [HttpGet("User")]
    public async Task<User?> GetUser(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        return await userRepo.GetUser(email, token);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpGet("Feasts")]
    public async Task<IList<UserFeast>?> GetFeasts(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return null;
        }

        return await userRepo.GetPastFeasts(user);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpGet("ShoppingList")]
    public async Task<IList<RecipeIngredientDto>?> GetShoppingList(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return null;
        }

        var currentFeast = await userRepo.GetCurrentFeast(user, includeRecipeIngredients: true);
        if (currentFeast == null) { return null; }

        return await NewsletterRepo.GetShoppingList(currentFeast.UserFeastRecipes.SelectMany(r => r.Recipe.RecipeIngredients).ToList());
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
