using Microsoft.EntityFrameworkCore.Migrations;

namespace Adso.Migrations
{
    public partial class NewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityNmae",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "City");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "CityNmae",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "City",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");
        }
    }
}
