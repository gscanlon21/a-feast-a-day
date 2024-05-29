using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nutrients",
                table: "ingredient");

            migrationBuilder.CreateTable(
                name: "nutrient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IngredientId = table.Column<int>(type: "integer", nullable: true),
                    Nutrients = table.Column<long>(type: "bigint", nullable: false),
                    PercentDailyValue = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nutrient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id");
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateIndex(
                name: "IX_nutrient_IngredientId",
                table: "nutrient",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutrient");

            migrationBuilder.AddColumn<long>(
                name: "Nutrients",
                table: "ingredient",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
