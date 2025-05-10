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
    }
}
