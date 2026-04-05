using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFeastPerf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_feast_UserId",
                table: "user_feast");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_UserId_Date",
                table: "user_feast",
                columns: new[] { "UserId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_user_feast_UserId_Date",
                table: "user_feast");

            migrationBuilder.CreateIndex(
                name: "IX_user_feast_UserId",
                table: "user_feast",
                column: "UserId");
        }
    }
}
