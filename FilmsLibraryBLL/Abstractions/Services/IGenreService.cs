using FilmsLibraryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface IGenreService
    {
        Task<int> AddGenreAsync(string genreName);
        Task<List<Genre>> ReadAllGenresAsync();
        Task<Genre> RenameGenreAsync(int genreID, string genreName);
        Task<Genre> DeleteGenreAsync(int genreId);
   
    }
}
