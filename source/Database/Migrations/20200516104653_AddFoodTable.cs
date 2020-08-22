using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddFoodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Food");

            migrationBuilder.CreateTable(
                name: "Foods",
                schema: "Food",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Fat = table.Column<float>(nullable: false),
                    Protine = table.Column<float>(nullable: false),
                    Carbohydrate = table.Column<float>(nullable: false),
                    IsVeg = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods",
                schema: "Food");
        }
    }
}
