using Hospitals.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hospitals.Persistance.Database.Configurations
{
    internal class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            //Id
            builder.HasKey(x => x.Id);

            //Name
            builder.Property(x => x.Name).HasMaxLength(256);

            //Adres
            builder.OwnsOne(x => x.Adress, a =>
            {
                a.Property(a => a.Street).HasColumnName("Street");
                a.Property(a => a.NumberOfHouse).HasColumnName("NumberOfHouse");
            });
        }
    }
}
