using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeSubjectInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectInfo_SubjectInfoId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectInfo_SubjectInfoId",
                table: "Subject",
                column: "SubjectInfoId",
                principalTable: "SubjectInfo",
                principalColumn: "SubjectInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectInfo_SubjectInfoId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectInfo_SubjectInfoId",
                table: "Subject",
                column: "SubjectInfoId",
                principalTable: "SubjectInfo",
                principalColumn: "SubjectInfoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
