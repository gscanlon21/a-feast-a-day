using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_UserId",
                table: "user_recipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_recipe_user_UserId",
                table: "user_recipe",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_recipe_user_UserId",
                table: "user_recipe");

            migrationBuilder.DropIndex(
                name: "IX_user_recipe_UserId",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "user_recipe");
        }
    }
}
