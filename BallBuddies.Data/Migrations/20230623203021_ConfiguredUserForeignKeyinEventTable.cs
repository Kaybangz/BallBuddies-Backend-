using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BallBuddies.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredUserForeignKeyinEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatedByUserId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a841c6ea-68cb-47a4-8e1a-e19e66ea82e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbab82b3-1f65-49b8-81fa-80c68a76adb1");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b97f6d68-0467-4e62-9289-a647e7411b57", "d149b3df-68c1-4698-b467-e3badde24b1a", "User", "USER" },
                    { "da4e0061-1c54-4aa3-8b2e-91435acb340d", "aba7ed78-cb9c-4bd3-bb84-c9d333b1aed1", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatedByUserId",
                table: "Events",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_CreatedByUserId",
                table: "Events");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b97f6d68-0467-4e62-9289-a647e7411b57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da4e0061-1c54-4aa3-8b2e-91435acb340d");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a841c6ea-68cb-47a4-8e1a-e19e66ea82e4", "dca3e7d8-23aa-439d-8499-fe23d4088398", "Admin", "ADMIN" },
                    { "dbab82b3-1f65-49b8-81fa-80c68a76adb1", "3d8f4002-2a9b-4f7a-8a52-7f3e0b2bd7c2", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_CreatedByUserId",
                table: "Events",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
