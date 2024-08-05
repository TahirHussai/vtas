using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sample.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Plus_AddFieldsToAspNetUserRoles_AspNetUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SufixId = table.Column<int>(type: "int", nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MailingAddressId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    EmailWorkId = table.Column<int>(type: "int", nullable: true),
                    EmailPersonalId = table.Column<int>(type: "int", nullable: true),
                    EmergencyPersonId = table.Column<int>(type: "int", nullable: true),
                    SpouseId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Crid = table.Column<int>(type: "int", nullable: true),
                    PrimaryPhoneId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: false),
                    CreateByID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedByID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessLevelID = table.Column<int>(type: "int", nullable: true),
                    PersonStatusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04552f0c-1204-454f-88fe-dd5346ec5faf", null, "Vendor", "VENDOR" },
                    { "322c2338-b9cd-45db-8f3b-1bcf5cb2ab01", null, "Applicant", "APPLICANT" },
                    { "70f9b212-6cda-4b09-8b9d-b48a138ad518", null, "Client", "CLIENT" },
                    { "a1a446d6-5b18-41ee-adc4-f18eb5f5b8e2", null, "Recruiter", "Recruiter" },
                    { "bda30051-c030-467c-93e8-ae3e0b5bee4e", null, "SuperAdmin", "SUPERADMIN" },
                    { "e15c12c3-5582-4711-9306-984e0df1dcdd", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreatedDate", "Crid", "CustomerId", "Email", "EmailConfirmed", "EmailPersonalId", "EmailWorkId", "EmergencyPersonId", "FamilyName", "FirstName", "IsActive", "Lastname", "LockoutEnabled", "LockoutEnd", "MailingAddressId", "MiddleName", "ModifyById", "ModifyDate", "NickName", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PermanentAddressId", "PhoneNumber", "PhoneNumberConfirmed", "PrimaryPhoneId", "ProfilePicture", "SecurityStamp", "SpouseId", "SufixId", "Title", "TwoFactorEnabled", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { "2314094f-0974-4783-ae24-97b801faf01d", 0, "1b38de53-f241-48d7-b2ac-7892c0dc73a4", "", new DateTime(2024, 8, 6, 0, 19, 32, 497, DateTimeKind.Local).AddTicks(8073), null, "", "superadmin@admin.com", true, null, null, null, null, "Super", true, "Admin", false, null, null, null, "", new DateTime(2024, 8, 6, 0, 19, 32, 497, DateTimeKind.Local).AddTicks(8087), null, "SUPERADMIN@ADMIN.COM", "SUPERADMIN@ADMIN.COM", "", "AQAAAAIAAYagAAAAEFnIVsF7zLPuoh7vfJ1pulf2drvC7mRY2I4IkCiC5zfHEcyOr6IjtDhT8OaX3f4RDA==", null, null, false, null, "noimage.png", "23a1a01c-ba5a-45db-af93-973c1b01023c", null, null, null, false, "superadmin@admin.com", "superadmin@123#Admin" },
                    { "7375512a-4e4b-4178-babc-1de292b177b4", 0, "ce061d8b-b3e7-42b6-850c-4147dab35679", "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 622, DateTimeKind.Local).AddTicks(663), null, "", "customer@admin.com", true, null, null, null, null, "Customer", true, "Admin", false, null, null, null, "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 622, DateTimeKind.Local).AddTicks(675), null, "CUSTOMER@ADMIN.COM", "CUSTOMER@ADMIN.COM", "2314094f-0974-4783-ae24-97b801faf01d", "AQAAAAIAAYagAAAAEFlXrUVoWzZfMkQiDy9AlvFoWkG15FxIiGW9Gjz3xD/a855kKjDO7KEi+RoGFhMAGQ==", null, null, false, null, "noimage.png", "0f15cfb6-0abe-4898-919b-ebf37d441f28", null, null, null, false, "customer@admin.com", "superadmin@123#Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "AccessLevelID", "CreateByID", "CreatedDate", "Discriminator", "PersonStatusID", "UpdatedByID", "UpdatedDate" },
                values: new object[,]
                {
                    { "bda30051-c030-467c-93e8-ae3e0b5bee4e", "2314094f-0974-4783-ae24-97b801faf01d", 1, "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8057), "AspNetUserRole", 1, "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8071) },
                    { "e15c12c3-5582-4711-9306-984e0df1dcdd", "7375512a-4e4b-4178-babc-1de292b177b4", 1, "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8077), "AspNetUserRole", 1, "2314094f-0974-4783-ae24-97b801faf01d", new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8079) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
