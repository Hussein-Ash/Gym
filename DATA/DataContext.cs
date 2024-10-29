using EvaluationBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvaluationBackend.DATA
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<AppUser> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            AppUser[] u = {
                new() {
                    CreationDate=DateTime.UtcNow,
                    UserName="SuperAdmin",
                    Role=UserRole.SuperAdmin,
                    Password="12345678",
                    PhoneNumber="07816565518",
                    Id=Guid.Parse("0f8f8a71-fa93-4897-7a54-45a069619c0e")

                }

            };






            modelBuilder.Entity<AppUser>().HasData(u);


            //     // Configure JsonData to be ignored by EF Core's entity mapping
            //     entity.Property(e => e.JsonObject)
            //           .HasConversion(
            //               v => v.ToString(),   // Convert JObject to string for storage
            //               v => JObject.Parse(v));  // Convert string back to JObject
            // });


            // seed data 

        }

    }
}