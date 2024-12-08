using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIngredientRecipe2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_ingredient",
                table: "user_ingredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_ingredient",
                table: "user_ingredient",
                columns: new[] { "UserId", "IngredientId", "RecipeId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_ingredient",
                table: "user_ingredient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_ingredient",
                table: "user_ingredient",
                columns: new[] { "UserId", "IngredientId" });
        }
    }
}
