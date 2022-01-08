using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupMember_Person_StudentPersonId",
                table: "StudentsGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Person_TeacherPersonId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupMember_Person_StudentPersonId",
                table: "StudentsGroupMember",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Person_TeacherPersonId",
                table: "Subject",
                column: "TeacherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupMember_Person_StudentPersonId",
                table: "StudentsGroupMember");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Person_TeacherPersonId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupMember_Person_StudentPersonId",
                table: "StudentsGroupMember",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Person_TeacherPersonId",
                table: "Subject",
                column: "TeacherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
