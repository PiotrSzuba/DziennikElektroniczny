using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixGroupTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup",
                column: "TeacherPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup",
                column: "TeacherPersonId",
                unique: true,
                filter: "[TeacherPersonId] IS NOT NULL");
        }
    }
}
