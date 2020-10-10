using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddCurrentWeightCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Target",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentWeight",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TargetWeight",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "TargetWeight",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.AddColumn<decimal>(
                name: "Target",
                schema: "Profile",
                table: "Profiles",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
