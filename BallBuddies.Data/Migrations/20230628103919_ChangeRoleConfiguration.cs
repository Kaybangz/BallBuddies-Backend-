using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BallBuddies.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRoleConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "adf75217-0aeb-460c-8681-918cb402926b", "1be6b291-231c-4ce6-8e82-9e1eee7c99b6", "User", "USER" },
                    { "c722c751-7983-41bf-8182-97bd5571d77c", "3b662098-44d1-48f2-a19b-f28cd1f75597", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf75217-0aeb-460c-8681-918cb402926b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c722c751-7983-41bf-8182-97bd5571d77c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bd00524-2e1a-4214-8f63-f4115a7b2c0b", "97a687df-bc10-4767-abbf-b2edf4158d56", "admin", "ADMIN" },
                    { "b451af24-72df-498d-8102-323de8705011", "1c9df994-78dd-42f6-b0a3-42c656c152bc", "user", "USER" }
                });
        }
    }
}
