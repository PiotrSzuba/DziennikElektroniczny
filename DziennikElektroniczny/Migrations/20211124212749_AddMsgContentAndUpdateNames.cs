using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddMsgContentAndUpdateNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People_FromPersonId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People_ToPersonId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_People_StudentPersonId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_People_TeacherPersonId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_People_ParentPersonId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_People_StudentPersonId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonalInfos_PersonalInfoId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipators",
                table: "EventParticipators");

            migrationBuilder.RenameTable(
                name: "PersonalInfos",
                newName: "PersonalInfo");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "Parent");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "EventParticipators",
                newName: "EventParticipator");

            migrationBuilder.RenameIndex(
                name: "IX_People_PersonalInfoId",
                table: "Person",
                newName: "IX_Person_PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_StudentPersonId",
                table: "Parent",
                newName: "IX_Parent_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_ParentPersonId",
                table: "Parent",
                newName: "IX_Parent_ParentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToPersonId",
                table: "Message",
                newName: "IX_Message_ToPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromPersonId",
                table: "Message",
                newName: "IX_Message_FromPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipators_PersonId",
                table: "EventParticipator",
                newName: "IX_EventParticipator_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipators_EventId",
                table: "EventParticipator",
                newName: "IX_EventParticipator_EventId");

            migrationBuilder.AddColumn<int>(
                name: "MessageContentId",
                table: "Message",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo",
                column: "PersonalInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipator",
                table: "EventParticipator",
                column: "EventParticipatorId");

            migrationBuilder.CreateTable(
                name: "MessageContent",
                columns: table => new
                {
                    MessageContentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageContent", x => x.MessageContentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_MessageContentId",
                table: "Message",
                column: "MessageContentId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message",
                column: "MessageContentId",
                principalTable: "MessageContent",
                principalColumn: "MessageContentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message",
                column: "FromPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message",
                column: "ToPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Person_StudentPersonId",
                table: "Note",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Person_TeacherPersonId",
                table: "Note",
                column: "TeacherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_Person_ParentPersonId",
                table: "Parent",
                column: "ParentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_Person_StudentPersonId",
                table: "Parent",
                column: "StudentPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PersonalInfo_PersonalInfoId",
                table: "Person",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Event_EventId",
                table: "EventParticipator");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipator_Person_PersonId",
                table: "EventParticipator");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_FromPersonId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Person_ToPersonId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Person_StudentPersonId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Person_TeacherPersonId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Parent_Person_ParentPersonId",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_Parent_Person_StudentPersonId",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_PersonalInfo_PersonalInfoId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "MessageContent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfo",
                table: "PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_MessageContentId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipator",
                table: "EventParticipator");

            migrationBuilder.DropColumn(
                name: "MessageContentId",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "PersonalInfo",
                newName: "PersonalInfos");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "Parents");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "EventParticipator",
                newName: "EventParticipators");

            migrationBuilder.RenameIndex(
                name: "IX_Person_PersonalInfoId",
                table: "People",
                newName: "IX_People_PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_StudentPersonId",
                table: "Parents",
                newName: "IX_Parents_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_ParentPersonId",
                table: "Parents",
                newName: "IX_Parents_ParentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ToPersonId",
                table: "Messages",
                newName: "IX_Messages_ToPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_FromPersonId",
                table: "Messages",
                newName: "IX_Messages_FromPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipator_PersonId",
                table: "EventParticipators",
                newName: "IX_EventParticipators_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_EventParticipator_EventId",
                table: "EventParticipators",
                newName: "IX_EventParticipators_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos",
                column: "PersonalInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipators",
                table: "EventParticipators",
                column: "EventParticipatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_Event_EventId",
                table: "EventParticipators",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipators_People_PersonId",
                table: "EventParticipators",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_People_FromPersonId",
                table: "Messages",
                column: "FromPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_People_ToPersonId",
                table: "Messages",
                column: "ToPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_People_StudentPersonId",
                table: "Note",
                column: "StudentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_People_TeacherPersonId",
                table: "Note",
                column: "TeacherPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_People_ParentPersonId",
                table: "Parents",
                column: "ParentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_People_StudentPersonId",
                table: "Parents",
                column: "StudentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonalInfos_PersonalInfoId",
                table: "People",
                column: "PersonalInfoId",
                principalTable: "PersonalInfos",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
