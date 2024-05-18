using System.ComponentModel.DataAnnotations;

namespace MovieHive.Models
{
    public class Movie : Metadata
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? MovieId { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public List<string>? Genre { get; set; }

        [Required]
        public string? Director { get; set; }

        [Required]
        public string? Year { get; set; }

        [Required]
        public int? Duration { get; set; }

        [Required]
        public string? Rating { get; set; }
    }
}
