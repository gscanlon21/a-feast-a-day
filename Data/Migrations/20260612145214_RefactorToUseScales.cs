using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorToUseScales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "user_nutrient");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "user_nutrient");

            migrationBuilder.AddColumn<double>(
                name: "RDAScale",
                table: "user_nutrient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TULScale",
                table: "user_nutrient",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RDAScale",
                table: "user_nutrient");

            migrationBuilder.DropColumn(
                name: "TULScale",
                table: "user_nutrient");

            migrationBuilder.AddColumn<int>(
                name: "End",
                table: "user_nutrient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Start",
                table: "user_nutrient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
