using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowStaticImages",
                table: "user",
                newName: "ShareMyRecipes");

            migrationBuilder.AddColumn<int>(
                name: "CookTime",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrepTime",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Servings",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookTime",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "Servings",
                table: "user_recipe");

            migrationBuilder.RenameColumn(
                name: "ShareMyRecipes",
                table: "user",
                newName: "ShowStaticImages");
        }
    }
}
