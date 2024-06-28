using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.WebApi.Migrations
{
    public partial class ConfigRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                column: "ConcurrencyStamp",
                value: "1ee5fb48-8df6-4771-a13f-9711d2a6f022");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15c12c3-5582-4711-9306-984e0df1dcdd",
                column: "ConcurrencyStamp",
                value: "c560c126-20b1-46be-bb86-1d4d142f6ff5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2314094f-0974-4783-ae24-97b801faf01d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d49e4b10-b3b0-4274-95a6-6ff96fed4bef", "AQAAAAEAACcQAAAAEDtVztsyKeSY3iUS3KRE/MsKWrWaay9lH14LPMY9ePt8fsHwJ+m/uPGikRUBHn2b8w==", "4a0a0390-8910-46bc-8cff-88bd4dd2681e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36fd3dbd-2cc7-48b0-adec-91daeee86137", "AQAAAAEAACcQAAAAEMnY8CoY+rgAC+aqEf+o5B9v6gkxWf9l6TLxwDwDpjqJRudAxcpKKz4MJ2/YzxqqPg==", "06ff21e3-74b8-43f8-986b-0dc32a2a7237" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                column: "ConcurrencyStamp",
                value: "e07b24ae-0d0c-4be2-bf29-a42e9ad36314");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15c12c3-5582-4711-9306-984e0df1dcdd",
                column: "ConcurrencyStamp",
                value: "44e41b08-fd8b-4fee-80bd-b532c80f5bab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2314094f-0974-4783-ae24-97b801faf01d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d23e8400-b717-4791-9fa4-9dc59d08762b", "AQAAAAEAACcQAAAAEAEBuUmDLo+Bit0PKyaKVzPOekensjrghk0RWd684UhAOr43Ov3fK36+7gj4KUOnRQ==", "23d4d468-dfe8-4d36-a02f-78a27ee9af4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f58199a-aa6e-4331-ae59-31f2471cf6ce", "AQAAAAEAACcQAAAAEHqwxxdHgtwPhPuTL0gudcSUlVEgjRK6CxqSZtQmWKxFrjapZfjADMoOicjM0h7/mg==", "e3e9779b-0eff-4917-9c50-27a41a9f707a" });
        }
    }
}
