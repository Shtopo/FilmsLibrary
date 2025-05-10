using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(string userName);
        Task<User> ReadUserAsync(int userID);
        Task<List<User>> GetAllUsersAsync();
        Task<User> RenameUserAsync(int userID, string newName);
        Task<User> DeleteUserAsync(int userId);

        Task<string> GetTokenAsync(LoginRequest request);
    }
}
