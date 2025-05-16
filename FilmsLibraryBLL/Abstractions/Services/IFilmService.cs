using FilmsLibraryBLL.Services;
using FilmsLibraryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface IFilmService
    {
        Task<int> PutFilmAsync(string filmName);
        Task<string> GetFilmsAsync();
        Task<Film> RenameFilmAsync(string filmName, string newName);
        Task<bool> AssignDirectorAsync(int filmId, int directorId);
        Task<bool> AssignGenreAsync(int filmId, int genreId);
        Task<bool> AssignCountryAsync(int filmId, int countryId);
        Task<bool> AssignActorsAsync(int filmId, int actorId);
    }
}
