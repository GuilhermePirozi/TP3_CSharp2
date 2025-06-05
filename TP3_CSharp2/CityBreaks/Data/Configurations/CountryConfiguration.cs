using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configurations {
    public class CountryConfiguration : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.Property(c => c.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Name");

            builder.Property(c => c.CountryCode)
                .HasMaxLength(5)
                .HasColumnName("Code");


            builder.HasData(
                new Country { Id = 1, CountryCode = "BR", CountryName = "Brasil" },
                new Country { Id = 2, CountryCode = "PT", CountryName = "Portugal" },
                new Country { Id = 3, CountryCode = "IT", CountryName = "Itália" },
                new Country { Id = 4, CountryCode = "FR", CountryName = "França" }
            );
        }
    }
}
