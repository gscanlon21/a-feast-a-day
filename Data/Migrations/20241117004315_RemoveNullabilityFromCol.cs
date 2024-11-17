using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNullabilityFromCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nutrient_ingredient_IngredientId",
                table: "nutrient");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "nutrient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_nutrient_ingredient_IngredientId",
                table: "nutrient",
                column: "IngredientId",
                principalTable: "ingredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_nutrient_ingredient_IngredientId",
                table: "nutrient");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "nutrient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_nutrient_ingredient_IngredientId",
                table: "nutrient",
                column: "IngredientId",
                principalTable: "ingredient",
                principalColumn: "Id");
        }
    }
}
