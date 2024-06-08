using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RenamePrimaryToFavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "user_recipe");

            migrationBuilder.AddColumn<bool>(
                name: "Favorite",
                table: "user_recipe",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Favorite",
                table: "user_recipe");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "user_recipe",
                type: "boolean",
                nullable: true);
        }
    }
}
