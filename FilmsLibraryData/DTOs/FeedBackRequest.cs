using System.ComponentModel.DataAnnotations;

namespace FilmsLibraryData.DTOs
{
    public class FeedBackRequest
    {

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int FilmId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
