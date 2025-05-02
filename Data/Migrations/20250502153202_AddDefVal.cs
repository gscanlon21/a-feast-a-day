using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefVal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SubstituteScale",
                table: "user_ingredient",
                type: "double precision",
                nullable: false,
                defaultValue: 1.0,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Scale",
                table: "ingredient_alternative",
                type: "double precision",
                nullable: false,
                defaultValue: 1.0,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SubstituteScale",
                table: "user_ingredient",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 1.0);

            migrationBuilder.AlterColumn<double>(
                name: "Scale",
                table: "ingredient_alternative",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldDefaultValue: 1.0);
        }
    }
}
