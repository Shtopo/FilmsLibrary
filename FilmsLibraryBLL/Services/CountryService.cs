using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibraryBLL.Services
{
    public class CountryService : ICountryService

    {
        private readonly FilmsContext _context;
        public CountryService(FilmsContext context)
        {
            _context = context;
        }
        public async Task<int> AddCountryAsync(string countryName)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryName);

            if (country == null)
            {
                country = new Country { Name = countryName };
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
            }
            return country.Id;
        }

        public async Task<Country> ReadCountryAsync(int countryID)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryID);

            if (country == null)
            {
                throw new Exception("Country not found");
            }

            return country;
        }

        public async Task<List<Country>> ReturnCountryAsync()
        {
            var country = await _context.Countries.ToListAsync();

            return country;
        }

        public async Task<Country> RenameCountryAsync(int countryID, string countryName)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryID);
            if (country == null)
            {
                throw new KeyNotFoundException("Country not found");
            }

            country.Name = countryName;
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<Country> DeleteCountryAsync(int countryId)
        {

            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
            return country;
        }
    }
}
