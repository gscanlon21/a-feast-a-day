using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_workout_variation");

            migrationBuilder.CreateTable(
                name: "user_feast_recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFeastId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_user_feast_UserFeastId",
                        column: x => x.UserFeastId,
                        principalTable: "user_feast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_UserFeastId",
                table: "user_feast_recipe",
                column: "UserFeastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_feast_recipe");

            migrationBuilder.CreateTable(
                name: "user_workout_variation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserWorkoutId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<int>(type: "integer", nullable: false),
                    VariationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_workout_variation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_workout_variation_user_feast_UserWorkoutId",
                        column: x => x.UserWorkoutId,
                        principalTable: "user_feast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_workout_variation_UserWorkoutId",
                table: "user_workout_variation",
                column: "UserWorkoutId");
        }
    }
}
