using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class AddPlanTableUserIdFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Profile",
                table: "Profiles",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                schema: "Plan",
                table: "Plans",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "FoodType",
                schema: "Food",
                table: "Foods",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plans_UserId",
                schema: "Plan",
                table: "Plans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Users_UserId",
                schema: "Plan",
                table: "Plans",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                schema: "Profile",
                table: "Profiles",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Users_UserId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Plans_UserId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Plan",
                table: "Plans");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Profile",
                table: "Profiles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "FoodType",
                schema: "Food",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                schema: "Profile",
                table: "Profiles",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
