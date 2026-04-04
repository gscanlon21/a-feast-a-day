using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UseCompositeKeyHCNutrients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hc_nutrient",
                table: "hc_nutrient");

            migrationBuilder.DropIndex(
                name: "IX_hc_nutrient_IngredientId_Nutrients",
                table: "hc_nutrient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "hc_nutrient");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hc_nutrient",
                table: "hc_nutrient",
                columns: new[] { "IngredientId", "Nutrients" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hc_nutrient",
                table: "hc_nutrient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "hc_nutrient",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_hc_nutrient",
                table: "hc_nutrient",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_hc_nutrient_IngredientId_Nutrients",
                table: "hc_nutrient",
                columns: new[] { "IngredientId", "Nutrients" },
                unique: true);
        }
    }
}
