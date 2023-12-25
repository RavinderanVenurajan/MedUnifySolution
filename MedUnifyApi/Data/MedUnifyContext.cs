using MedUnifyApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MedUnifyApi.Data
{
    public class MedUnifyContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ProgressNote> ProgressNotes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        // ... other DbSets
        public MedUnifyContext(DbContextOptions<MedUnifyContext> options)
               : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure the Patients table is being created
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Patient>().HasData(
             new Patient
             {
                 PatientId = 1,
                 FirstName = "John",
                 LastName = "Doe",
                 Address = "123 Main St",
                 State = "CA",
                 City = "Los Angeles",
                 OrganizationId = 1, 
                 CreatedAt = DateTime.Now,
                 UpdatedAt = DateTime.Now,
                 IsDeleted = false,
             },
             new Patient
             {
                 PatientId = 2,
                 FirstName = "Jane",
                 LastName = "Smith",
                 Address = "456 Oak St",
                 State = "NY",
                 City = "New York",
                 OrganizationId = 1,
                 CreatedAt = DateTime.Now,
                 UpdatedAt = DateTime.Now,
                 IsDeleted = false,
                 
             }
             // Add more seed data for Patients as needed
         );

            // Seed ProgressNotes table
            modelBuilder.Entity<ProgressNote>().HasData(
                new ProgressNote
                {
                    Id = 1,
                    VisitId = 1,
                    VisitDate = DateTime.Now,
                    SectionName = "Height",
                    SectionText = "5.6",
                   
                },
                new ProgressNote
                {
                    Id = 2,
                    VisitId = 2,
                    VisitDate = DateTime.Now,
                    SectionName = "Weight",
                    SectionText = "59 - Gradual decrease",
                    
                }
                // Add more seed data for ProgressNotes as needed
            );

            // Add other seeding logic for additional tables

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={AppContext.BaseDirectory}/medunifyDB.db");
    }
}
