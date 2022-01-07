using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixedManyToManyV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPerson");

            migrationBuilder.DropTable(
                name: "PersonStudentsGroup");

            migrationBuilder.CreateTable(
                name: "EventParticipator",
                columns: table => new
                {
                    EventParticipatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipator", x => x.EventParticipatorId);
                    table.ForeignKey(
                        name: "FK_EventParticipator_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventParticipator_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentsGroupMember",
                columns: table => new
                {
                    StudentsGroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentsGroupId = table.Column<int>(type: "int", nullable: true),
                    StudentPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroupMember", x => x.StudentsGroupMemberId);
                    table.ForeignKey(
                        name: "FK_StudentsGroupMember_Person_StudentPersonId",
                        column: x => x.StudentPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentsGroupMember_StudentsGroup_StudentsGroupId",
                        column: x => x.StudentsGroupId,
                        principalTable: "StudentsGroup",
                        principalColumn: "StudentsGroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipator_EventId",
                table: "EventParticipator",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipator_PersonId",
                table: "EventParticipator",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupMember_StudentPersonId",
                table: "StudentsGroupMember",
                column: "StudentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupMember_StudentsGroupId",
                table: "StudentsGroupMember",
                column: "StudentsGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipator");

            migrationBuilder.DropTable(
                name: "StudentsGroupMember");

            migrationBuilder.CreateTable(
                name: "EventPerson",
                columns: table => new
                {
                    EventsEventId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPerson", x => new { x.EventsEventId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_EventPerson_Event_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPerson_Person_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonStudentsGroup",
                columns: table => new
                {
                    StudentsGroupsStudentsGroupId = table.Column<int>(type: "int", nullable: false),
                    StudentsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonStudentsGroup", x => new { x.StudentsGroupsStudentsGroupId, x.StudentsPersonId });
                    table.ForeignKey(
                        name: "FK_PersonStudentsGroup_Person_StudentsPersonId",
                        column: x => x.StudentsPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonStudentsGroup_StudentsGroup_StudentsGroupsStudentsGroupId",
                        column: x => x.StudentsGroupsStudentsGroupId,
                        principalTable: "StudentsGroup",
                        principalColumn: "StudentsGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPerson_PersonsPersonId",
                table: "EventPerson",
                column: "PersonsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStudentsGroup_StudentsPersonId",
                table: "PersonStudentsGroup",
                column: "StudentsPersonId");
        }
    }
}
