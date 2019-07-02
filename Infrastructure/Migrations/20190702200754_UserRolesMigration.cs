using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UserRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Employee",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "AspNetUsers",
                newName: "RoleString");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleString",
                table: "AspNetUsers",
                newName: "Manager");

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "AspNetUsers",
                nullable: true);
        }
    }
}
