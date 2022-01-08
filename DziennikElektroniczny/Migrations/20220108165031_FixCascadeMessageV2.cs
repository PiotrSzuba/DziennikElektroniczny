using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeMessageV2 : Migration
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
                onDelete: ReferentialAction.Cascade);
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
