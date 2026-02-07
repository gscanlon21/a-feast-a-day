using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFoodPreferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_food_preference",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Allergen = table.Column<long>(type: "bigint", nullable: false),
                    FoodPreference = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_food_preference", x => new { x.UserId, x.Allergen });
                    table.ForeignKey(
                        name: "FK_user_food_preference_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_food_preference");
        }
    }
}
