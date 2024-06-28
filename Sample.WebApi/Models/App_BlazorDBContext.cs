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
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "bda30051-c030-467c-93e8-ae3e0b5bee4e"
                },
                 new IdentityRole
                 {
                     Name = "User",
                     NormalizedName = "USER",
                     Id = "e15c12c3-5582-4711-9306-984e0df1dcdd"
                 }
           );

            var hash = new PasswordHasher<UserPofile>();
            modelBuilder.Entity<UserPofile>().HasData(

               new UserPofile
               {
                   Id = "2314094f-0974-4783-ae24-97b801faf01d",
                   Email = "admin@admin.com",
                   NormalizedEmail = "ADMIN@ADMIN.COM",
                   PasswordHash = hash.HashPassword(null, "admin@123#Admin"),
                   UserName = "admin@admin.com",
                   NormalizedUserName = "ADMIN@ADMIN.COM",
                   FirstName = "System",
                   Lastname = "Admin",
                   ProfilePicture="noimage.png"
               },
                new UserPofile
                {
                    Id = "fe750ed8-92fd-484e-a3fa-dc5f4b62c0d1",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    PasswordHash = hash.HashPassword(null, "user@123#User"),
                    UserName = "user@user.com",
                    NormalizedUserName = "USER@USER.COM",
                    FirstName = "System",
                    Lastname = "User",
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
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PaymentDetails> Payments { get; set; }
        public DbSet<ScreensPermission>  ScreensPermissions { get; set; }
        public IEnumerable<Products> GetSortedProducts(int pageNumber, int pageSize, string sortBy)
        {
            List<Products> result = new List<Products>();

            using (var connection = Database.GetDbConnection() as SqlConnection)
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetSortedProducts";

                    var pageNumberParam = new SqlParameter("@pageNumber", SqlDbType.Int);
                    pageNumberParam.Value = pageNumber;

                    var pageSizeParam = new SqlParameter("@pageSize", SqlDbType.Int);
                    pageSizeParam.Value = pageSize;

                    var sortByParam = new SqlParameter("@sortBy", SqlDbType.NVarChar, 50);
                    sortByParam.Value = sortBy;

                    command.Parameters.AddRange(new[] { pageNumberParam, pageSizeParam, sortByParam });

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Products
                            {
                                ProductId = (int)reader["ProductId"],
                                ProductName = reader["ProductName"].ToString(),
                                ProductPrice = (decimal)reader["ProductPrice"],
                                ProductCategory = reader["ProductCategory"].ToString(),
                                ProductImage = reader["ProductImage"].ToString(),
                                ProductDescription = reader["ProductDescription"].ToString(),
                                EntryDate = (DateTime)reader["EntryDate"]
                            };
                            result.Add(product);
                        }
                    }
                }
            }

            return result;
        }
        public IEnumerable<ProductCategory> GetSortedProductCategories(int pageNumber, int pageSize, string sortBy)
        {
            List<ProductCategory> result = new List<ProductCategory>();

            using (var connection = Database.GetDbConnection() as SqlConnection)
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetSortedProductCategories";

                    var pageNumberParam = new SqlParameter("@pageNumber", SqlDbType.Int);
                    pageNumberParam.Value = pageNumber;

                    var pageSizeParam = new SqlParameter("@pageSize", SqlDbType.Int);
                    pageSizeParam.Value = pageSize;

                    var sortByParam = new SqlParameter("@sortBy", SqlDbType.NVarChar, 50);
                    sortByParam.Value = sortBy;

                    command.Parameters.AddRange(new[] { pageNumberParam, pageSizeParam, sortByParam });

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var category = new ProductCategory
                            {
                                CategoryId = (int)reader["CategoryId"],
                                CategoryName = reader["CategoryName"].ToString(),
                                CategoryDescription = reader["CategoryDescription"].ToString(),
                                CreationDate = (DateTime)reader["CreationDate"]
                            };
                            result.Add(category);
                        }
                    }
                }
            }

            return result;
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
