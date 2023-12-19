using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipe");

            migrationBuilder.CreateTable(
                name: "user_recipe",
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
                    table.PrimaryKey("PK_user_recipe", x => x.Id);
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateTable(
                name: "user_recipe_ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<string>(type: "text", nullable: false),
                    Measure = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_recipe_ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_recipe_ingredient_user_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "user_recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateTable(
                name: "user_recipe_instruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_recipe_instruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_recipe_instruction_user_recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "user_recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Recipes listed on the website");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_ingredient_RecipeId",
                table: "user_recipe_ingredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_recipe_instruction_RecipeId",
                table: "user_recipe_instruction",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_recipe_ingredient");

            migrationBuilder.DropTable(
                name: "user_recipe_instruction");

            migrationBuilder.DropTable(
                name: "user_recipe");

            migrationBuilder.CreateTable(
                name: "recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisabledReason = table.Column<string>(type: "text", nullable: true),
                    Groups = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipe", x => x.Id);
                },
                comment: "Recipes listed on the website");
        }
    }
}
