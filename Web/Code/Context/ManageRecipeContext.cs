using Core.Models.Newsletter;

namespace Web.Code.Context;

public record ManageRecipeParams(string Email, string Token, int RecipeId, Section Section);
