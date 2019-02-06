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
                name: "Skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SkillName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.ID);
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
                    WageRange = table.Column<string>(nullable: true),
                    ApplicationUrl = table.Column<string>(nullable: true)
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
                    SkillID = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequiredSkills", x => new { x.SkillID, x.JobID });
                    table.ForeignKey(
                        name: "FK_RequiredSkills_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequiredSkills_Skills_SkillID",
                        column: x => x.SkillID,
                        principalTable: "Skills",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "a", "Real Estate", "Redfin", "www.Redfin.com" },
                    { 2, "b", "Technology", "Microsoft", "www.Microsoft.com" },
                    { 3, "c", "e-commerce Market", "Groupon", "www.Groupon.com" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "ID", "SkillName" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, "C#" },
                    { 3, "C++" },
                    { 4, "React.js" },
                    { 5, "JavaScript" },
                    { 6, "SQL" },
                    { 7, "CSS" },
                    { 8, "Project Management" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "ApplicationUrl", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 1, "www.TechCompanyThatShouldTotallyHireRick.com/BestEverJobs/Apply", 1, " Solid understanding of Object Oriented Programming and some other stuff, experience with SQL", "C# Back-End Developer", "Kirkland,WA", "8k monthly" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "ApplicationUrl", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 2, "www.RickSuxNeverHireHim.com/IfIWorkedOnFrontEnd", 1, "1+ years of experience with React.js. Gotta be a cool cat and like other cool cats, and CSS.", "Front-end Developer", "Bellevue,WA", "5k monthly" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "ApplicationUrl", "CompanyID", "Description", "JobTitle", "Location", "WageRange" },
                values: new object[] { 3, "www.WayCoolerThanYourTechCompany.com/N00bCrushers/apply", 2, "Solid understanding of Object Oriented Programming principles, 4000+ years of experience with latest frameworks. GIANT ROBOT BODY a must. Lazer eyes a plus!!", "GIGASENIOR MECHA-DEVELOPER", "Secret Lunar Base, WV", "5-6 Xolthar-Class Power Crystals/Month, DOE" });

            migrationBuilder.InsertData(
                table: "RequiredSkills",
                columns: new[] { "SkillID", "JobID" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 6, 1 },
                    { 7, 2 },
                    { 4, 3 }
                });

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
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
