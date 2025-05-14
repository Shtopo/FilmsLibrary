namespace FilmsLibraryData.Entities
{
    public class Film
    {
        public int Id { get; set; } 

        public int? DirectorId { get; set; }

        public virtual Person Director { get; set; }

        public string Name { get; set; }

        public DateTime Year { get; set; }

        public long Duration { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<Country> Countries { get; set; }

        public virtual ICollection<Person> Actors { get; set; }

        public virtual ICollection<Feedback> Rating { get; set; }
    }
}
