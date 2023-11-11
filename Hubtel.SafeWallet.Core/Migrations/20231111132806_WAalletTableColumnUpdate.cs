using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.SafeWallet.Core.Migrations
{
    public partial class WAalletTableColumnUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a0943eb-277e-43e2-860c-2efb3639b86e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1dfa8d7-af20-4640-93b2-508bbe7fed97");

            migrationBuilder.AddColumn<string>(
                name: "hashed_account_no",
                table: "wallet",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da299e04-0ad5-4f3b-94fa-bbc0c7c109df", "2f87dce8-518f-450a-87e3-7461dd1c94fe", "Member", "MEMBER" },
                    { "ecde0e0e-ef1f-4c9a-ad0f-2d75ce61e13b", "d713da4a-1f64-4da9-a5b0-192229178a49", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da299e04-0ad5-4f3b-94fa-bbc0c7c109df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecde0e0e-ef1f-4c9a-ad0f-2d75ce61e13b");

            migrationBuilder.DropColumn(
                name: "hashed_account_no",
                table: "wallet");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a0943eb-277e-43e2-860c-2efb3639b86e", "df4529a8-1884-4a92-bf65-4bd88034e9ea", "Administrator", "ADMINISTRATOR" },
                    { "d1dfa8d7-af20-4640-93b2-508bbe7fed97", "9950be6a-2c1e-43e7-8715-2144051e312a", "Member", "MEMBER" }
                });
        }
    }
}
