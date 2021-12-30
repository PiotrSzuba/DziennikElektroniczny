using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikElektroniczny.Migrations
{
    public partial class AddPersonalInfoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parent_People_ParentPersonId",
                table: "Parent");

            migrationBuilder.DropForeignKey(
                name: "FK_Parent_People_StudentPersonId",
                table: "Parent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parent",
                table: "Parent");

            migrationBuilder.RenameTable(
                name: "Parent",
                newName: "parents");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_StudentPersonId",
                table: "parents",
                newName: "IX_parents_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Parent_ParentPersonId",
                table: "parents",
                newName: "IX_parents_ParentPersonId");

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_parents",
                table: "parents",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonalInfoId",
                table: "People",
                column: "PersonalInfoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonalInfos_PersonalInfoId",
                table: "People",
                column: "PersonalInfoId",
                principalTable: "PersonalInfos",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parents_People_ParentPersonId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_parents_People_StudentPersonId",
                table: "parents");

            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonalInfos_PersonalInfoId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonalInfoId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_parents",
                table: "parents");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "People");

            migrationBuilder.RenameTable(
                name: "parents",
                newName: "Parent");

            migrationBuilder.RenameIndex(
                name: "IX_parents_StudentPersonId",
                table: "Parent",
                newName: "IX_Parent_StudentPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_parents_ParentPersonId",
                table: "Parent",
                newName: "IX_Parent_ParentPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parent",
                table: "Parent",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_People_ParentPersonId",
                table: "Parent",
                column: "ParentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parent_People_StudentPersonId",
                table: "Parent",
                column: "StudentPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
