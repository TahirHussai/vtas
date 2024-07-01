using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sample.WebApi.Models
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
                    Name = "SuperAdministrator",
                    NormalizedName = "SUPERADMINISTRATOR",
                    Id = "bda30051-c030-467c-93e8-ae3e0b5bee4e"
                },
                 new IdentityRole
                 {
                     Name = "CustomerAdministrator",
                     NormalizedName = "CUSTOMERADMINISTRATOR",
                     Id = "e15c12c3-5582-4711-9306-984e0df1dcdd"
                 },
                   new IdentityRole
                   {
                       Name = "VendorAdministrator",
                       NormalizedName = "VENDORADMINISTRATOR",
                       Id = "04552f0c-1204-454f-88fe-dd5346ec5faf"
                   } ,
                   new IdentityRole
                   {
                       Name = "SubVendor",
                       NormalizedName = "SUBVENDOR",
                       Id = "322c2338-b9cd-45db-8f3b-1bcf5cb2ab01"
                   },
                   new IdentityRole
                   {
                       Name = "Client",
                       NormalizedName = "CLIENT",
                       Id = "70f9b212-6cda-4b09-8b9d-b48a138ad518"
                   }
           );

            var hash = new PasswordHasher<UserPofile>();
            modelBuilder.Entity<UserPofile>().HasData(

               new UserPofile
               {
                   Id = "2314094f-0974-4783-ae24-97b801faf01d",
                   Email = "superadmin@admin.com",
                   NormalizedEmail = "SUPERADMINADMIN@ADMIN.COM",
                   PasswordHash = hash.HashPassword(null, "superadmin@123#Admin"),
                   UserName = "superadmin@admin.com",
                   NormalizedUserName = "SUPERADMIN@ADMIN.COM",
                   FirstName = "Super",
                   Lastname = "Admin",
                   ProfilePicture="noimage.png"
               },
                new UserPofile
                {
                    Id = "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                    Email = "customer@admin.com",
                    NormalizedEmail = "CUSTOMER@ADMIN.COM",
                    PasswordHash = hash.HashPassword(null, "customer@123#Admin"),
                    UserName = "customer@admin.com",
                    NormalizedUserName = "CUSTOMER@ADMIN.COM",
                    FirstName = "Customer",
                    Lastname = "Admin",
                    ProfilePicture = "noimage.png"
                }
          );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

               new IdentityUserRole<string>
               {
                   UserId = "2314094f-0974-4783-ae24-97b801faf01d",
                   RoleId = "bda30051-c030-467c-93e8-ae3e0b5bee4e"
               },
                new IdentityUserRole<string>
                {
                    UserId = "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                    RoleId = "e15c12c3-5582-4711-9306-984e0df1dcdd"

                }
          );




        }
     
     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
