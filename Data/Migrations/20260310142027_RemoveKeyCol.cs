using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveKeyCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "dietary_intake");

            migrationBuilder.AlterColumn<int>(
                name: "NutrientId",
                table: "dietary_intake",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake",
                column: "NutrientId",
                principalTable: "nutrient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake");

            migrationBuilder.AlterColumn<int>(
                name: "NutrientId",
                table: "dietary_intake",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "dietary_intake",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake",
                column: "NutrientId",
                principalTable: "nutrient",
                principalColumn: "Id");
        }
    }
}
