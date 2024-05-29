using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "Minerals",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "Vitamins",
                table: "ingredient");

            migrationBuilder.AlterColumn<decimal>(
                name: "Nutrient",
                table: "user_nutrient",
                type: "numeric(20,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Nutrients",
                table: "ingredient",
                type: "numeric(20,0)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nutrients",
                table: "ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "Nutrient",
                table: "user_nutrient",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(20,0)");

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minerals",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitamins",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
