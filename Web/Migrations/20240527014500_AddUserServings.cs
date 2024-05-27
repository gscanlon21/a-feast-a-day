using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class AddUserServings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastVisible",
                table: "user_user_recipe");

            migrationBuilder.DropColumn(
                name: "RefreshAfter",
                table: "user_user_recipe");

            migrationBuilder.DropColumn(
                name: "WeeklyServings",
                table: "user");

            migrationBuilder.CreateTable(
                name: "user_serving",
                columns: table => new
                {
                    Section = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_serving", x => new { x.UserId, x.Section });
                    table.ForeignKey(
                        name: "FK_user_serving_user_UserId",
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
                name: "user_serving");

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastVisible",
                table: "user_user_recipe",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "RefreshAfter",
                table: "user_user_recipe",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeeklyServings",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
