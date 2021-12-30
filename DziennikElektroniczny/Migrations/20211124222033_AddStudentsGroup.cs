using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddStudentsGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsGroupId",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentsGroup",
                columns: table => new
                {
                    StudentsGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherPersonId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    YearOfStudy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsGroup", x => x.StudentsGroupId);
                    table.ForeignKey(
                        name: "FK_StudentsGroup_Person_TeacherPersonId",
                        column: x => x.TeacherPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StudentsGroupId",
                table: "Subject",
                column: "StudentsGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsGroup_TeacherPersonId",
                table: "StudentsGroup",
                column: "TeacherPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_StudentsGroup_StudentsGroupId",
                table: "Subject",
                column: "StudentsGroupId",
                principalTable: "StudentsGroup",
                principalColumn: "StudentsGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_StudentsGroup_StudentsGroupId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "StudentsGroup");

            migrationBuilder.DropIndex(
                name: "IX_Subject_StudentsGroupId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "StudentsGroupId",
                table: "Subject");
        }
    }
}
