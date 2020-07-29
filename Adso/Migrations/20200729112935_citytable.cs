using Microsoft.EntityFrameworkCore.Migrations;

namespace Adso.Migrations
{
    public partial class citytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityCode", "CityName", "CountryId", "Status" },
                values: new object[] { 1, "LHR", "Lahore", 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
