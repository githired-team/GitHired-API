using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHiredApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Industry = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyID = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    WageRange = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequiredSkills",
                columns: table => new
                {
                    Skill = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSkills", x => new { x.Skill, x.JobID });
                    table.ForeignKey(
                        name: "FK_RequiredSkills_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Name", "Website" },
                values: new object[] { 1, "a", "Real Estate", "Redfin", "www.Redfin.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Name", "Website" },
                values: new object[] { 2, "b", "Technology", "Microsoft", "www.Microsoft.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Name", "Website" },
                values: new object[] { 3, "c", "e-commerce Market", "Groupon", "www.Groupon.com" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 1, 1, " Solid understanding of Object Oriented Programming", "Java Developer", "Kirkland,WA", "8k monthly" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 2, 1, "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills", "Front-end Developer", "Bellevue,WA", "5k monthly" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 3, 2, "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills", "Front-end Developer", "Bellevue,WA", "5k monthly" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Skill", "JobID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Skill", "JobID" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "Skill", "JobID" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyID",
                table: "Jobs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_RequiredSkills_JobID",
                table: "RequiredSkills",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequiredSkills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
