using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.WebApi.Migrations
{
    public partial class PaymentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                column: "ConcurrencyStamp",
                value: "89858dce-3b7f-455d-9841-3d7a392b1a64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15c12c3-5582-4711-9306-984e0df1dcdd",
                column: "ConcurrencyStamp",
                value: "56fc1e4d-73e9-48d1-8bfe-6c21a1a1d6e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2314094f-0974-4783-ae24-97b801faf01d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e09317c4-4252-4477-aba5-7ce4a8bee0fb", "AQAAAAEAACcQAAAAEKfBaIXOcQxiYkJCY9qM96BNAVo0xY+m/H7kW1nlpMsVD66t+4AdYlYqUQVPw9tFfw==", "81d080ca-6b2e-4051-86e7-dac8dea6544d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c97d100-d81f-40ad-9aaf-c6e8264c109b", "AQAAAAEAACcQAAAAENjUiO5zTo8A+VkQ1yNKjFRKTBvoPYRIk4CfBfwrxG2IaLLs7ZqzBBqxkX9LlrWiOg==", "f977ec05-7401-40a7-8ae5-7c5d6b10d189" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

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
    }
}
