using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddDeaultMeasureToIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServingSizeGrams",
                table: "ingredient",
                newName: "GramsPerServing");

            migrationBuilder.RenameColumn(
                name: "GramsPerCup",
                table: "ingredient",
                newName: "GramsPerMeasure");

            migrationBuilder.AddColumn<int>(
                name: "DefaultMeasure",
                table: "ingredient",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultMeasure",
                table: "ingredient");

            migrationBuilder.RenameColumn(
                name: "GramsPerServing",
                table: "ingredient",
                newName: "ServingSizeGrams");

            migrationBuilder.RenameColumn(
                name: "GramsPerMeasure",
                table: "ingredient",
                newName: "GramsPerCup");
        }
    }
}
