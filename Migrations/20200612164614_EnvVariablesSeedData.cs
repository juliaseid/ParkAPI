using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkAPI.Migrations
{
    public partial class EnvVariablesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parks",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Parks",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Beach", "EntranceFee", "Location", "Name", "ParkingPermit", "PicnicArea", "Playground", "RealBathrooms", "Type", "VisitorCenter" },
                values: new object[,]
                {
                    { 1, true, 0, "Issaquah", "Lake Sammamish State Park", "Discover Pass", true, true, true, "Washington State Park", false },
                    { 2, false, 0, "Redmond", "Marymoor Park", null, true, true, true, "King County Park", false },
                    { 3, true, 0, "Sammamish/Issaquah", "Pine Lake Park", null, true, true, true, "City Park", false },
                    { 4, false, 30, "Multiple Entrances", "Mount Rainier National Park", null, true, false, true, "National Park", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Parks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Parks",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
