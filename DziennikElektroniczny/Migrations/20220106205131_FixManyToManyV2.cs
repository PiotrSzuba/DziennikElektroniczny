using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class FixManyToManyV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsGroupMember");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup");

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
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup",
                column: "TeacherPersonId",
                unique: true,
                filter: "[TeacherPersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonStudentsGroup_StudentsPersonId",
                table: "PersonStudentsGroup",
                column: "StudentsPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonStudentsGroup");

            migrationBuilder.DropIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup");

            migrationBuilder.CreateTable(
                name: "StudentsGroupMember",
                columns: table => new
                {
                    StudentsGroupMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentPersonId = table.Column<int>(type: "int", nullable: true),
                    StudentsGroupId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup",
                column: "TeacherPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupMember_StudentPersonId",
                table: "StudentsGroupMember",
                column: "StudentPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroupMember_StudentsGroupId",
                table: "StudentsGroupMember",
                column: "StudentsGroupId");
        }
    }
}
