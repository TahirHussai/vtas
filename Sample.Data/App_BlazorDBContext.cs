﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.Data;
using System.Data;

namespace Sample.Data
{
    public partial class App_BlazorDBContext : IdentityDbContext<UserPofile>
    {
     
        public App_BlazorDBContext()
        {
        }
        public App_BlazorDBContext(DbContextOptions<App_BlazorDBContext> options)
            : base(options)
        {
        }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<LuRegion> LuRegions { get; set; }
        public DbSet<LuSector>  LuSectors { get; set; }
        public DbSet<UserAssignedRegion> UserAssignedRegions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
            
        modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN",
                    Id = "bda30051-c030-467c-93e8-ae3e0b5bee4e"
                },
                 new IdentityRole
                 {
                     Name = "Customer",
                     NormalizedName = "CUSTOMER",
                     Id = "e15c12c3-5582-4711-9306-984e0df1dcdd"
                 },
                   new IdentityRole
                   {
                       Name = "Vendor",
                       NormalizedName = "VENDOR",
                       Id = "04552f0c-1204-454f-88fe-dd5346ec5faf"
                   },
                   new IdentityRole
                   {
                       Name = "Applicant",
                       NormalizedName = "APPLICANT",
                       Id = "322c2338-b9cd-45db-8f3b-1bcf5cb2ab01"
                   },
                   new IdentityRole
                   {
                       Name = "Client",
                       NormalizedName = "CLIENT",
                       Id = "70f9b212-6cda-4b09-8b9d-b48a138ad518"
                   }
                   ,
                   new IdentityRole
                   {
                       Name = "Recruiter",
                       NormalizedName = "Recruiter",
                       Id = "a1a446d6-5b18-41ee-adc4-f18eb5f5b8e2"
                   }
           );

            var hash = new PasswordHasher<UserPofile>();
            modelBuilder.Entity<UserPofile>().HasData(

               new UserPofile
               {
                   Id = "2314094f-0974-4783-ae24-97b801faf01d",
                   Email = "superadmin@admin.com",
                   NormalizedEmail = "SUPERADMIN@ADMIN.COM",
                   PasswordHash = hash.HashPassword(null, "superadmin@123#Admin"),
                   UserPassword = "superadmin@123#Admin",
                   UserName = "superadmin@admin.com",
                   NormalizedUserName = "SUPERADMIN@ADMIN.COM",
                   FirstName = "Super",
                   Lastname = "Admin",
                   ParentId = "",
                   CreatedById = "",
                   ModifyById = "",
                   CreatedDate = DateTime.Now,
                   ModifyDate = DateTime.Now,
                   ProfilePicture = "noimage.png",
                   CustomerId = "",
                   IsActive = true,
                   EmailConfirmed = true,
                   AltId="NA",
                   OldId= "NA",
                   OldVtasId= "NA",
                   IndustryID= "NA",
                   LOB_ID= "NA",
                   Crid = "NA",
                   DisplayName= "Super Admin",
                   FaxID="NA"

               },
                new UserPofile
                {
                    Id = "7375512a-4e4b-4178-babc-1de292b177b4",
                    Email = "customer@admin.com",
                    NormalizedEmail = "CUSTOMER@ADMIN.COM",
                    PasswordHash = hash.HashPassword(null, "customer@123#Admin"),
                    UserName = "customer@admin.com",
                    NormalizedUserName = "CUSTOMER@ADMIN.COM",
                    FirstName = "Customer",
                    Lastname = "Admin",
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    ParentId = "2314094f-0974-4783-ae24-97b801faf01d",
                    CreatedById = "2314094f-0974-4783-ae24-97b801faf01d",
                    ModifyById = "2314094f-0974-4783-ae24-97b801faf01d",
                    ProfilePicture = "noimage.png",
                    CustomerId = "",
                    IsActive = true,
                    EmailConfirmed = true,
                    UserPassword = "superadmin@123#Admin",
                    AltId = "NA",
                    OldId = "NA",
                    OldVtasId = "NA",
                    IndustryID = "NA",
                    LOB_ID = "NA",
                    Crid="NA",
                    DisplayName = "Customer Admin",
                    FaxID = "NA"

                }
          );

            modelBuilder.Entity<AspNetUserRole>().HasData(
            new AspNetUserRole
            {
                UserId = "2314094f-0974-4783-ae24-97b801faf01d",
                RoleId = "bda30051-c030-467c-93e8-ae3e0b5bee4e",
                //AccessLevelID = 1,
                CreateByID = "2314094f-0974-4783-ae24-97b801faf01d",
                CreatedDate = DateTime.Now,
                PersonStatusID = 1,
                UpdatedByID = "2314094f-0974-4783-ae24-97b801faf01d",
                UpdatedDate = DateTime.Now
            },
            new AspNetUserRole
            {
                UserId = "7375512a-4e4b-4178-babc-1de292b177b4",
                RoleId = "e15c12c3-5582-4711-9306-984e0df1dcdd",
                //AccessLevelID = 1,
                CreateByID = "2314094f-0974-4783-ae24-97b801faf01d",
                CreatedDate = DateTime.Now,
                PersonStatusID = 1,
                UpdatedByID = "2314094f-0974-4783-ae24-97b801faf01d",
                UpdatedDate = DateTime.Now
            }
        );




        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
