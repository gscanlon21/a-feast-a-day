using Data.Entities.Footnote;
using Data.Entities.Ingredient;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Data;

/// <summary>
/// https://mehdi.me/ambient-dbcontext-in-ef6/
/// </summary>
public class CoreContext : DbContext
{
    [Obsolete("Public parameterless constructor required for EF Core.", error: true)]
    public CoreContext() : base() { }
    public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Recipe> Recipes { get; set; } = null!;
    public DbSet<Nutrient> Nutrients { get; set; } = null!;
    public DbSet<Footnote> Footnotes { get; set; } = null!;
    public DbSet<UserToken> UserTokens { get; set; } = null!;
    public DbSet<UserEmail> UserEmails { get; set; } = null!;
    public DbSet<UserFeast> UserFeasts { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<UserRecipe> UserRecipes { get; set; } = null!;
    public DbSet<UserFamily> UserFamilies { get; set; } = null!;
    public DbSet<UserSection> UserSections { get; set; } = null!;
    public DbSet<UserFootnote> UserFootnotes { get; set; } = null!;
    public DbSet<UserNutrient> UserNutrients { get; set; } = null!;
    public DbSet<UserIngredient> UserIngredients { get; set; } = null!;
    public DbSet<UserFeastRecipe> UserFeastRecipes { get; set; } = null!;
    public DbSet<UserFeastRecipeIngredient> UserFeastRecipeIngredients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserSection>().HasKey(sc => new { sc.UserId, sc.Section });
        modelBuilder.Entity<UserNutrient>().HasKey(sc => new { sc.UserId, sc.Nutrient });
        modelBuilder.Entity<UserRecipe>().HasKey(sc => new { sc.UserId, sc.RecipeId, sc.Section });
        modelBuilder.Entity<UserIngredient>().HasKey(sc => new { sc.UserId, sc.IngredientId, sc.RecipeId });
        modelBuilder.Entity<IngredientAlternative>().HasKey(sc => new { sc.IngredientId, sc.AlternativeIngredientId });

        ////////// Query Filters //////////
        modelBuilder.Entity<Recipe>().HasQueryFilter(p => p.DisabledReason == null);
        modelBuilder.Entity<RecipeIngredient>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<RecipeInstruction>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);
        modelBuilder.Entity<UserRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserFeastRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserFeastRecipeIngredient>().HasQueryFilter(p => p.UserFeastRecipe.Recipe.DisabledReason == null);
    }
}
