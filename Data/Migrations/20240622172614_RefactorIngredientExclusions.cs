using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class RefactorIngredientExclusions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUser");

            migrationBuilder.AddColumn<bool>(
                name: "Ignore",
                table: "user_ingredient",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityNumerator",
                table: "recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuantityDenominator",
                table: "recipe_ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ignore",
                table: "user_ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityNumerator",
                table: "recipe_ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "QuantityDenominator",
                table: "recipe_ingredient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "IngredientUser",
                columns: table => new
                {
                    IngredientExclusionsId = table.Column<int>(type: "integer", nullable: false),
                    UserExclusionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientUser", x => new { x.IngredientExclusionsId, x.UserExclusionsId });
                    table.ForeignKey(
                        name: "FK_IngredientUser_ingredient_IngredientExclusionsId",
                        column: x => x.IngredientExclusionsId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientUser_user_UserExclusionsId",
                        column: x => x.UserExclusionsId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientUser_UserExclusionsId",
                table: "IngredientUser",
                column: "UserExclusionsId");
        }
    }
}
