using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIgnoreDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ignore",
                table: "user_recipe");

            migrationBuilder.AddColumn<DateOnly>(
                name: "IgnoreUntil",
                table: "user_recipe",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IgnoreUntil",
                table: "user_recipe");

            migrationBuilder.AddColumn<bool>(
                name: "Ignore",
                table: "user_recipe",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
