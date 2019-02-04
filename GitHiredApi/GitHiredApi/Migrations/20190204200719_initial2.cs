using Microsoft.EntityFrameworkCore.Migrations;

namespace GitHiredApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "ID",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
