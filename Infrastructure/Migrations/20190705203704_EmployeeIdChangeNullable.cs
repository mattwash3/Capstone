using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class EmployeeIdChangeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TaskLog",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TaskLog",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_TaskLog_Employee_EmployeeId",
                table: "TaskLog",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
