using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FilmsLibraryData.DBContext
{
    public class FilmsContext : DbContext
    {
        public FilmsContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Film> Films => Set<Film>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Feedback> FeedBacks => Set<Feedback>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>(f =>
            {
                f.HasMany(f => f.Countries).WithMany();
                f.HasMany(f => f.Genres).WithMany();
                f.HasOne(f => f.Director)
                    .WithMany()
                    .HasForeignKey(f => f.DirectorId);
                f.HasMany(f => f.Actors).WithMany(a => a.Films);
                f.HasMany(f => f.Rating).WithOne(fb => fb.Film);
            });

            modelBuilder.Entity<Person>(p =>
            {
                p.HasMany(p => p.Films).WithMany(f => f.Actors);
            });

            modelBuilder.Entity<Feedback>(fb =>
            {
                fb.HasOne(fb => fb.Film).WithMany(f => f.Rating);
                fb.HasOne(fb => fb.Author).WithMany(u => u.Feedbacks);
            });

            modelBuilder.Entity<User>(u =>
            {
                u.HasMany(u => u.Feedbacks).WithOne(fb => fb.Author);
            });
        }
    }
}
