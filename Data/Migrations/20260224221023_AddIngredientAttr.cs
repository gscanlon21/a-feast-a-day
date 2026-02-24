using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredient_attr",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    FDC_ID = table.Column<int>(type: "integer", nullable: true),
                    NDB_Number = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredient_attr", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_ingredient_attr_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredient_attr");
        }
    }
}
