using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateLogAndEntryClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LogDate",
                table: "TaskLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "TaskEntry",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTime",
                table: "TaskEntry",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogDate",
                table: "TaskLog");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "TaskEntry");

            migrationBuilder.DropColumn(
                name: "TaskTime",
                table: "TaskEntry");
        }
    }
}
