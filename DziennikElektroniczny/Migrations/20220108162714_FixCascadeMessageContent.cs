using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixCascadeMessageContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message",
                column: "MessageContentId",
                principalTable: "MessageContent",
                principalColumn: "MessageContentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_MessageContent_MessageContentId",
                table: "Message",
                column: "MessageContentId",
                principalTable: "MessageContent",
                principalColumn: "MessageContentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
