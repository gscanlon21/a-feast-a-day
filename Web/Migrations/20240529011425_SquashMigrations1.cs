using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_ingredient_group_user_UserId",
                table: "user_ingredient_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_ingredient_group",
                table: "user_ingredient_group");

            migrationBuilder.RenameTable(
                name: "user_ingredient_group",
                newName: "user_nutrient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_nutrient",
                table: "user_nutrient",
                columns: new[] { "UserId", "Group" });

            migrationBuilder.AddForeignKey(
                name: "FK_user_nutrient_user_UserId",
                table: "user_nutrient",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_nutrient_user_UserId",
                table: "user_nutrient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_nutrient",
                table: "user_nutrient");

            migrationBuilder.RenameTable(
                name: "user_nutrient",
                newName: "user_ingredient_group");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_ingredient_group",
                table: "user_ingredient_group",
                columns: new[] { "UserId", "Group" });

            migrationBuilder.AddForeignKey(
                name: "FK_user_ingredient_group_user_UserId",
                table: "user_ingredient_group",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
