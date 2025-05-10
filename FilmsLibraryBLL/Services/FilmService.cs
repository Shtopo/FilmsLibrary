using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibraryBLL.Services
{
    public class FilmService : IFilmService
    {
        private readonly FilmsContext _context;
        public FilmService(FilmsContext context)
        {
            _context = context;
        }

        public async Task<int> PutFilmAsync(string filmName)
        {
            var film = await _context.Films.FirstOrDefaultAsync(f => f.Name == filmName);
            if (film == null)
            {
                film = new Film { Name = filmName };
                _context.Films.Add(film);
                await _context.SaveChangesAsync();
            }
            return film.Id;
        }

        public async Task<string> GetFilmsAsync()
        {
            var films = await _context.Films.ToListAsync();
            var findFilm = string.Join("\n", films.Select(f => f.Name));
            return findFilm;
        }

        public async Task<Film> RenameFilmAsync(string filmName, string newName)
        {
            if (string.IsNullOrWhiteSpace(filmName) || string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentNullException(nameof(filmName));
            }

            var film = await _context.Films.FirstOrDefaultAsync(f => f.Name == filmName);

            if (film == null)
            {
                throw new Exception("Not found");
            }
            film.Name = newName;
            _context.SaveChanges();

            return film;
        }


    }
}
