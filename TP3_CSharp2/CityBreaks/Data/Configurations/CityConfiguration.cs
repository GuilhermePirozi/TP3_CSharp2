using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configurations {
    public class CityConfiguration : IEntityTypeConfiguration<City> {
        public void Configure(EntityTypeBuilder<City> builder) {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .HasColumnName("CityName");

            builder.Property(c => c.CountryId)
                .HasColumnName("Country_Id");


            builder.HasData(
               new City { Id = 1, Name = "Rio de Janeiro", CountryId = 1 },
               new City { Id = 2, Name = "São Paulo", CountryId = 1 },
               new City { Id = 3, Name = "Lisboa", CountryId = 2 },
               new City { Id = 4, Name = "Porto", CountryId = 2 },
               new City { Id = 5, Name = "Roma", CountryId = 3 },
               new City { Id = 6, Name = "Paris", CountryId = 4 }
           );
        }
    }
}
