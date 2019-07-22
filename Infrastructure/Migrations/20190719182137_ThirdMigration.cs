using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TaskEntry",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntry_ApplicationUserId",
                table: "TaskEntry",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskEntry_AspNetUsers_ApplicationUserId",
                table: "TaskEntry",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskEntry_AspNetUsers_ApplicationUserId",
                table: "TaskEntry");

            migrationBuilder.DropIndex(
                name: "IX_TaskEntry_ApplicationUserId",
                table: "TaskEntry");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TaskEntry");
        }
    }
}
