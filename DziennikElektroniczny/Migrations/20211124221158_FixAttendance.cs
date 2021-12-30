using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPersonId",
                table: "Attendance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentPersonId",
                table: "Attendance",
                column: "StudentPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Person_StudentPersonId",
                table: "Attendance",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Person_StudentPersonId",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_StudentPersonId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "StudentPersonId",
                table: "Attendance");
        }
    }
}
