using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hubtel.SafeWallet.Core.Migrations
{
    public partial class AddedUserFirstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "158e32ed-0a10-4efe-8d48-78613fa65097");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a1489ab-15c8-4170-b333-f07880518720");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "abdd72eb-2054-4c96-a9f2-c495eea13506", "b47cca25-5497-4cde-aca1-a07ad11d9714", "Administrator", "ADMINISTRATOR" },
                    { "fa6a2a31-30e1-4f6a-8b31-b057f8ee6b74", "67aa40f1-8d04-4fcc-97df-d059056da66b", "Member", "MEMBER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abdd72eb-2054-4c96-a9f2-c495eea13506");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa6a2a31-30e1-4f6a-8b31-b057f8ee6b74");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "158e32ed-0a10-4efe-8d48-78613fa65097", "e5659734-ae53-42b5-a8d7-34000718ea1a", "Member", "MEMBER" },
                    { "4a1489ab-15c8-4170-b333-f07880518720", "356da848-0241-4e9d-8d0b-e404674b8ecc", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
