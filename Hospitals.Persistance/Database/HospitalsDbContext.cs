using Hospitals.Domain.Models;
using Hospitals.Persistance.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Hospitals.Persistance.Database
{
    internal class HospitalsDbContext : DbContext
    {
        public HospitalsDbContext(DbContextOptions<HospitalsDbContext> options) : base(options)
        {
			try
			{
                var creator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (creator != null)
                {
                    if (!creator.CanConnect()) creator.Create();
                    if (!creator.HasTables())
                    {
                        creator.CreateTables();
                        CreateDataToTables();
                    }
                }
			}
			catch (Exception exception)
			{
                Console.WriteLine(exception.Message);
			}
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientsConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }

        private async void CreateDataToTables()
        {
            this.Sections.AddRange(
            new Section
            {
                Id = Guid.NewGuid(),
                Number = 1,
            },
            new Section() 
            {
                Id = Guid.NewGuid(),
                Number = 2,
            });
            this.Specialisations.AddRange(
                new Specialisation() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Surgery",
                },
                new Specialisation() 
                {
                    Id = Guid.NewGuid(),
                    Name = "Neurologist"
                }
                );
            this.Cabinets.AddRange(
                new Cabinet()
                {
                    Id = Guid.NewGuid(),
                    Number = 100,
                },
                new Cabinet()
                {
                    Id = Guid.NewGuid(),
                    Number = 123
                }
                );
            await SaveChangesAsync();
        }
    }
}
