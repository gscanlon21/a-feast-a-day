using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Attributes",
                table: "user_recipe_ingredient",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIngredientId",
                table: "user_recipe_ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user_ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_ingredient_UserIngredientId",
                table: "user_recipe_ingredient",
                column: "UserIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_UserId",
                table: "user_ingredient",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient",
                column: "UserIngredientId",
                principalTable: "user_ingredient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient");

            migrationBuilder.DropTable(
                name: "user_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_user_recipe_ingredient_UserIngredientId",
                table: "user_recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "Attributes",
                table: "user_recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "UserIngredientId",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "user_recipe_ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
