using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddSubjectPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPersonId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherPersonId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentPersonId",
                table: "Subject",
                column: "StudentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_TeacherPersonId",
                table: "Subject",
                column: "TeacherPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Person_StudentPersonId",
                table: "Subject",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Person_StudentPersonId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Person_TeacherPersonId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentPersonId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_TeacherPersonId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentPersonId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "TeacherPersonId",
                table: "Subject");
        }
    }
}
