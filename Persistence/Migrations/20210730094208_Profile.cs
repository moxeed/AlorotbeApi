using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alorotbe.Persistence.Migrations
{
    public partial class Profile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.MediaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_MediaId",
                table: "Student",
                column: "MediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Media_MediaId",
                table: "Student",
                column: "MediaId",
                principalTable: "Media",
                principalColumn: "MediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Media_MediaId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Student_MediaId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Student");
        }
    }
}
