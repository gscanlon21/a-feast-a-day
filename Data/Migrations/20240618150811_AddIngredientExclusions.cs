using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientExclusions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientUser");
        }
    }
}
