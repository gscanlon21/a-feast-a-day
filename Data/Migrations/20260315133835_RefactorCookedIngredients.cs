using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorCookedIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipe_ingredient_ingredient_CookedIngredientId",
                table: "recipe_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_recipe_ingredient_CookedIngredientId",
                table: "recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "CookedIngredientId",
                table: "recipe_ingredient");

            migrationBuilder.AddColumn<string>(
                name: "FoodName",
                table: "ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodName",
                table: "ingredient");

            migrationBuilder.AddColumn<int>(
                name: "CookedIngredientId",
                table: "recipe_ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipe_ingredient_CookedIngredientId",
                table: "recipe_ingredient",
                column: "CookedIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipe_ingredient_ingredient_CookedIngredientId",
                table: "recipe_ingredient",
                column: "CookedIngredientId",
                principalTable: "ingredient",
                principalColumn: "Id");
        }
    }
}
