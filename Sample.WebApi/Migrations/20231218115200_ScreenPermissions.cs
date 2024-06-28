using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.WebApi.Migrations
{
    public partial class ScreenPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScreensPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ScreenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CanRead = table.Column<bool>(type: "bit", nullable: false),
                    CanWrite = table.Column<bool>(type: "bit", nullable: false),
                    CanEdit = table.Column<bool>(type: "bit", nullable: false),
                    CanDelete = table.Column<bool>(type: "bit", nullable: false),
                    CanAccess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreensPermissions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                column: "ConcurrencyStamp",
                value: "278bc623-6d17-44d4-b7d2-41f52fa778d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e15c12c3-5582-4711-9306-984e0df1dcdd",
                column: "ConcurrencyStamp",
                value: "9ea7ab13-1d47-4ded-928c-f0093da5cf54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2314094f-0974-4783-ae24-97b801faf01d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaa9a135-a12c-49ca-9e81-c6da6a64224a", "AQAAAAEAACcQAAAAEOyOicn9rlQjJ2chT0NooligwfG3nrN7UP5OUedzHmn9ER9C0GzTBRUw/SsLsYcVMQ==", "5a0caa2b-c187-4b30-9b8f-5aa7ff3d230d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1375c7d5-1733-4b0b-a791-698680f82358", "AQAAAAEAACcQAAAAEBOKBqh2xv8uvVpD1Sjv1yFdFDip7rehla86DHIIk3jm3oxVGOxthTKvVynxJW+M/w==", "1a9be2b4-3023-4069-b8ba-689452b6c19a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreensPermissions");

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
    }
}
