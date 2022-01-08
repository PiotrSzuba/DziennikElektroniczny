using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeStudentGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupMember_StudentsGroup_StudentsGroupId",
                table: "StudentsGroupMember");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupMember_StudentsGroup_StudentsGroupId",
                table: "StudentsGroupMember",
                column: "StudentsGroupId",
                principalTable: "StudentsGroup",
                principalColumn: "StudentsGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsGroupMember_StudentsGroup_StudentsGroupId",
                table: "StudentsGroupMember");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsGroupMember_StudentsGroup_StudentsGroupId",
                table: "StudentsGroupMember",
                column: "StudentsGroupId",
                principalTable: "StudentsGroup",
                principalColumn: "StudentsGroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
