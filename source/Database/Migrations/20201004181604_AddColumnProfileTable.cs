using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddColumnProfileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goal",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pace",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Target",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Goal",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Pace",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Target",
                schema: "Profile",
                table: "Profiles");
        }
    }
}
