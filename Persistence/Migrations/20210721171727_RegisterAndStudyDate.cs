using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alorotbe.Persistence.Migrations
{
    public partial class RegisterAndStudyDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Group_GroupId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Student",
                newName: "MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                newName: "IX_Student_MajorId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Course",
                newName: "MajorId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_GroupId",
                table: "Course",
                newName: "IX_Course_MajorId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<byte>(
                name: "Mood",
                table: "DailyStudy",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "StudeyDate",
                table: "DailyStudy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    MajorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.MajorId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_GradeId",
                table: "Student",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Major_MajorId",
                table: "Course",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "GradeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Major_MajorId",
                table: "Student",
                column: "MajorId",
                principalTable: "Major",
                principalColumn: "MajorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Major_MajorId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Grade_GradeId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Major_MajorId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropIndex(
                name: "IX_Student_GradeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudeyDate",
                table: "DailyStudy");

            migrationBuilder.RenameColumn(
                name: "MajorId",
                table: "Student",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_MajorId",
                table: "Student",
                newName: "IX_Student_GroupId");

            migrationBuilder.RenameColumn(
                name: "MajorId",
                table: "Course",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_MajorId",
                table: "Course",
                newName: "IX_Course_GroupId");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Mood",
                table: "DailyStudy",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Group_GroupId",
                table: "Course",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Group_GroupId",
                table: "Student",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
