using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.WebApi.Migrations
{
    public partial class ProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.CategoryId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                column: "ConcurrencyStamp",
                value: "8e6799bb-60b3-4c12-94b9-f545fc52a444");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15c12c3-5582-4711-9306-984e0df1dcdd",
                column: "ConcurrencyStamp",
                value: "41f78b37-17cc-4456-aae8-5916a8f35cb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2314094f-0974-4783-ae24-97b801faf01d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6aadbc95-9026-4242-a88d-5f34f67b9d95", "AQAAAAEAACcQAAAAEK6xtmFX8/MsQ5/0qSHeCsBQ8Y3wqYfLytL9lZI5tdVp7JIP8QbIaznLU1O7FX23qA==", "f01b449b-e3e6-45d3-9202-286d0a39d8c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "264a3f77-2fd0-4aa7-9463-7f0857d94a5e", "AQAAAAEAACcQAAAAEL73YsyU2mDNu1p7lwBflCIhRi9ZxUHFuLYiIywLT0DcoQ7/HPANxtzmC586qTE7NA==", "9993223e-c8b2-4c14-9f63-785be42518af" });
        }
    }
}
