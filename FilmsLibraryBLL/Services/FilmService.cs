﻿using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using static System.Net.WebRequestMethods;

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
            var films = await _context.Films
                .Include(f => f.Director)
                .Include(f => f.Rating)
                .Include(f => f.Genres)
                .Include(f => f.Countries)
                .Include(f => f.Actors)
                .ToListAsync();
            var filmsConvert = films.Select(f => new FilmInfoResponse()
            {
                Id = f.Id,
                Name = f.Name,
                Year = f.Year,
                Duration = f.Duration,
                Rating = CalculateRating(f.Rating),
                Director = f.Director!=null ? new FilmInfoDirector()
                {
                    Id = f.Director.Id,
                    Name = f.Director.Name
                    
                }: null, 
                Genres = f.Genres.Select(g => new FilmInfoGenres()
                {
                    Id = g.Id,
                    Name = g.Name
                }),
                Countries = f.Countries.Select(c => new FilmInfoCountries()
                {
                    Id = c.Id,
                    Name = c.Name
                }),
                Actors = f.Actors.Select(a => new FilmInfoPerson()
                {
                    Id = a.Id,
                    Name = a.Name
                })
            });
            var filmsJson = JsonSerializer.Serialize(filmsConvert);

            return filmsJson;
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

        public async Task<bool> AssignDirectorAsync(int filmId, int directorId)
        {
            var film = await _context.Films.FindAsync(filmId);
            var director = await _context.Persons.FindAsync(directorId);

            if (film == null || director == null)
                return false;

            film.DirectorId = directorId;
            await _context.SaveChangesAsync();
            return true;
        }

        private int CalculateRating(ICollection<Feedback> ratings)
        {
            if (!ratings.Any())
            {
                return 0;
            }
            return ratings.Select(f => f.Rating).Sum()/ratings.Count;
        }

        public async Task<bool> AssignGenreAsync(int filmId, int genreId)
        {
            if(filmId == 0 || genreId == 0)
            {
                return false;
            }

            var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);

            if(film == null || genre == null)
            {
                return false;
            }

            if(film.Genres == null)
            {
                film.Genres = new List<Genre>();
            }

            film.Genres.Add(genre);
            
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignCountryAsync(int filmId, int countryId)
        {
            if (filmId == 0 || countryId == 0)
            {
                return false;
            }

            var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == countryId);

            if (film == null || country == null)
            {
                return false;
            }

            if (film.Countries == null)
            {
                film.Countries = new List<Country>();
            }

            film.Countries.Add(country);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AssignActorsAsync(int filmId, int actorId)
        {
            if (filmId == 0 || actorId == 0)
            {
                return false;
            }

            var film = await _context.Films.FirstOrDefaultAsync(f => f.Id == filmId);
            var actor = await _context.Persons.FirstOrDefaultAsync(p => p.Id == actorId);

            if (film == null || actor == null)
            {
                return false;
            }

            if (film.Actors == null)
            {
                film.Actors = new List<Person>();
            }

            film.Actors.Add(actor);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
