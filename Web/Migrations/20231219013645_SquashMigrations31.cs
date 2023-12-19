using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<double>(
                name: "Quantity2",
                table: "user_recipe_ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity2",
                table: "user_recipe_ingredient");

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "user_recipe_ingredient",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
