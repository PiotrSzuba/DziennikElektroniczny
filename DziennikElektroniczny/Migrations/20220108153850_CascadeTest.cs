using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class CascadeTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Lesson_LessonId",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Lesson_LessonId",
                table: "Attendance",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Lesson_LessonId",
                table: "Attendance");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Lesson_LessonId",
                table: "Attendance",
                column: "LessonId",
                principalTable: "Lesson",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
