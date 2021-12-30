using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixSubjectPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Person_StudentPersonId",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentPersonId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentPersonId",
                table: "Subject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPersonId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentPersonId",
                table: "Subject",
                column: "StudentPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Person_StudentPersonId",
                table: "Subject",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
