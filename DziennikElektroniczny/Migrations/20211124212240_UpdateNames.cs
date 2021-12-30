using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class UpdateNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_People_FromPersonId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_People_ToPersonId",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_People_ParentPersonId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_People_StudentPersonId",
                table: "parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parents",
                table: "parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.RenameTable(
                name: "parents",
                newName: "Parents");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_parents_StudentPersonId",
                table: "Parents",
                newName: "IX_Parents_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_ParentPersonId",
                table: "Parents",
                newName: "IX_Parents_ParentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_ToPersonId",
                table: "Messages",
                newName: "IX_Messages_ToPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_FromPersonId",
                table: "Messages",
                newName: "IX_Messages_FromPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parents",
                table: "Parents",
                column: "ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People_FromPersonId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People_ToPersonId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_People_ParentPersonId",
                table: "Parents");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_People_StudentPersonId",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parents",
                table: "Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Parents",
                newName: "parents");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "messages");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_StudentPersonId",
                table: "parents",
                newName: "IX_parents_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Parents_ParentPersonId",
                table: "parents",
                newName: "IX_parents_ParentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ToPersonId",
                table: "messages",
                newName: "IX_messages_ToPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_FromPersonId",
                table: "messages",
                newName: "IX_messages_FromPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_parents",
                table: "parents",
                column: "ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_People_FromPersonId",
                table: "messages",
                column: "FromPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_People_ToPersonId",
                table: "messages",
                column: "ToPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_People_ParentPersonId",
                table: "parents",
                column: "ParentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parents_People_StudentPersonId",
                table: "parents",
                column: "StudentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
