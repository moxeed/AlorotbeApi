using Microsoft.EntityFrameworkCore.Migrations;

namespace Alorotbe.Persistence.Migrations
{
    public partial class SupporterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Supporter",
                newName: "TelegramId");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Supporter",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Supporter",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Supporter",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Supporter",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sheba",
                table: "Supporter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentScore",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MajorId = table.Column<int>(type: "int", nullable: false),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalStudy = table.Column<int>(type: "int", nullable: false),
                    TotalTestCount = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentScore");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Supporter");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Supporter");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Supporter");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Supporter");

            migrationBuilder.DropColumn(
                name: "Sheba",
                table: "Supporter");

            migrationBuilder.RenameColumn(
                name: "TelegramId",
                table: "Supporter",
                newName: "LastName");
        }
    }
}
