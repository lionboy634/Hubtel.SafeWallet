using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hubtel.SafeWallet.Core.Migrations
{
    public partial class WalletTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f74845b-f65e-4f63-aff5-3e273d3e3cce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e9ac9f-23d1-43f7-8e0e-f4cb6b41f0b7");

            migrationBuilder.CreateTable(
                name: "wallet",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    account_scheme = table.Column<string>(type: "text", nullable: false),
                    account_number = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false),
                    owner = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallet", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a0943eb-277e-43e2-860c-2efb3639b86e", "df4529a8-1884-4a92-bf65-4bd88034e9ea", "Administrator", "ADMINISTRATOR" },
                    { "d1dfa8d7-af20-4640-93b2-508bbe7fed97", "9950be6a-2c1e-43e7-8715-2144051e312a", "Member", "MEMBER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wallet");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a0943eb-277e-43e2-860c-2efb3639b86e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1dfa8d7-af20-4640-93b2-508bbe7fed97");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f74845b-f65e-4f63-aff5-3e273d3e3cce", "f43baa06-33ba-4c5b-aacf-142e2249848c", "Administrator", "ADMINISTRATOR" },
                    { "65e9ac9f-23d1-43f7-8e0e-f4cb6b41f0b7", "1e48d5a4-a9c2-45e6-ac38-314075e81409", "Member", "MEMBER" }
                });
        }
    }
}
