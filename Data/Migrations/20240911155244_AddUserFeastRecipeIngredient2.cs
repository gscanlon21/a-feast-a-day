using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFeastRecipeIngredient2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_recipe_ingredient_ingredient_IngredientId",
                table: "user_feast_recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "user_feast_recipe_ingredient");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "user_feast_recipe_ingredient",
                newName: "RecipeIngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_user_feast_recipe_ingredient_IngredientId",
                table: "user_feast_recipe_ingredient",
                newName: "IX_user_feast_recipe_ingredient_RecipeIngredientId");

            migrationBuilder.AlterTable(
                name: "user_feast_recipe_ingredient",
                oldComment: "A day's workout routine");

            migrationBuilder.AlterTable(
                name: "user_feast_recipe",
                oldComment: "A day's workout routine");

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_recipe_ingredient_recipe_ingredient_RecipeIngred~",
                table: "user_feast_recipe_ingredient",
                column: "RecipeIngredientId",
                principalTable: "recipe_ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_recipe_ingredient_recipe_ingredient_RecipeIngred~",
                table: "user_feast_recipe_ingredient");

            migrationBuilder.RenameColumn(
                name: "RecipeIngredientId",
                table: "user_feast_recipe_ingredient",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_user_feast_recipe_ingredient_RecipeIngredientId",
                table: "user_feast_recipe_ingredient",
                newName: "IX_user_feast_recipe_ingredient_IngredientId");

            migrationBuilder.AlterTable(
                name: "user_feast_recipe_ingredient",
                comment: "A day's workout routine");

            migrationBuilder.AlterTable(
                name: "user_feast_recipe",
                comment: "A day's workout routine");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "user_feast_recipe_ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_recipe_ingredient_ingredient_IngredientId",
                table: "user_feast_recipe_ingredient",
                column: "IngredientId",
                principalTable: "ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
