using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddMsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Event",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Event",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Event",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Event",
                newName: "DndDate");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "Event",
                newName: "EventId");

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromPersonId = table.Column<int>(type: "int", nullable: true),
                    ToPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_messages_People_FromPersonId",
                        column: x => x.FromPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_People_ToPersonId",
                        column: x => x.ToPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messages_FromPersonId",
                table: "messages",
                column: "FromPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_messages_ToPersonId",
                table: "messages",
                column: "ToPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Event",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Event",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "DndDate",
                table: "Event",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Event",
                newName: "event_id");
        }
    }
}
