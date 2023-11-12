using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.SafeWallet.Core.Migrations
{
    public partial class WalletIDFluenApiValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da299e04-0ad5-4f3b-94fa-bbc0c7c109df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecde0e0e-ef1f-4c9a-ad0f-2d75ce61e13b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1708e3c-41f3-48c0-a257-639936a6ad5a", "e0f1fc71-5cfe-48a6-aa5f-6b6d9e036cab", "Member", "MEMBER" },
                    { "d2e983a3-8dc3-43c5-9067-e0fbc48f5f0a", "23890ea9-bd6a-49ec-b1d5-ae396ba4ad41", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "da299e04-0ad5-4f3b-94fa-bbc0c7c109df", "2f87dce8-518f-450a-87e3-7461dd1c94fe", "Member", "MEMBER" },
                    { "ecde0e0e-ef1f-4c9a-ad0f-2d75ce61e13b", "d713da4a-1f64-4da9-a5b0-192229178a49", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
