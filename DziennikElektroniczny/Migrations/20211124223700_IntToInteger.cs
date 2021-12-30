using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class IntToInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Subject",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "StudentsGroupMember",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "StudentsGroup",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Person",
                type: "integer(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Parent",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentPersonId",
                table: "Parent",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Note",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Note",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToPersonId",
                table: "Message",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromPersonId",
                table: "Message",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Lesson",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Grade",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Grade",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EventParticipator",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Attendance",
                type: "integer(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "StudentsGroupMember",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "StudentsGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Person",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer(10)")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Parent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentPersonId",
                table: "Parent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Note",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Note",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToPersonId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromPersonId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Lesson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherPersonId",
                table: "Grade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Grade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EventParticipator",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentPersonId",
                table: "Attendance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer(10)",
                oldNullable: true);
        }
    }
}
