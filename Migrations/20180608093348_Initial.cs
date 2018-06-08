using Microsoft.EntityFrameworkCore.Migrations;

namespace Electron.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationsID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Location = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationsID);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationsID", "Location", "Region" },
                values: new object[] { 1, "Kumasi", "Ashanti" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationsID", "Location", "Region" },
                values: new object[] { 2, "Accra", "Greater Accra" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationsID", "Location", "Region" },
                values: new object[] { 3, "Nalerigu", "Northern" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
