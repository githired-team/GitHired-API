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
                    Title = table.Column<string>(nullable: true),
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
                    Title = table.Column<string>(nullable: true),
                    CompanyID = table.Column<int>(nullable: false),
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
                name: "requiredskills",
                columns: table => new
                {
                    skill = table.Column<int>(nullable: false),
                    JobID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requiredskills", x => new { x.skill, x.JobID });
                    table.ForeignKey(
                        name: "FK_requiredskills_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Headline", "Industry", "Title", "Website" },
                values: new object[,]
                {
                    { 1, "", "Technology", "Microsoft", "www.microsoft.com" },
                    { 2, "", "e-commerce marketplace", "Groupon", "www.groupon.com" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "ID", "CompanyID", "Description", "Location", "Title", "WageRange" },
                values: new object[,]
                {
                    { 1, 0, "Experience with AngularJS, React, Backbone or other Model-View-Whatever frameworks ", "Seattle,WA", "Junior Web Develoer", "4k-5k monthly" },
                    { 2, 0, "Solid understanding of Object Oriented Programming,Outstanding verbal and written communication skills", "Bellevue,WA", "Front-end Developer", "5k monthly" },
                    { 3, 0, " Solid understanding of Object Oriented Programming", "Kirkland,WA", "Java Developer", "8k monthly" },
                    { 4, 0, " Solid understanding of Object Oriented Programming", "Lynwood,WA", "Junior C# Developer", "5k-6k monthly" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyID",
                table: "Jobs",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_requiredskills_JobID",
                table: "requiredskills",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requiredskills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
