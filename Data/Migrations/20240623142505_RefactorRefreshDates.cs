using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RefactorRefreshDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "Allergens",
                table: "recipe");

            migrationBuilder.AddColumn<int>(
                name: "LagRefreshXWeeks",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "user_recipe",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PadRefreshXWeeks",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "RefreshAfter",
                table: "user_recipe",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LagRefreshXWeeks",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "PadRefreshXWeeks",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "RefreshAfter",
                table: "user_recipe");

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "user_recipe",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "Allergens",
                table: "recipe",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
