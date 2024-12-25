using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGeneticsStudies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gene", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "snp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    GeneId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_snp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_snp_gene_GeneId",
                        column: x => x.GeneId,
                        principalTable: "gene",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: false),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    SNPId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study", x => x.Id);
                    table.ForeignKey(
                        name: "FK_study_snp_SNPId",
                        column: x => x.SNPId,
                        principalTable: "snp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "study_ingredient",
                columns: table => new
                {
                    StudyId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_study_ingredient", x => new { x.StudyId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_study_ingredient_ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_study_ingredient_study_StudyId",
                        column: x => x.StudyId,
                        principalTable: "study",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_snp_GeneId",
                table: "snp",
                column: "GeneId");

            migrationBuilder.CreateIndex(
                name: "IX_study_SNPId",
                table: "study",
                column: "SNPId");

            migrationBuilder.CreateIndex(
                name: "IX_study_ingredient_IngredientId",
                table: "study_ingredient",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "study_ingredient");

            migrationBuilder.DropTable(
                name: "study");

            migrationBuilder.DropTable(
                name: "snp");

            migrationBuilder.DropTable(
                name: "gene");
        }
    }
}
