using Data.Entities.Exercise;
using Data.Entities.Footnote;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Data;

public class CoreContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; } = null!;
    public DbSet<Footnote> Footnotes { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserToken> UserTokens { get; set; } = null!;
    public DbSet<UserEmail> UserEmails { get; set; } = null!;
    public DbSet<UserFrequency> UserFrequencies { get; set; } = null!;
    public DbSet<UserExercise> UserExercises { get; set; } = null!;
    public DbSet<UserWorkout> UserWorkouts { get; set; } = null!;
    public DbSet<UserWorkoutVariation> UserWorkoutVariations { get; set; } = null!;
    public DbSet<UserFootnote> UserFootnotes { get; set; } = null!;

    public CoreContext() : base() { }

    public CoreContext(DbContextOptions<CoreContext> context) : base(context) { }

    private static readonly JsonSerializerOptions JsonSerializerOptions = new();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ////////// Keys //////////
        modelBuilder.Entity<UserFrequency>().HasKey(sc => new { sc.UserId, sc.Id });
        modelBuilder.Entity<UserExercise>().HasKey(sc => new { sc.UserId, sc.ExerciseId });
        //modelBuilder.Entity<ExerciseVariation>().HasKey(sc => new { sc.ExerciseId, sc.VariationId });

        //modelBuilder
        //    .Entity<Variation>()
        //    .Property(e => e.StrengthMuscles)
        //    .HasConversion(v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
        //        v => JsonSerializer.Deserialize<List<MuscleGroups>>(v, new JsonSerializerOptions()),
        //        new ValueComparer<List<MuscleGroups>>((mg, mg2) => mg == mg2, mg => mg.GetHashCode())
        //    );


        ////////// Query Filters //////////
        modelBuilder.Entity<Exercise>().HasQueryFilter(p => p.DisabledReason == null);
        modelBuilder.Entity<UserExercise>().HasQueryFilter(p => p.Exercise.DisabledReason == null);
        modelBuilder.Entity<UserToken>().HasQueryFilter(p => p.Expires > DateTime.UtcNow);
    }
}
