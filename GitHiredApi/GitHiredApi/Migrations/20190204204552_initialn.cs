using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHiredApi.Migrations
{
    public partial class initialn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_requiredskills_Jobs_JobID",
                table: "requiredskills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requiredskills",
                table: "requiredskills");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "requiredskills",
                newName: "RequiredSkills");

            migrationBuilder.RenameColumn(
                name: "skill",
                table: "RequiredSkills",
                newName: "Skill");

            migrationBuilder.RenameIndex(
                name: "IX_requiredskills_JobID",
                table: "RequiredSkills",
                newName: "IX_RequiredSkills_JobID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Jobs",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequiredSkills",
                table: "RequiredSkills",
                columns: new[] { "Skill", "JobID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RequiredSkills_Jobs_JobID",
                table: "RequiredSkills",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequiredSkills_Jobs_JobID",
                table: "RequiredSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequiredSkills",
                table: "RequiredSkills");

            migrationBuilder.RenameTable(
                name: "RequiredSkills",
                newName: "requiredskills");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "requiredskills",
                newName: "skill");

            migrationBuilder.RenameIndex(
                name: "IX_RequiredSkills_JobID",
                table: "requiredskills",
                newName: "IX_requiredskills_JobID");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "Jobs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requiredskills",
                table: "requiredskills",
                columns: new[] { "skill", "JobID" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Title", "Website" },
                values: new object[] { 1, "", "Technology", "Microsoft", "www.microsoft.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Title", "Website" },
                values: new object[] { 2, "", "e-commerce marketplace", "Groupon", "www.groupon.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_requiredskills_Jobs_JobID",
                table: "requiredskills",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
