using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_ClassRoom_ClassRoomId",
                table: "Subject",
                column: "ClassRoomId",
                principalTable: "ClassRoom",
                principalColumn: "ClassRoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
