using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BallBuddies.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53a492de-4937-4dda-b1cb-db12241258ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2c2bb9b-cc9f-4e1b-9907-c23d3b320a8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bd00524-2e1a-4214-8f63-f4115a7b2c0b", "97a687df-bc10-4767-abbf-b2edf4158d56", "admin", "ADMIN" },
                    { "b451af24-72df-498d-8102-323de8705011", "1c9df994-78dd-42f6-b0a3-42c656c152bc", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bd00524-2e1a-4214-8f63-f4115a7b2c0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b451af24-72df-498d-8102-323de8705011");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53a492de-4937-4dda-b1cb-db12241258ed", "7ff91e25-f2e0-4e89-9698-97c3b21c71f5", "Admin", "ADMIN" },
                    { "a2c2bb9b-cc9f-4e1b-9907-c23d3b320a8a", "1f26b79f-afce-4a13-bafe-2012204b3e19", "User", "USER" }
                });
        }
    }
}
