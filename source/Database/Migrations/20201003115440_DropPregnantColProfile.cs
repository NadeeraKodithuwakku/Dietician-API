using Microsoft.EntityFrameworkCore.Migrations;

namespace Dietician.Database.Migrations
{
    public partial class DropPregnantColProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Users_UserId",
                schema: "Progress",
                table: "Progress");

            migrationBuilder.DropColumn(
                name: "IsPregnant",
                schema: "Profile",
                table: "Profiles");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Progress",
                table: "Progress",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Users_UserId",
                schema: "Progress",
                table: "Progress",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Users_UserId",
                schema: "Progress",
                table: "Progress");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                schema: "Progress",
                table: "Progress",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<bool>(
                name: "IsPregnant",
                schema: "Profile",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Users_UserId",
                schema: "Progress",
                table: "Progress",
                column: "UserId",
                principalSchema: "User",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
