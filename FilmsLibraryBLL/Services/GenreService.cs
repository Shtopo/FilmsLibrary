using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibraryBLL.Services
{
    public class GenreService : IGenreService
    {
        private readonly FilmsContext _context;
        public GenreService(FilmsContext context)
        {
            _context = context;
        }

        public async Task<int> AddGenreAsync(string genreName)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);
            if (genre == null)
            {
                _context.Genres.Add(new Genre() { Name = genreName });
                await _context.SaveChangesAsync();
            }
            return genre.Id;
        }

        public async Task<List<Genre>> ReadAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> RenameGenreAsync(int genreID, string genreName)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreID);
            if (genre == null)
            {
                throw new Exception("Country not found");
            }

            genre.Name = genreName;
            _context.Genres.Update(genre);
            await _context.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> DeleteGenreAsync(int genreId)
        {

            var genre = await _context.Genres.FirstOrDefaultAsync(c => c.Id == genreId);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
            return genre;
        }
    }
}
