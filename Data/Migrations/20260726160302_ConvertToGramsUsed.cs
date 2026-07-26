using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertToGramsUsed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoarseCut",
                table: "user_feast_recipe_ingredient");

            migrationBuilder.DropColumn(
                name: "Measure",
                table: "user_feast_recipe_ingredient");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "user_feast_recipe_ingredient",
                newName: "GramsUsed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GramsUsed",
                table: "user_feast_recipe_ingredient",
                newName: "Quantity");

            migrationBuilder.AddColumn<bool>(
                name: "CoarseCut",
                table: "user_feast_recipe_ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Measure",
                table: "user_feast_recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
