using Core.Models.Newsletter;
using Data.Entities.User;
using Data.Query;
using System.Diagnostics;

namespace Data.Models;

[DebuggerDisplay("{Exercise}: {Variation}")]
public record QueryResults(
    Section Section,
    Recipe Recipe,
    UserRecipe? UserRecipe
) : IRecipeCombo;