using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RefactyorIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "user_recipe",
                newName: "Section");

            migrationBuilder.AddColumn<int>(
                name: "Allergens",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IngredientGroups",
                table: "user_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserRecipeId",
                table: "user_feast_recipe",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExcludeAllergens",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "user_ingredient_group",
                columns: table => new
                {
                    Group = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<int>(type: "integer", nullable: false),
                    End = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ingredient_group", x => new { x.UserId, x.Group });
                    table.ForeignKey(
                        name: "FK_user_ingredient_group_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_user_recipe",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RecipeId = table.Column<int>(type: "integer", nullable: false),
                    Ignore = table.Column<bool>(type: "boolean", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: true),
                    LastSeen = table.Column<DateOnly>(type: "date", nullable: false),
                    LastVisible = table.Column<DateOnly>(type: "date", nullable: false),
                    RefreshAfter = table.Column<DateOnly>(type: "date", nullable: true),
                    UserRecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_user_recipe", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_user_user_recipe_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_user_recipe_user_recipe_UserRecipeId",
                        column: x => x.UserRecipeId,
                        principalTable: "user_recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User's progression level of an exercise");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_recipe_UserRecipeId",
                table: "user_feast_recipe",
                column: "UserRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_recipe_UserRecipeId",
                table: "user_user_recipe",
                column: "UserRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_feast_recipe_user_recipe_UserRecipeId",
                table: "user_feast_recipe",
                column: "UserRecipeId",
                principalTable: "user_recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_feast_recipe_user_recipe_UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropTable(
                name: "user_ingredient_group");

            migrationBuilder.DropTable(
                name: "user_user_recipe");

            migrationBuilder.DropIndex(
                name: "IX_user_feast_recipe_UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropColumn(
                name: "Allergens",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "IngredientGroups",
                table: "user_recipe");

            migrationBuilder.DropColumn(
                name: "UserRecipeId",
                table: "user_feast_recipe");

            migrationBuilder.DropColumn(
                name: "ExcludeAllergens",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "Section",
                table: "user_recipe",
                newName: "Type");
        }
    }
}
