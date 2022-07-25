using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSolution.Context
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string IdImbd { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public string UserScore { get; set; }
        public string Ratings { get; set; }
        public string MetaScore { get; set; }

    }

    public partial class Rating
    {
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public string Source { get; set; }
        public string Value { get; set; }

        public Rating(string source, string value)
        {
            Source = source;
            Value = value;
        }  
    }
}
