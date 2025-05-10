using FilmsLibraryData.Entities;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface ICountryService
    {
        Task<int> AddCountryAsync(string countryName);
        Task<Country> ReadCountryAsync(int countryID);
        Task<List<Country>> ReturnCountryAsync();
        Task<Country> RenameCountryAsync(int countryID, string countryName);
        Task<Country> DeleteCountryAsync(int countryId);
    }
}
