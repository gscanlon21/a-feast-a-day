using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_exercise_exercise_ExerciseId",
                table: "user_exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_variation_variation_VariationId",
                table: "user_workout_variation");

            migrationBuilder.DropTable(
                name: "exercise_prerequisite");

            migrationBuilder.DropTable(
                name: "instruction");

            migrationBuilder.DropTable(
                name: "user_muscle_flexibility");

            migrationBuilder.DropTable(
                name: "user_muscle_mobility");

            migrationBuilder.DropTable(
                name: "user_muscle_strength");

            migrationBuilder.DropTable(
                name: "user_variation_weight");

            migrationBuilder.DropTable(
                name: "user_variation");

            migrationBuilder.DropTable(
                name: "variation");

            migrationBuilder.DropIndex(
                name: "IX_user_workout_variation_VariationId",
                table: "user_workout_variation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_exercise",
                table: "exercise");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "IsDeloadWeek",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_Id",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_MovementPatterns",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_MuscleGroups",
                table: "user_workout");

            migrationBuilder.DropColumn(
                name: "Rotation_Id",
                table: "user_frequency");

            migrationBuilder.DropColumn(
                name: "Rotation_MovementPatterns",
                table: "user_frequency");

            migrationBuilder.DropColumn(
                name: "Rotation_MuscleGroups",
                table: "user_frequency");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "user");

            migrationBuilder.DropColumn(
                name: "PrehabFocus",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RehabFocus",
                table: "user");

            migrationBuilder.DropColumn(
                name: "SeasonedDate",
                table: "user");

            migrationBuilder.DropColumn(
                name: "SportsFocus",
                table: "user");

            migrationBuilder.RenameTable(
                name: "exercise",
                newName: "recipe");

            migrationBuilder.AlterTable(
                name: "recipe",
                comment: "Recipes listed on the website",
                oldComment: "Exercises listed on the website");

            migrationBuilder.AddPrimaryKey(
                name: "PK_recipe",
                table: "recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_exercise_recipe_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId",
                principalTable: "recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_exercise_recipe_ExerciseId",
                table: "user_exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_recipe",
                table: "recipe");

            migrationBuilder.RenameTable(
                name: "recipe",
                newName: "exercise");

            migrationBuilder.AlterTable(
                name: "exercise",
                comment: "Exercises listed on the website",
                oldComment: "Recipes listed on the website");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "user_workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeloadWeek",
                table: "user_workout",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rotation_Id",
                table: "user_workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rotation_MovementPatterns",
                table: "user_workout",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rotation_MuscleGroups",
                table: "user_workout",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rotation_Id",
                table: "user_frequency",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rotation_MovementPatterns",
                table: "user_frequency",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rotation_MuscleGroups",
                table: "user_frequency",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PrehabFocus",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RehabFocus",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateOnly>(
                name: "SeasonedDate",
                table: "user",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportsFocus",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_exercise",
                table: "exercise",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "exercise_prerequisite",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    PrerequisiteExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Proficiency = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercise_prerequisite", x => new { x.ExerciseId, x.PrerequisiteExerciseId });
                    table.ForeignKey(
                        name: "FK_exercise_prerequisite_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_exercise_prerequisite_exercise_PrerequisiteExerciseId",
                        column: x => x.PrerequisiteExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Pre-requisite exercises for other exercises");

            migrationBuilder.CreateTable(
                name: "user_muscle_flexibility",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroup = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_muscle_flexibility", x => new { x.UserId, x.MuscleGroup });
                    table.ForeignKey(
                        name: "FK_user_muscle_flexibility_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_muscle_mobility",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroup = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_muscle_mobility", x => new { x.UserId, x.MuscleGroup });
                    table.ForeignKey(
                        name: "FK_user_muscle_mobility_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_muscle_strength",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroup = table.Column<long>(type: "bigint", nullable: false),
                    End = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_muscle_strength", x => new { x.UserId, x.MuscleGroup });
                    table.ForeignKey(
                        name: "FK_user_muscle_strength_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    AnimatedImage = table.Column<string>(type: "text", nullable: true),
                    DefaultInstruction = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    ExerciseFocus = table.Column<int>(type: "integer", nullable: false),
                    ExerciseType = table.Column<int>(type: "integer", nullable: false),
                    IsWeighted = table.Column<bool>(type: "boolean", nullable: false),
                    MobilityJoints = table.Column<long>(type: "bigint", nullable: false),
                    MovementPattern = table.Column<int>(type: "integer", nullable: false),
                    MuscleContractions = table.Column<int>(type: "integer", nullable: false),
                    MuscleMovement = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    PauseReps = table.Column<bool>(type: "boolean", nullable: true),
                    SecondaryMuscles = table.Column<long>(type: "bigint", nullable: false),
                    SportsFocus = table.Column<int>(type: "integer", nullable: false),
                    StaticImage = table.Column<string>(type: "text", nullable: false),
                    StrengthMuscles = table.Column<long>(type: "bigint", nullable: false),
                    StretchMuscles = table.Column<long>(type: "bigint", nullable: false),
                    Unilateral = table.Column<bool>(type: "boolean", nullable: false),
                    UseCaution = table.Column<bool>(type: "boolean", nullable: false),
                    Progression_Max = table.Column<int>(type: "integer", nullable: true),
                    Progression_Min = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_variation_exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Variations of exercises");

            migrationBuilder.CreateTable(
                name: "instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    VariationId = table.Column<int>(type: "integer", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Equipment = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_instruction_instruction_ParentId",
                        column: x => x.ParentId,
                        principalTable: "instruction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_instruction_variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Equipment that can be switched out for one another");

            migrationBuilder.CreateTable(
                name: "user_variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    VariationId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_variation_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_variation_variation_VariationId",
                        column: x => x.VariationId,
                        principalTable: "variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's intensity stats");

            migrationBuilder.CreateTable(
                name: "user_variation_weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserVariationId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_variation_weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_variation_weight_user_variation_UserVariationId",
                        column: x => x.UserVariationId,
                        principalTable: "user_variation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User variation weight log");

            migrationBuilder.CreateIndex(
                name: "IX_user_workout_variation_VariationId",
                table: "user_workout_variation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_exercise_prerequisite_PrerequisiteExerciseId",
                table: "exercise_prerequisite",
                column: "PrerequisiteExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_ParentId",
                table: "instruction",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_instruction_VariationId",
                table: "instruction",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_user_variation_UserId_VariationId_Section",
                table: "user_variation",
                columns: new[] { "UserId", "VariationId", "Section" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_variation_VariationId",
                table: "user_variation",
                column: "VariationId");

            migrationBuilder.CreateIndex(
                name: "IX_user_variation_weight_UserVariationId",
                table: "user_variation_weight",
                column: "UserVariationId");

            migrationBuilder.CreateIndex(
                name: "IX_variation_ExerciseId",
                table: "variation",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_exercise_exercise_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId",
                principalTable: "exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_variation_variation_VariationId",
                table: "user_workout_variation",
                column: "VariationId",
                principalTable: "variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
