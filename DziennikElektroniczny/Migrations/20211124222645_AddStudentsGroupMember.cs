using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddStudentsGroupMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "StudentsGroupMember");
        }
    }
}
