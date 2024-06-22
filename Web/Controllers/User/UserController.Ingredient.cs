﻿using Core.Models.User;
using Data.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Web.Code.TempData;
using Web.Views.Shared.Components.ManageIngredient;
using Web.Views.User;

namespace Web.Controllers.User;

public partial class UserController
{
    [HttpPost]
    [Route("ingredient/add")]
    public async Task<IActionResult> AddIngredient(string email, string token, [FromForm] string name, [FromForm] Nutrients nutrients, [FromForm] IList<Allergy> allergens)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        context.Add(new Data.Entities.User.Ingredient()
        {
            User = user,
            Name = name,
            //Nutrients = nutrients,
            Allergens = allergens.Aggregate(Allergy.None, (curr, next) => curr | next),
        });

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("ingredient/remove")]
    public async Task<IActionResult> RemoveIngredient(string email, string token, [FromForm] int ingredientId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        await context.Ingredients
            // The user has control of this footnote and is not a built-in footnote.
            .Where(f => f.UserId == user.Id)
            .Where(f => f.Id == ingredientId)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.Edit), new { email, token });
    }

    [HttpPost]
    [Route("{ingredientId}/ii", Order = 1)]
    [Route("{ingredientId}/ignore-ingredient", Order = 2)]
    public async Task<IActionResult> IgnoreIngredient(string email, string token, int ingredientId)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var userProgression = await context.UserIngredients
            .Where(ue => ue.UserId == user.Id)
            .FirstOrDefaultAsync(ue => ue.IngredientId == ingredientId);

        // May be null if the exercise was soft/hard deleted
        if (userProgression == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        userProgression.Ignore = !userProgression.Ignore;
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(ManageIngredient), new { email, token, ingredientId, WasUpdated = true });
    }

    /// <summary>
    /// Shows a form to the user where they can update their Pounds lifted.
    /// </summary>
    [HttpGet]
    [Route("ingredient/{ingredientId}")]
    public async Task<IActionResult> ManageIngredient(string email, string token, int ingredientId, bool? wasUpdated = null)
    {
        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var ingredient = await context.Ingredients.Include(i => i.Nutrients).FirstOrDefaultAsync(r => r.Id == ingredientId);
        if (ingredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        return View(new UserManageIngredientViewModel()
        {
            User = user,
            Token = token,
            Ingredient = ingredient,
            WasUpdated = wasUpdated,
            HasUserIngredient = true,
            Parameters = new UserManageIngredientViewModel.Params(email, token, ingredientId)
        });
    }

    [HttpPost]
    [Route("useringredient/post")]
    public async Task<IActionResult> ManageUserIngredientPost(string email, string token, int ingredientId, ManageIngredientViewModel viewModel)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingIngredient = await context.UserIngredients
            .FirstOrDefaultAsync(r => r.IngredientId == ingredientId && r.UserId == user.Id);
        if (existingIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        existingIngredient.SubstituteIngredientId = viewModel.UserIngredient.SubstituteIngredientId;
        await context.SaveChangesAsync();
        TempData[TempData_User.SuccessMessage] = "Your ingredients have been updated!";
        return RedirectToAction(nameof(UserController.ManageIngredient), new { email, token, ingredientId, wasUpdated = true });
    }

    [HttpPost]
    [Route("ingredient/post")]
    public async Task<IActionResult> ManageIngredientPost(string email, string token, Data.Entities.User.Ingredient ingredient, List<Data.Entities.User.Nutrient> nutrients)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null || !user.Features.HasFlag(Features.Admin))
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        var existingIngredient = await context.Ingredients.Include(i => i.Nutrients).FirstOrDefaultAsync(r => r.Id == ingredient.Id);
        if (existingIngredient == null)
        {
            return View("StatusMessage", new StatusMessageViewModel(LinkExpiredMessage));
        }

        existingIngredient.Name = ingredient.Name;
        existingIngredient.Notes = ingredient.Notes;
        existingIngredient.Allergens = ingredient.Allergens;
        existingIngredient.DefaultMeasure = ingredient.DefaultMeasure;
        existingIngredient.GramsPerMeasure = ingredient.GramsPerMeasure;
        existingIngredient.GramsPerServing = ingredient.GramsPerServing;
        existingIngredient.SkipShoppingList = ingredient.SkipShoppingList;
        existingIngredient.CaloriesPerServing = ingredient.CaloriesPerServing;

        foreach (var nutrient in nutrients.OrderBy(n => BitOperations.PopCount((ulong)n.Nutrients)))
        {
            // Sum all the parts of a nutrient if it was left empty.
            // FIXME: Not all of the precursors get converted into a nutrient. Need a conversion percentage.
            //if (nutrient.Value == 0 && BitOperations.PopCount((ulong)nutrient.Nutrients) > 1)
            //{
            //    nutrient.Measure = Measure.Grams;
            //    nutrient.Value = nutrients
            //        .Where(n => BitOperations.PopCount((ulong)n.Nutrients) == 1)
            //        .Where(n => nutrient.Nutrients.HasFlag(n.Nutrients))
            //        .Sum(n => n.Measure.ToGrams(n.Value));
            //}

            var existingNutrient = existingIngredient.Nutrients.FirstOrDefault(n => n.Nutrients == nutrient.Nutrients);
            if (existingNutrient != null)
            {
                existingNutrient.Synthetic = nutrient.Synthetic;
                existingNutrient.Measure = nutrient.Measure;
                existingNutrient.Value = nutrient.Value;
            }
            else
            {
                existingIngredient.Nutrients.Add(new Nutrient()
                {
                    Nutrients = nutrient.Nutrients,
                    Synthetic = nutrient.Synthetic,
                    Measure = nutrient.Measure,
                    Value = nutrient.Value,
                });
            }
        }

        await context.SaveChangesAsync();
        //TempData[TempData_User.SuccessMessage] = "Your recipes have been updated!";
        return RedirectToAction(nameof(UserController.ManageIngredient), new { email, token, ingredientId = ingredient.Id, wasUpdated = true });
    }
}
