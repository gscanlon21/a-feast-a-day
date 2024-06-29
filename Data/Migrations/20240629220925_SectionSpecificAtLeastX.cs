using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SectionSpecificAtLeastX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtLeastXServingsPerRecipe",
                table: "user");

            migrationBuilder.DropColumn(
                name: "AtLeastXUniqueNutrientsPerRecipe",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXServingsPerRecipe",
                table: "user_serving",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXUniqueNutrientsPerRecipe",
                table: "user_serving",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtLeastXServingsPerRecipe",
                table: "user_serving");

            migrationBuilder.DropColumn(
                name: "AtLeastXUniqueNutrientsPerRecipe",
                table: "user_serving");

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXServingsPerRecipe",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXUniqueNutrientsPerRecipe",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
