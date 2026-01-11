using Data.Entities.Footnote;
using Data.Entities.Genetics;
using Data.Entities.Ingredients;
using Data.Entities.Newsletter;
using Data.Entities.Recipes;
using Data.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel;
using System.Reflection;

namespace Data;

/// <summary>
/// https://mehdi.me/ambient-dbcontext-in-ef6/
/// </summary>
public class CoreContext : DbContext
{
    private const string DISABLED_REASON_IS_NULL = "\"DisabledReason\" IS NULL";

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
    public DbSet<UserRecipe> UserRecipes { get; set; } = null!;
    public DbSet<UserFamily> UserFamilies { get; set; } = null!;
    public DbSet<UserSection> UserSections { get; set; } = null!;
    public DbSet<UserFootnote> UserFootnotes { get; set; } = null!;
    public DbSet<UserNutrient> UserNutrients { get; set; } = null!;
    public DbSet<UserIngredient> UserIngredients { get; set; } = null!;
    public DbSet<UserFeastRecipe> UserFeastRecipes { get; set; } = null!;
    public DbSet<UserRecipeIngredient> UserRecipeIngredients { get; set; } = null!;
    public DbSet<UserFeastRecipeIngredient> UserFeastRecipeIngredients { get; set; } = null!;

    /// <summary>
    /// AlternativeIngredient does not have a global query filter for DisabledReason.
    /// </summary>
    public DbSet<IngredientAlternative> IngredientAlternatives { get; set; } = null!;

    /// <summary>
    /// Ingredient does not have a global query filter for DisabledReason.
    /// This shouldn't matter because the recipe can be updated and fixed.
    /// </summary>
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;

    /// <summary>
    /// These do not have a global query filter for DisabledReason.
    /// </summary>
    public DbSet<Ingredient> Ingredients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserRecipe>().HasKey(sc => new { sc.UserId, sc.RecipeId });
        modelBuilder.Entity<UserSection>().HasKey(sc => new { sc.UserId, sc.Section });
        modelBuilder.Entity<UserNutrient>().HasKey(sc => new { sc.UserId, sc.Nutrient });
        modelBuilder.Entity<UserIngredient>().HasKey(sc => new { sc.UserId, sc.IngredientId });
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

        ////////// Partial Indexes ////////// Clone existing indexes to have a DisabledReason filter. Only filter out DisabledReason if there's a global query filter set for it.
        modelBuilder.Entity<Recipe>().Metadata.GetIndexes().Where(index => index.GetFilter() == null).ToList().ForEach(index => modelBuilder.Entity<Recipe>().Metadata.AddIndex(index.Properties, $"{index.GetDatabaseName()}_DisabledReason").SetFilter(DISABLED_REASON_IS_NULL));
        modelBuilder.Entity<Ingredient>().Metadata.GetIndexes().Where(index => index.GetFilter() == null).ToList().ForEach(index => modelBuilder.Entity<Ingredient>().Metadata.AddIndex(index.Properties, $"{index.GetDatabaseName()}_DisabledReason").SetFilter(DISABLED_REASON_IS_NULL));

        ////////// Conversions //////////
        modelBuilder.Entity<Ingredient>().Property(i => i.Group).HasConversion(v => v.TrimEnd('s'), v => v.TrimEnd('s'), new ValueComparer<string>((v1, v2) => v1 == v2, v => v.GetHashCode()));

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
