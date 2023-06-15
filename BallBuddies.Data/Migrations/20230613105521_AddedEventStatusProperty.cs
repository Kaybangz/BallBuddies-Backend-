using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BallBuddies.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventStatusProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59c445db-5fc7-44e9-aa45-555eebb5bf53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad13fe04-7f1b-43a4-955f-5cbd44c1dc43");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a841c6ea-68cb-47a4-8e1a-e19e66ea82e4", "dca3e7d8-23aa-439d-8499-fe23d4088398", "Admin", "ADMIN" },
                    { "dbab82b3-1f65-49b8-81fa-80c68a76adb1", "3d8f4002-2a9b-4f7a-8a52-7f3e0b2bd7c2", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a841c6ea-68cb-47a4-8e1a-e19e66ea82e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbab82b3-1f65-49b8-81fa-80c68a76adb1");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59c445db-5fc7-44e9-aa45-555eebb5bf53", "e3880174-2df3-4974-bc97-1824b84994d9", "User", "USER" },
                    { "ad13fe04-7f1b-43a4-955f-5cbd44c1dc43", "54ddd5bb-eab3-40f6-9c9d-c3c2dd28e62f", "Admin", "ADMIN" }
                });
        }
    }
}
