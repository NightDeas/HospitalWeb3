using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;

namespace DataBase
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                return;
            }
            optionsBuilder.UseSqlServer(DataBaseService.GetConnectionString());
            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasOne(x => x.MedCard)
                .WithOne(d => d.Patient)
                .HasForeignKey<MedCard>(x => x.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(x => x.InsurancePolicy)
                .WithOne(x => x.Patient)
                .HasForeignKey<InsurancePolicy>(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Patient)
                .HasForeignKey(x => x.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hospitalization>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Hospitalizations)
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            

            modelBuilder.Entity<Genre>().HasData(new List<Genre>()
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Мужской"
                },
                 new Genre()
                {
                    Id = 2,
                    Name = "Женский"
                },
            });
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedCard> MedCards { get; set; }
        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }

    }
}
