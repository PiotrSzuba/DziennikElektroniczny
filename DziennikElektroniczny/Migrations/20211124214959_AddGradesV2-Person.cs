using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddGradesV2Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPersonId",
                table: "Grade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherPersonId",
                table: "Grade",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentPersonId",
                table: "Grade",
                column: "StudentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_TeacherPersonId",
                table: "Grade",
                column: "TeacherPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Person_StudentPersonId",
                table: "Grade",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Person_TeacherPersonId",
                table: "Grade",
                column: "TeacherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Person_StudentPersonId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Person_TeacherPersonId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_StudentPersonId",
                table: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Grade_TeacherPersonId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "StudentPersonId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "TeacherPersonId",
                table: "Grade");
        }
    }
}
