using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
