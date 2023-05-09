using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BallBuddies.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2659f5d8-5bfe-4ba6-a87b-6d6b19c7a5db", "df80611b-694b-444e-b79c-59540b1b4c5f", "Manager", "MANAGER" },
                    { "bb66bcb8-c940-4651-b671-e70b5e1fc183", "fb3ff9ec-d546-4dec-be4d-770dfc6b12cf", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2659f5d8-5bfe-4ba6-a87b-6d6b19c7a5db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb66bcb8-c940-4651-b671-e70b5e1fc183");
        }
    }
}
