using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddConstraintToProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                schema: "Profile",
                table: "Profiles",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                schema: "Profile",
                table: "Profiles",
                column: "UserId");
        }
    }
}
