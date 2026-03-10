using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNutrientTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NutrientId",
                table: "dietary_intake",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "nutrient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutrient", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dietary_intake_NutrientId",
                table: "dietary_intake",
                column: "NutrientId");

            migrationBuilder.AddForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake",
                column: "NutrientId",
                principalTable: "nutrient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dietary_intake_nutrient_NutrientId",
                table: "dietary_intake");

            migrationBuilder.DropTable(
                name: "nutrient");

            migrationBuilder.DropIndex(
                name: "IX_dietary_intake_NutrientId",
                table: "dietary_intake");

            migrationBuilder.DropColumn(
                name: "NutrientId",
                table: "dietary_intake");
        }
    }
}
