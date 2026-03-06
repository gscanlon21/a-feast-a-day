using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameDateCols : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "dietary_intake",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "Checked",
                table: "dietary_intake",
                newName: "LastChecked");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "dietary_intake",
                newName: "Updated");

            migrationBuilder.RenameColumn(
                name: "LastChecked",
                table: "dietary_intake",
                newName: "Checked");
        }
    }
}
