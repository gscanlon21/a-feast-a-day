using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CoreContext : DbContext
{
    public DbSet<Footnote> Footnotes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserToken> UserTokens { get; set; } = null!;
    public DbSet<UserEmail> UserEmails { get; set; } = null!;
    public DbSet<UserServing> UserServings { get; set; } = null!;
    public DbSet<Ingredient> UserIngredients { get; set; } = null!;
    public DbSet<UserIngredientGroup> UserIngredientGroups { get; set; } = null!;
    public DbSet<UserFeast> UserFeasts { get; set; } = null!;
    public DbSet<Recipe> UserRecipes { get; set; } = null!;
    public DbSet<UserRecipe> UserUserRecipes { get; set; } = null!;
    public DbSet<UserFeastRecipe> UserFeastRecipes { get; set; } = null!;
    public DbSet<UserFootnote> UserFootnotes { get; set; } = null!;

    public CoreContext() : base() { }

    public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }

    //private static readonly JsonSerializerOptions JsonSerializerOptions = new();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserRecipe>().HasKey(sc => new { sc.UserId, sc.RecipeId });
        modelBuilder.Entity<UserIngredientGroup>().HasKey(sc => new { sc.UserId, sc.Nutrient });
        modelBuilder.Entity<UserServing>().HasKey(sc => new { sc.UserId, sc.Section });

        //modelBuilder
        //    .Entity<Variation>()
        //    .Property(e => e.StrengthMuscles)
        //    .HasConversion(v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
        //        v => JsonSerializer.Deserialize<List<MuscleGroups>>(v, new JsonSerializerOptions()),
        //        new ValueComparer<List<MuscleGroups>>((mg, mg2) => mg == mg2, mg => mg.GetHashCode())
        //    );


        ////////// Query Filters //////////
        modelBuilder.Entity<Recipe>().HasQueryFilter(p => p.DisabledReason == null);
        modelBuilder.Entity<RecipeIngredient>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<RecipeInstruction>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserFeastRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserRecipe>().HasQueryFilter(p => p.Recipe.DisabledReason == null);
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);
    }
}
