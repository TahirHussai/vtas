﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sample.Data;


#nullable disable

namespace Sample.WebApi.Migrations
{
    [DbContext(typeof(App_BlazorDBContext))]
    [Migration("20240805191933_Initial_Plus_AddFieldsToAspNetUserRoles_AspNetUsers")]
    partial class Initial_Plus_AddFieldsToAspNetUserRoles_AspNetUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "e15c12c3-5582-4711-9306-984e0df1dcdd",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "04552f0c-1204-454f-88fe-dd5346ec5faf",
                            Name = "Vendor",
                            NormalizedName = "VENDOR"
                        },
                        new
                        {
                            Id = "322c2338-b9cd-45db-8f3b-1bcf5cb2ab01",
                            Name = "Applicant",
                            NormalizedName = "APPLICANT"
                        },
                        new
                        {
                            Id = "70f9b212-6cda-4b09-8b9d-b48a138ad518",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        },
                        new
                        {
                            Id = "a1a446d6-5b18-41ee-adc4-f18eb5f5b8e2",
                            Name = "Recruiter",
                            NormalizedName = "Recruiter"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("nvarchar(34)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Sample.Data.UserPofile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedById")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Crid")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("EmailPersonalId")
                        .HasColumnType("int");

                    b.Property<int?>("EmailWorkId")
                        .HasColumnType("int");

                    b.Property<int?>("EmergencyPersonId")
                        .HasColumnType("int");

                    b.Property<string>("FamilyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MailingAddressId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifyById")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PermanentAddressId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("PrimaryPhoneId")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpouseId")
                        .HasColumnType("int");

                    b.Property<int?>("SufixId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2314094f-0974-4783-ae24-97b801faf01d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1b38de53-f241-48d7-b2ac-7892c0dc73a4",
                            CreatedById = "",
                            CreatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 497, DateTimeKind.Local).AddTicks(8073),
                            CustomerId = "",
                            Email = "superadmin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Super",
                            IsActive = true,
                            Lastname = "Admin",
                            LockoutEnabled = false,
                            ModifyById = "",
                            ModifyDate = new DateTime(2024, 8, 6, 0, 19, 32, 497, DateTimeKind.Local).AddTicks(8087),
                            NormalizedEmail = "SUPERADMIN@ADMIN.COM",
                            NormalizedUserName = "SUPERADMIN@ADMIN.COM",
                            ParentId = "",
                            PasswordHash = "AQAAAAIAAYagAAAAEFnIVsF7zLPuoh7vfJ1pulf2drvC7mRY2I4IkCiC5zfHEcyOr6IjtDhT8OaX3f4RDA==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "noimage.png",
                            SecurityStamp = "23a1a01c-ba5a-45db-af93-973c1b01023c",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@admin.com",
                            UserPassword = "superadmin@123#Admin"
                        },
                        new
                        {
                            Id = "7375512a-4e4b-4178-babc-1de292b177b4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ce061d8b-b3e7-42b6-850c-4147dab35679",
                            CreatedById = "2314094f-0974-4783-ae24-97b801faf01d",
                            CreatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 622, DateTimeKind.Local).AddTicks(663),
                            CustomerId = "",
                            Email = "customer@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Customer",
                            IsActive = true,
                            Lastname = "Admin",
                            LockoutEnabled = false,
                            ModifyById = "2314094f-0974-4783-ae24-97b801faf01d",
                            ModifyDate = new DateTime(2024, 8, 6, 0, 19, 32, 622, DateTimeKind.Local).AddTicks(675),
                            NormalizedEmail = "CUSTOMER@ADMIN.COM",
                            NormalizedUserName = "CUSTOMER@ADMIN.COM",
                            ParentId = "2314094f-0974-4783-ae24-97b801faf01d",
                            PasswordHash = "AQAAAAIAAYagAAAAEFlXrUVoWzZfMkQiDy9AlvFoWkG15FxIiGW9Gjz3xD/a855kKjDO7KEi+RoGFhMAGQ==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "noimage.png",
                            SecurityStamp = "0f15cfb6-0abe-4898-919b-ebf37d441f28",
                            TwoFactorEnabled = false,
                            UserName = "customer@admin.com",
                            UserPassword = "superadmin@123#Admin"
                        });
                });

            modelBuilder.Entity("Sample.Data.AspNetUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<int?>("AccessLevelID")
                        .HasColumnType("int");

                    b.Property<string>("CreateByID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonStatusID")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedByID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("AspNetUserRole");

                    b.HasData(
                        new
                        {
                            UserId = "2314094f-0974-4783-ae24-97b801faf01d",
                            RoleId = "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                            AccessLevelID = 1,
                            CreateByID = "2314094f-0974-4783-ae24-97b801faf01d",
                            CreatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8057),
                            PersonStatusID = 1,
                            UpdatedByID = "2314094f-0974-4783-ae24-97b801faf01d",
                            UpdatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8071)
                        },
                        new
                        {
                            UserId = "7375512a-4e4b-4178-babc-1de292b177b4",
                            RoleId = "e15c12c3-5582-4711-9306-984e0df1dcdd",
                            AccessLevelID = 1,
                            CreateByID = "2314094f-0974-4783-ae24-97b801faf01d",
                            CreatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8077),
                            PersonStatusID = 1,
                            UpdatedByID = "2314094f-0974-4783-ae24-97b801faf01d",
                            UpdatedDate = new DateTime(2024, 8, 6, 0, 19, 32, 633, DateTimeKind.Local).AddTicks(8079)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sample.Data.UserPofile", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sample.Data.UserPofile", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sample.Data.UserPofile", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sample.Data.UserPofile", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
