using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class RemovedFoodTableColumnFoodType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodType",
                schema: "Food",
                table: "Foods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodType",
                schema: "Food",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
