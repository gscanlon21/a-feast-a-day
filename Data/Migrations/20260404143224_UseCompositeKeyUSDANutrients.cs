using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UseCompositeKeyUSDANutrients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usda_nutrient",
                table: "usda_nutrient");

            migrationBuilder.DropIndex(
                name: "IX_usda_nutrient_IngredientId_Nutrients",
                table: "usda_nutrient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "usda_nutrient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usda_nutrient",
                table: "usda_nutrient",
                columns: new[] { "IngredientId", "Nutrients" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usda_nutrient",
                table: "usda_nutrient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "usda_nutrient",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_usda_nutrient",
                table: "usda_nutrient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_usda_nutrient_IngredientId_Nutrients",
                table: "usda_nutrient",
                columns: new[] { "IngredientId", "Nutrients" },
                unique: true);
        }
    }
}
