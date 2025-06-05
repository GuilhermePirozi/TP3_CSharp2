using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Data.Configurations {
    public class PropertyConfiguration : IEntityTypeConfiguration<Property> {
        public void Configure(EntityTypeBuilder<Property> builder) {
            builder.Property(p => p.Name)
                .HasMaxLength(150)
                .HasColumnName("PropertyName");

            builder.Property(p => p.PricePerNight)
                .HasColumnName("Price");

            builder.Property(p => p.CityId)
                .HasColumnName("City_Id");


            builder.HasData(
                new Property { Id = 1, Name = "Copacabana Flat", PricePerNight = 300.00m, CityId = 1 },
                new Property { Id = 2, Name = "Studio Paulista", PricePerNight = 280.00m, CityId = 2 },
                new Property { Id = 3, Name = "Apartamento em Lisboa", PricePerNight = 450.00m, CityId = 3 },
                new Property { Id = 4, Name = "Suíte Ribeira", PricePerNight = 400.00m, CityId = 4 },
                new Property { Id = 5, Name = "Vila Romana", PricePerNight = 520.00m, CityId = 5 },
                new Property { Id = 6, Name = "Estúdio Trastevere", PricePerNight = 390.00m, CityId = 5 },
                new Property { Id = 7, Name = "Loft Montmartre", PricePerNight = 600.00m, CityId = 6 },
                new Property { Id = 8, Name = "Apartamento Torre Eiffel", PricePerNight = 720.00m, CityId = 6 }
            );
        }
    }
}
