using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddPlanTableNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Target",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Goal",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pace",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FoodType",
                schema: "Food",
                table: "Foods",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Goal",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Pace",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "FoodType",
                schema: "Food",
                table: "Foods");

            migrationBuilder.AlterColumn<decimal>(
                name: "Target",
                schema: "Plan",
                table: "Plans",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                schema: "Plan",
                table: "Plans",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);
        }
    }
}
