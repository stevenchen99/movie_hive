namespace MovieHive.DTOs
{
    public class MovieLiteDTO
    {
        public int Id { get; set; }
        public string? MovieId { get; set; }
        public string? Title { get; set; }
        public List<string>? Genre { get; set; }
    }
}
