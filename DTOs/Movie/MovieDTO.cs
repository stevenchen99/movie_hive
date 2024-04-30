using MovieHive.Models;

namespace MovieHive.DTOs
{
    public class MovieDTO : Metadata
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public string? Year { get; set; }
        public int Duration { get; set; }
        public string? Rating { get; set; }
    }
}
