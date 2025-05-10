using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace FilmsLibraryBLL.Services
{
    public class UserService : IUserService
    {
        private readonly FilmsContext _context;
        private readonly ITokenProvider _tokenProvider;

        public UserService(FilmsContext context, ITokenProvider tokenProvider)
        {
            _context = context;
            _tokenProvider = tokenProvider;
        }

        public async Task<int> CreateUserAsync(string userName)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == userName);
            if (user == null)
            {
                user = new User() { Name = userName };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            return user.Id;
        }

        public async Task<User> ReadUserAsync(int userID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userID);
            if (user == null)
            {
                throw new Exception("User is not found!");
            }

            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> RenameUserAsync(int userID, string newName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userID);
            if (user == null)
            {
                throw new Exception("User is not found!");
            }

            user.Name = newName;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<string> GetTokenAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Name == request.Login);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var token = _tokenProvider.GenerateToken(user.Id);

            return token;
        }

    }
}
