using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddFoodCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodCategory",
                schema: "Food",
                table: "Foods",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodCategory",
                schema: "Food",
                table: "Foods");
        }
    }
}
