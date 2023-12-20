using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_variation_user_workout_UserWorkoutId",
                table: "user_workout_variation");

            migrationBuilder.DropTable(
                name: "user_exercise");

            migrationBuilder.DropTable(
                name: "user_frequency");

            migrationBuilder.DropTable(
                name: "user_workout");

            migrationBuilder.DropColumn(
                name: "DeloadAfterEveryXWeeks",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IncludeMobilityWorkouts",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Intensity",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RefreshAccessoryEveryXWeeks",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RefreshFunctionalEveryXWeeks",
                table: "user");

            migrationBuilder.CreateTable(
                name: "user_feast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_UserId",
                table: "user_feast",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_variation_user_feast_UserWorkoutId",
                table: "user_workout_variation",
                column: "UserWorkoutId",
                principalTable: "user_feast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_workout_variation_user_feast_UserWorkoutId",
                table: "user_workout_variation");

            migrationBuilder.DropTable(
                name: "user_feast");

            migrationBuilder.AddColumn<int>(
                name: "DeloadAfterEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeMobilityWorkouts",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Intensity",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefreshAccessoryEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefreshFunctionalEveryXWeeks",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "user_exercise",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    LastVisible = table.Column<DateOnly>(type: "date", nullable: false),
                    Progression = table.Column<int>(type: "integer", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_exercise", x => new { x.UserId, x.ExerciseId });
                    table.ForeignKey(
                        name: "FK_user_exercise_recipe_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_exercise_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's progression level of an exercise");

            migrationBuilder.CreateTable(
                name: "user_frequency",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_frequency", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_user_frequency_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_workout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Intensity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_workout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_workout_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_exercise_ExerciseId",
                table: "user_exercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_user_workout_UserId",
                table: "user_workout",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_workout_variation_user_workout_UserWorkoutId",
                table: "user_workout_variation",
                column: "UserWorkoutId",
                principalTable: "user_workout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
