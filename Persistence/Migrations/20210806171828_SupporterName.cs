using Microsoft.EntityFrameworkCore.Migrations;

namespace Alorotbe.Persistence.Migrations
{
    public partial class SupporterName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuppporterId",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuppporterId",
                table: "Student",
                type: "int",
                nullable: true);
        }
    }
}
