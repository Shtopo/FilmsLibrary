using FilmsLibraryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsLibraryData.DTOs
{
    public class FilmInfoResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Year { get; set; }

        public long Duration { get; set; }

        public int Rating { get; set; }

        public FilmInfoDirector?  Director { get; set; }

        public IEnumerable<FilmInfoGenres> Genres { get; set; }

        public IEnumerable<FilmInfoCountries> Countries { get; set; }

        public IEnumerable<FilmInfoPerson> Actors { get; set; }
    }

    public class FilmInfoDirector
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FilmInfoGenres
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FilmInfoCountries
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FilmInfoPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
