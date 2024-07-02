using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorIngredientPrerequisites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                table: "user_ingredient");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "user_recipe");

            migrationBuilder.AlterColumn<int>(
                name: "SubstituteIngredientId",
                table: "user_ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SubstituteRecipeId",
                table: "user_ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_SubstituteRecipeId",
                table: "user_ingredient",
                column: "SubstituteRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                table: "user_ingredient",
                column: "SubstituteIngredientId",
                principalTable: "ingredient",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_ingredient_recipe_SubstituteRecipeId",
                table: "user_ingredient",
                column: "SubstituteRecipeId",
                principalTable: "recipe",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                table: "user_ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_user_ingredient_recipe_SubstituteRecipeId",
                table: "user_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_user_ingredient_SubstituteRecipeId",
                table: "user_ingredient");

            migrationBuilder.DropColumn(
                name: "SubstituteRecipeId",
                table: "user_ingredient");

            migrationBuilder.AddColumn<int>(
                name: "Scale",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SubstituteIngredientId",
                table: "user_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                table: "user_ingredient",
                column: "SubstituteIngredientId",
                principalTable: "ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
