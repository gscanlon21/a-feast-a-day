using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations53 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "UserIngredientId",
                table: "user_recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient",
                column: "UserIngredientId",
                principalTable: "user_ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "UserIngredientId",
                table: "user_recipe_ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_user_recipe_ingredient_user_ingredient_UserIngredientId",
                table: "user_recipe_ingredient",
                column: "UserIngredientId",
                principalTable: "user_ingredient",
                principalColumn: "Id");
        }
    }
}
