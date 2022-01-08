using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class TryToFixDoubleFKFromOneTableV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message",
                column: "FromPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message",
                column: "FromPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
