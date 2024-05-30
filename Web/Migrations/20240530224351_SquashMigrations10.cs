using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GramsInACup",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServingSizeGrams",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GramsInACup",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "ServingSizeGrams",
                table: "ingredient");
        }
    }
}
