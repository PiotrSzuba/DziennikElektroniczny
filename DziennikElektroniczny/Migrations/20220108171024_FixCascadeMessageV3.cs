using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeMessageV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message",
                column: "ToPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message",
                column: "ToPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
