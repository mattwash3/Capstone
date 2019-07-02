using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "TaskLog",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaskEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaskType = table.Column<string>(nullable: true),
                    TaskLogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskEntry_TaskLog_TaskLogId",
                        column: x => x.TaskLogId,
                        principalTable: "TaskLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntry_TaskLogId",
                table: "TaskEntry",
                column: "TaskLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskEntry");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "TaskLog");
        }
    }
}
