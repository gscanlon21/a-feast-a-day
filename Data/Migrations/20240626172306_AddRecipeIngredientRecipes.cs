using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeIngredientRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipe_ingredient_ingredient_IngredientId",
                table: "recipe_ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "recipe_ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IngredientRecipeId",
                table: "recipe_ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_IngredientRecipeId",
                table: "recipe_ingredient",
                column: "IngredientRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_ingredient_ingredient_IngredientId",
                table: "recipe_ingredient",
                column: "IngredientId",
                principalTable: "ingredient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_ingredient_recipe_IngredientRecipeId",
                table: "recipe_ingredient",
                column: "IngredientRecipeId",
                principalTable: "recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipe_ingredient_ingredient_IngredientId",
                table: "recipe_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_recipe_ingredient_recipe_IngredientRecipeId",
                table: "recipe_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_recipe_ingredient_IngredientRecipeId",
                table: "recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "IngredientRecipeId",
                table: "recipe_ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_ingredient_ingredient_IngredientId",
                table: "recipe_ingredient",
                column: "IngredientId",
                principalTable: "ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
