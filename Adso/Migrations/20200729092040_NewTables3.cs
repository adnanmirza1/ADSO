using Microsoft.EntityFrameworkCore.Migrations;

namespace Adso.Migrations
{
    public partial class NewTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CallingCode", "CountryName", "Currency", "ShortName", "Status" },
                values: new object[] { 1, "+54", "Africa", "Rs", "Afr", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
