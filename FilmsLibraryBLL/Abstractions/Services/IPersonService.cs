using FilmsLibraryData.Entities;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface IPersonService
    {
        Task<int> CreatePersonAsync(string personName);
        Task<Person> ReadPersonAsync(int personID);
        Task<Person> RenamePersonAsync(int personID, string personName);
        Task<Person> DeletePersonAsync(int personId);
    }
}
