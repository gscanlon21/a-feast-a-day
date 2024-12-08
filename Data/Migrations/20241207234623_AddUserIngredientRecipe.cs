using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIngredientRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "user_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_RecipeId",
                table: "user_ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ingredient_recipe_RecipeId",
                table: "user_ingredient",
                column: "RecipeId",
                principalTable: "recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ingredient_recipe_RecipeId",
                table: "user_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_user_ingredient_RecipeId",
                table: "user_ingredient");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "user_ingredient");
        }
    }
}
