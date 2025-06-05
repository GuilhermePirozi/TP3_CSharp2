using CityBreaks.Data;
using CityBreaks.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityBreaks.Services {
    public class PropertyService {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context) {
            _context = context;
        }

        public async Task DeleteAsync(int id) {
            var property = await _context.Properties.FindAsync(id);
            if (property != null) {
                property.DeletedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Property>> GetFilteredAsync(
            decimal? minPrice,
            decimal? maxPrice,
            string cityName,
            string propertyName) {
            var query = _context.Properties
                .Include(p => p.City)
                .ThenInclude(c => c.Country)
                .AsQueryable();

            if (minPrice.HasValue)
                query = query.Where(p => p.PricePerNight >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);

            if (!string.IsNullOrWhiteSpace(cityName))
                query = query.Where(p => p.City.Name.ToLower().Contains(cityName.ToLower()));

            if (!string.IsNullOrWhiteSpace(propertyName))
                query = query.Where(p => p.Name.ToLower().Contains(propertyName.ToLower()));

            return await query.ToListAsync();
        }
    }
}
