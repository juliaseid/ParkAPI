using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkAPI.Migrations
{
    public partial class MoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Accessible", "Clean", "Comments", "FunForKids", "FunForParents", "ParkId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 4, "Prepare for a lot of time in the car.", 2, 3, 4, 3 },
                    { 2, 4, 3, "Relaxing and fun, but the beach can get gross.", 4, 4, 3, 2 },
                    { 3, 5, 2, "Lots to do, but also lots of trash and goose poop.", 5, 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Token", "Username" },
                values: new object[,]
                {
                    { 1, "p", null, "Pete" },
                    { 2, "g", null, "George" },
                    { 3, "s", null, "Sam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "RatingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
