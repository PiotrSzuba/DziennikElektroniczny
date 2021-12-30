using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddZeroToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EventParticipators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventParticipators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EventParticipators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventParticipators",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
