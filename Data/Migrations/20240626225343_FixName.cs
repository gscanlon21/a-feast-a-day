using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class FixName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ingredient_ingredient_ParentId",
                table: "ingredient");

            migrationBuilder.DropIndex(
                name: "IX_ingredient_ParentId",
                table: "ingredient");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ingredient");

            migrationBuilder.CreateTable(
                name: "ingredient_alternative",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    AlternativeIngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_alternative", x => new { x.IngredientId, x.AlternativeIngredientId });
                    table.ForeignKey(
                        name: "FK_ingredient_alternative_ingredient_AlternativeIngredientId",
                        column: x => x.AlternativeIngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingredient_alternative_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Alternative ingredients");

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_alternative_AlternativeIngredientId",
                table: "ingredient_alternative",
                column: "AlternativeIngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient_alternative");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ingredient",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ingredient_ParentId",
                table: "ingredient",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ingredient_ingredient_ParentId",
                table: "ingredient",
                column: "ParentId",
                principalTable: "ingredient",
                principalColumn: "Id");
        }
    }
}
