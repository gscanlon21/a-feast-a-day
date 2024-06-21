using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSubstituteIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user_ingredient",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    SubstituteIngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_ingredient", x => new { x.UserId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_user_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_ingredient_ingredient_SubstituteIngredientId",
                        column: x => x.SubstituteIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_ingredient_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_ParentId",
                table: "ingredient",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_IngredientId",
                table: "user_ingredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ingredient_SubstituteIngredientId",
                table: "user_ingredient",
                column: "SubstituteIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_ingredient_ParentId",
                table: "ingredient",
                column: "ParentId",
                principalTable: "ingredient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_ingredient_ParentId",
                table: "ingredient");

            migrationBuilder.DropTable(
                name: "user_ingredient");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_ParentId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ingredient");
        }
    }
}
