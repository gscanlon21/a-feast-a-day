using Data.Entities.Footnote;
using Data.Entities.Genetics;
using Data.Entities.Ingredient;
using Data.Entities.Newsletter;
using Data.Entities.Recipe;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;

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
    public DbSet<UserFeastRecipe> UserFeastRecipes { get; set; } = null!;
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
    public DbSet<UserRecipeIngredient> UserRecipeIngredients { get; set; } = null!;
    public DbSet<UserFeastRecipeIngredient> UserFeastRecipeIngredients { get; set; } = null!;
    public DbSet<IngredientAlternative> IngredientAlternatives { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserRecipe>().HasKey(sc => new { sc.UserId, sc.RecipeId });
        modelBuilder.Entity<UserSection>().HasKey(sc => new { sc.UserId, sc.Section });
        modelBuilder.Entity<UserNutrient>().HasKey(sc => new { sc.UserId, sc.Nutrient });
        modelBuilder.Entity<UserRecipeIngredient>().HasKey(sc => new { sc.UserId, sc.RecipeIngredientId });
        modelBuilder.Entity<IngredientAlternative>().HasKey(sc => new { sc.IngredientId, sc.AlternativeIngredientId });
        modelBuilder.Entity<StudyIngredient>().HasKey(sc => new { sc.StudyId, sc.IngredientId });

        ////////// Query Filters //////////
        modelBuilder.Entity<Recipe>().HasQueryFilter(p => p.DisabledReason == null);
        modelBuilder.Entity<RecipeIngredient>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<RecipeInstruction>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);
        modelBuilder.Entity<UserRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserFeastRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserRecipeIngredient>().HasQueryFilter(p => p.RecipeIngredient.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserFeastRecipeIngredient>().HasQueryFilter(p => p.UserFeastRecipe.Recipe.DisabledReason == null);

        // Set the default value of the db columns be attributes.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (((MemberInfo?)property.PropertyInfo ?? property.FieldInfo) is MemberInfo memberInfo)
                {
                    if (Attribute.GetCustomAttribute(memberInfo, typeof(DefaultValueAttribute)) is DefaultValueAttribute defaultValue)
                    {
                        property.SetDefaultValue(defaultValue.Value);
                    }
                }
            }
        }
    }
}
