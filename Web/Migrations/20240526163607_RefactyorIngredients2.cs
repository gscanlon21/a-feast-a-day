using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RefactyorIngredients2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_recipe_user_recipe_UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropIndex(
                name: "IX_user_feast_recipe_UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropColumn(
                name: "UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_RecipeId",
                table: "user_feast_recipe",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_recipe_user_recipe_RecipeId",
                table: "user_feast_recipe",
                column: "RecipeId",
                principalTable: "user_recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_recipe_user_recipe_RecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropIndex(
                name: "IX_user_feast_recipe_RecipeId",
                table: "user_feast_recipe");

            migrationBuilder.AddColumn<int>(
                name: "UserRecipeId",
                table: "user_feast_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_UserRecipeId",
                table: "user_feast_recipe",
                column: "UserRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_recipe_user_recipe_UserRecipeId",
                table: "user_feast_recipe",
                column: "UserRecipeId",
                principalTable: "user_recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
