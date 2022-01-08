using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
