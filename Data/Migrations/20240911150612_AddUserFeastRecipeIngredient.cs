using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFeastRecipeIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_feast_recipe_ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    UserFeastRecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_feast_recipe_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_feast_recipe_ingredient_user_feast_recipe_UserFeastRec~",
                        column: x => x.UserFeastRecipeId,
                        principalTable: "user_feast_recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "A day's workout routine");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_ingredient_IngredientId",
                table: "user_feast_recipe_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_ingredient_UserFeastRecipeId",
                table: "user_feast_recipe_ingredient",
                column: "UserFeastRecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_feast_recipe_ingredient");
        }
    }
}
