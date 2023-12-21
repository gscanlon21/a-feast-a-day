using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<int>(
                name: "QuantityDenominator",
                table: "user_recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantityNumerator",
                table: "user_recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityDenominator",
                table: "user_recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "QuantityNumerator",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "user_recipe_ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
