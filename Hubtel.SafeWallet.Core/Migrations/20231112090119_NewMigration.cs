using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.SafeWallet.Core.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1708e3c-41f3-48c0-a257-639936a6ad5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2e983a3-8dc3-43c5-9067-e0fbc48f5f0a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "158e32ed-0a10-4efe-8d48-78613fa65097", "e5659734-ae53-42b5-a8d7-34000718ea1a", "Member", "MEMBER" },
                    { "4a1489ab-15c8-4170-b333-f07880518720", "356da848-0241-4e9d-8d0b-e404674b8ecc", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "158e32ed-0a10-4efe-8d48-78613fa65097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a1489ab-15c8-4170-b333-f07880518720");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1708e3c-41f3-48c0-a257-639936a6ad5a", "e0f1fc71-5cfe-48a6-aa5f-6b6d9e036cab", "Member", "MEMBER" },
                    { "d2e983a3-8dc3-43c5-9067-e0fbc48f5f0a", "23890ea9-bd6a-49ec-b1d5-ae396ba4ad41", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
