using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SquashMigrations46 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtLeastXUniqueMusclesPerExercise_Accessory",
                table: "user");

            migrationBuilder.DropColumn(
                name: "AtLeastXUniqueMusclesPerExercise_Flexibility",
                table: "user");

            migrationBuilder.DropColumn(
                name: "AtLeastXUniqueMusclesPerExercise_Mobility",
                table: "user");

            migrationBuilder.DropColumn(
                name: "IgnorePrerequisites",
                table: "user");

            migrationBuilder.DropColumn(
                name: "WeightIsolationXTimesMore",
                table: "user");

            migrationBuilder.DropColumn(
                name: "WeightSecondaryMusclesXTimesLess",
                table: "user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtLeastXUniqueMusclesPerExercise_Accessory",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXUniqueMusclesPerExercise_Flexibility",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AtLeastXUniqueMusclesPerExercise_Mobility",
                table: "user",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IgnorePrerequisites",
                table: "user",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "WeightIsolationXTimesMore",
                table: "user",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WeightSecondaryMusclesXTimesLess",
                table: "user",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
