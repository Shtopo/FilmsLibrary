using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmsLibraryData.Entities
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual Film Film { get; set; }

        [JsonIgnore]
        public virtual User Author { get; set; }

        [Required]
        public int FilmId { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}
