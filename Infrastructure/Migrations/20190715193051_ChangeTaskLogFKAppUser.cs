using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ChangeTaskLogFKAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog");

            migrationBuilder.DropIndex(
                name: "IX_TaskLog_EmployeeId",
                table: "TaskLog");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TaskLog");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TaskLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskLog_ApplicationUserId",
                table: "TaskLog",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLog_AspNetUsers_ApplicationUserId",
                table: "TaskLog",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLog_AspNetUsers_ApplicationUserId",
                table: "TaskLog");

            migrationBuilder.DropIndex(
                name: "IX_TaskLog_ApplicationUserId",
                table: "TaskLog");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TaskLog");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "TaskLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskLog_EmployeeId",
                table: "TaskLog",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
