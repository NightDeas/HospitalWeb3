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
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
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

	}
}
